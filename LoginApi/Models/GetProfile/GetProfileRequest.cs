using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models.GetProfileRequest
{
    public class GetProfileRequest
    {
        [Required(ErrorMessage = "User id is required.")]
        public int UserId { get; set; } = 0;

        
    }
}