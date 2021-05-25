using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
            public int ID { get; set; }
            public int Quantity { get; set; } 
            [Column(TypeName = "date")]
            public DateTime OrderDate { get; set; }
            public double TotalPrice { get; set; }
            public double Discount { get; set; }
            [NotMapped]
            public double NetPrice
            {
                get { return TotalPrice - Discount; }
                private set { }
            }
            [ForeignKey("Product")]
            public int? ProductID { get; set; }
            [ForeignKey("Order")]
            public int? OrderID { get; set; }

            public virtual Product Product { get; set; }
            public virtual Order Order { get; set; }
        }
 }
