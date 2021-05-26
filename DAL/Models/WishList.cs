using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("WishList")]
    public class WishList
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        public ICollection<WishListProduct> wishListProducts { get; set; }
    }
}
