namespace BoilerPlate.Application.Models.Identity
{
    public class AuthResponse
    {

        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; }

        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; } 
    }
}

