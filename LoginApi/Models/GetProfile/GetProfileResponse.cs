namespace LoginApi.Models.GetProfile
{
    public class GetProfileResponse
    {

        public string StatusCode { get; set; } = string.Empty;

        public string StatusText { get; set; } = string.Empty;
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        
    }
}