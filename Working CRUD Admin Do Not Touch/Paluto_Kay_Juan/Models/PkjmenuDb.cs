using System;
using System.Collections.Generic;

namespace Paluto_Kay_Juan.Models
{
    public partial class PkjmenuDb
    {
        public int Id { get; set; }
        public string FoodName { get; set; } = null!;
        public string FoodCategory { get; set; } = null!;
        public int QtyPerOrder { get; set; }
        public decimal PricePerOrder { get; set; }
        public string ImageLocation { get; set; } = null!;
    }
}
