using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DogAPI.DTO.UsersDTO;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DogAPI.Services.Interfaces;
using System.Linq;

namespace DogAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserServices(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            IMapper mapper,
                            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserTokenDTO> LogIn(LoginUserDTO userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                var userToken = GeraToken(userInfo);
                return await userToken;

            }
            else return null;
        }

        public Result Logout()
        {
            var result = _signInManager.SignOutAsync();
            if (result.IsCompletedSuccessfully)
                return Result.Ok();

            return Result.Fail("Falha ao realizar o logout");
        }

        public async Task RegisterUser(RegisterUserDTO model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Registro invalido");
            }
            await _userManager.AddClaimAsync(user, new Claim("Acesso", "Usuario"));
            await _signInManager.SignInAsync(user, false);
        }

        public async Task<UserTokenDTO> GeraToken(LoginUserDTO userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("meuPet", "pipoca"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credenciais
            );

            var user = GetUserPerEmail(userInfo.Email);
            return new UserTokenDTO()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token JWT Ok",
                Email = userInfo.Email,
                Claim = await GetClaims(user)
            };
            
        }
        private IdentityUser GetUserPerEmail(string Email)
        {
            
            return _signInManager
                        .UserManager
                        .Users
                        .FirstOrDefault(u => u.NormalizedEmail == Email.ToUpper());
        }
        private async Task<String> GetClaims(IdentityUser user)
        {
            var claims = await _signInManager.UserManager.GetClaimsAsync(user);
            return claims[0].Value;
        }

    }
}