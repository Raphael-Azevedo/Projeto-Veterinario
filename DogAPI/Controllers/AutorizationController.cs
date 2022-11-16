using System;
using System.Linq;
using System.Threading.Tasks;
using DogAPI.DTO.UsersDTO;
using DogAPI.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AutorizationController : Controller
    {
        private readonly IUserServices _userServices;

        public AutorizationController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        /// <summary>
        /// Registra um usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }
            try
            {
                await _userServices.RegisterUser(model);
                return Ok(model);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Efetua o Login
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>Token</returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }
            var result = await _userServices.LogIn(userInfo);
            if(result == null) 
                return Unauthorized(result);
                
            return Ok(result);

        }
        
        /// <summary>
        /// Logout usuario!
        /// </summary>
        /// <returns></returns>
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Result result = _userServices.Logout();
            if(result.IsSuccess) return Ok(result);
            return Unauthorized("Log out fail!");
        }
    }
}