using System.Threading.Tasks;
using DogAPI.DTO.UsersDTO;
using FluentResults;

namespace DogAPI.Services.Interfaces
{
    public interface IUserServices
    {
        Task RegisterUser(RegisterUserDTO model);
        Result Logout();
        Task<UserTokenDTO> LogIn(LoginUserDTO userInfo);
        Task<UserTokenDTO> GeraToken(LoginUserDTO userInfo);
    }
}