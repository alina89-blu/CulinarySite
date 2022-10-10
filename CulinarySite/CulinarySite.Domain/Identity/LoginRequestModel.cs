using System.ComponentModel.DataAnnotations;

namespace CulinarySite.Domain.Identity
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; set; }      
        [Required]
        public string Password { get; set; }
    }
}
