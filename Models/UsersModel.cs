using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Paluto_Kay_Juan.Models
{
    public class UsersModel
    {
        [Key]
        public int userId { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        [StringLength(50, ErrorMessage = "Invalid Userame! Maximum of 50 Characters Only!")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Invalid Password! Must be between 8 and 16 Characters Only!")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Confirm Password field is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Invalid Password! Must be between 8 and 16 Characters Only!")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string CPassword { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [StringLength(50, ErrorMessage = "Invalid Email Address!")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Contact Number field is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Invalid Contact Number!")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Contact Number")]
        public string ContactNum { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        [StringLength(50, ErrorMessage = "Invalid Input! Maximum of 50 Characters Only!")]
        [DisplayName("First Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        [StringLength(50, ErrorMessage = "Invalid Input! Maximum of 50 Characters Only!")]
        [DisplayName("Last Name")]
        public string LName { get; set; }
        public string isAdmin { get; set; } = "No";
    }
}
