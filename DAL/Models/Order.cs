using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Order")]
    public class Order
    {
            public Order()
            {
                //OrderDetails = new List<OrderDetails>();
            }
            public int ID { get; set; }
            //[ForeignKey("User")]
            public string UserID { get; set; }
            [Column(TypeName = "date")]
            public DateTime OrderDate { get; set; }
            public double TotalPrice { get; set; }
            public double CouponDiscount { get; set; }
            [NotMapped]
            public double? NetPrice
            {
                get { return TotalPrice - CouponDiscount; }
                private set { }
            }
            public int ItemsCount { get; set; }

            //public virtual User User { get; set; }
            //public virtual ICollection<OrderDetails> OrderDetails { get; private set; }
        }
    }

