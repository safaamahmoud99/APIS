using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set;}
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public int SubCategoryID { get; set; }
        [ForeignKey("SubCategoryID")]
        public virtual SubCategory subCategory { get; set; }
        [NotMapped]
        public double? AverageRating
        {
            get
            {
                if (Reviews.Count != 0)
                    return Reviews.Select(r => r.Rating).Average();
                return null;
            }
        }
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brands Brands { get; set; }
        public List<Offer> Offers {get;set;}
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<CartProduct> Carts { get; set; } = new List<CartProduct>();
        public List<WishListProduct> Wishlists { get; set; } = new List<WishListProduct>();
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
