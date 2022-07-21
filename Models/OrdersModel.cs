using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Paluto_Kay_Juan.Models
{
    public class OrdersModel
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "Invalid Name! Maximum of 100 Characters Only!")]
        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "The Contact Number field is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Invalid Contact Number!")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Contact Number")]
        public string CustomerContact { get; set; }

        [DisplayName("Status")]
        public string PaymentStatus { get; set; } = "Pending";

        [Required(ErrorMessage = "The Main Dish Orders field is required.")]
        [StringLength(99999)]
        public string MainDishOrder { get; set; }

        [Required(ErrorMessage = "The Appetizers Orders field is required.")]
        [StringLength(99999)]
        public string AppetizersOrder { get; set; }

        [Required(ErrorMessage = "The Desserts Orders field is required.")]
        [StringLength(99999)]
        public string DessertOrder { get; set; }

        [Required(ErrorMessage = "The Drinks Orders field is required.")]
        [StringLength(99999)]
        public string DrinksOrder { get; set; }

        [Required(ErrorMessage = "The Venue Location field is required.")]
        [StringLength(100, ErrorMessage = "Invalid Input!")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Venue Location")]
        public string VenueLocation { get; set; } = "PKJ Facility";

        [Required(ErrorMessage = "The Date field is required.")]
        [StringLength(50, ErrorMessage = "Invalid Input!")]
        [DisplayName("Catering Date")]
        public string CateringDate { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Total! Maximum of 2 Decimal Points.")]
        [DisplayName("Total")]
        public decimal Total { get; set; } = 0;

        [StringLength(100)]
        [DisplayName("Date Ordered")]
        public string OrderDate { get; set; } = DateTime.Now.ToString("MM-dd-yyyy");
    }
}
