using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid price")]
        public double Price { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        //public string MainImage { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity Must be more than 1")]
        public int Quantity { get; set; }
       
        public int SubCategoryID { get; set; }
        public int BrandID { get; set; }
        public int SupplierID { get; set; }
        public double? AverageRating { get; set; }
    }
}
