using Base.Proyecto.Common.Dto;
using System.Text.Json.Serialization;

namespace Base.Proyecto.Common.Dto
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        //public AuthenticateResponse(UserDto user, string jwtToken, string refreshToken)
        //{
        //    Id = user.Id;
        //    FirstName = user.Firstname;
        //    LastName = user.Lastname;
        //    JwtToken = jwtToken;
        //    RefreshToken = refreshToken;
        //}
    }
}