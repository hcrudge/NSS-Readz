using System.ComponentModel.DataAnnotations;

namespace Readz.Auth.Models
{
    public class Credentials
    {
        [Required]
        //Type validation - some sort of regex to make sure its a valid email
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
