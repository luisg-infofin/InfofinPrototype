namespace IdentityService.Models
{
    public class Session
    {
        public string Token { get; set; } = string.Empty;
        public string ExpiresIn { get; set; } = string.Empty;

        public Session(string token, string expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
