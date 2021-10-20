using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Readz.Auth.Models
{
    public class Registration
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string ImageLocation { get; set; }

        [Required]
        public string Password { get; set; }
 
        [Required]
        //Model is only valid if Password and ConfirmPassword are the same
        //Our ModelState in the Register function in the AccountController
        //will return NotValid if they are not the same.
        [Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
