using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Cart")]
    public class Cart
    {
        [ForeignKey("user"),Key]
        public string UserID { get; set; }
        public virtual User user { get; set; }
        public ICollection<CartProduct> cartProducts { get; set; }
    }
}
