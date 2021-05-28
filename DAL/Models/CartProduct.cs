using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("CartProduct")]
    public class CartProduct
    {
            public int ID { get; set; }

            [ForeignKey("product")]
            public int productId { get; set; }
            public Product product { get; set; }
            public int quintity { get; set; } = 1;

            [ForeignKey("cart")]
            public string CartID { get; set; }
            public Cart cart { get; set; }
        }
 }

