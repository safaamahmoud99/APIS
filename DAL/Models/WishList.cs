using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("WishList")]
    public class WishList
    {
        [ForeignKey("user"), Key]
        public string UserID { get; set; }
        public virtual User user { get; set; }
        public ICollection<WishListProduct> wishListProducts { get; set; }
    }
}
