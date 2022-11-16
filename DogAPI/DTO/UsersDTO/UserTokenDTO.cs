using System;

namespace DogAPI.DTO.UsersDTO
{
    public class UserTokenDTO
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Claim { get; set; }
    }
}