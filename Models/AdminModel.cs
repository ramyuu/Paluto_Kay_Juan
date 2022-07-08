using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Paluto_Kay_Juan.Models
{
    public class AdminModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Dish Name field is required.")]
        [StringLength(50, ErrorMessage ="Invalid Name! Maximum of 50 Characters Only!")]
        [DisplayName("Name")]
        public string DishName { get; set; } = null!;

        [Required(ErrorMessage = "The Dish Category field is required.")]
        [StringLength(50)]
        [DisplayName("Category")]
        public string DishCategory { get; set; } = null!;

        [Required(ErrorMessage = "The Amount Per Order field is required.")]
        [Range(1,100, ErrorMessage ="Enter Values 1-100 Only!")]
        [DisplayName("Amount Per Order")]
        public int AmtPerOrder { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Price! Maximum of 2 Decimal Points.")]
        [Range(1,9999.99,ErrorMessage ="Enter Price Values 1-9999.99 Only!")]
        public decimal Price { get; set; }

        public string FoodImgUrl { get; set; } = null!;

        [NotMapped]
        [Required(ErrorMessage = "The Img field is required.")]
        public IFormFile UploadedImage { get; set; } = null!;

    }
}
