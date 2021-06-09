using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
   public class CartProductViewModel
    {
        public int ID { get; set; }
        public  int productId { get; set; }
        public string CartID { get; set; }
        public double NetPrice { get; set; }
        public int quintity { get; set; } 


    }
}
