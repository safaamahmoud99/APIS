using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Golbalization;

namespace BL.DTOs
{
   public class OfferViewModel
    {
        public int ID { get; set; }
        [required]
        public DateTime StartDate { get;set;}
        [required]
        public DateTime EndDate {get;set;}
        public double OfferValue { get; set; }
    }
}
