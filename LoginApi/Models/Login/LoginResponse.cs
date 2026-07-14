namespace LoginApi.Models.Response
{
    public class LoginResponse
    {

        public string StatusCode { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

    }
}