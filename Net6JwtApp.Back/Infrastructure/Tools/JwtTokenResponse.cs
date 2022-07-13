namespace Net6JwtApp.Back.Infrastructure.Tools
{
    public class JwtTokenResponse
    {
        public JwtTokenResponse(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
