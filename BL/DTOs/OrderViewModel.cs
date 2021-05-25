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

        [Display(Name = "Date")]
        public string date { get; set; }



        [Display(Name = "Total Price")]
        public double totalPrice { get; set; }
        public string User_Id { get; set; }
    }    
}
