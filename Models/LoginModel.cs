using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Paluto_Kay_Juan.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        [StringLength(50, ErrorMessage = "Invalid Userame! Maximum of 50 Characters Only!")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(16, ErrorMessage = "Invalid Password! Maximum of 16 Characters Only!")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string isAdmin { get; set; }
    }
}
