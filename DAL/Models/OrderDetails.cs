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
            public int ProductID { get; set; }           
            public int  OrderID { get; set; }
        }
 }
