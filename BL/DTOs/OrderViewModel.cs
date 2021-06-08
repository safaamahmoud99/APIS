using DAL.Models;
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
        public string OrderDate { get; set; }
        [Required]
        public double totalPrice { get; set; }
        public string UserID { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get;  set; }
    }    
}
