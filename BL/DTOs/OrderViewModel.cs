using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class OrderViewModel
    {
        public int Id { get; set; } 
        [Required]
        public DateTime Orderdate { get; set; }
        [Required]
        public double totalPrice { get; set; }
        public double CouponDiscount { get; set; }
        public string UserID { get; set; }
    }    
}
