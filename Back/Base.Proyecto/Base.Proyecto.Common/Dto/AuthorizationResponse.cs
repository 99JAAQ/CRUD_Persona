namespace Base.Proyecto.Common.Dto
{
    public class AuthorizationResponse
    {
        public string Type { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}