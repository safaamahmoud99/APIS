using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
   public class OfferViewModel
    {
        public int ID { get; set; }
        [Required]
        public DateTime StartDate { get;set;}
        [Required]
        public DateTime EndDate {get;set;}
        public double OfferValue { get; set; }
    }
}
