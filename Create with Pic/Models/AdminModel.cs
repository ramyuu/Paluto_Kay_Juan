using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Paluto_Kay_Juan.Models
{
    public class AdminModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DishName { get; set; }

        [Required]
        [StringLength(50)]
        public string DishCategory { get; set; }

        [Required]
        public int AmtPerOrder { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string FoodImgUrl { get; set; }

        [NotMapped]
        public IFormFile UploadedImage { get; set; }

    }
}
