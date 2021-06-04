using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
   public class OrderDetailsViewModel
    {
        public int ID { get; set; }

        public int Quantity { get; set; }
       
        public int ProductID { get; set; }
         
        public int OrderID { get; set; }
    }
}
