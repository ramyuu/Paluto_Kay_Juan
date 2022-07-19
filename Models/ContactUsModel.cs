using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Paluto_Kay_Juan.Models
{
    public class ContactUsModel
    {
        [Key]
        public int MsgID{ get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(75, ErrorMessage = "Invalid Name! Maximum of 75 Characters Only!")]
        [DisplayName("Full Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [StringLength(50, ErrorMessage = "Invalid Email Address!")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Message field is required.")]
        [StringLength(1000, ErrorMessage = "Max characters reached! Maximum of 1000 Characters Only!")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Message")]
        public string Message { get; set; } 
    }
}
