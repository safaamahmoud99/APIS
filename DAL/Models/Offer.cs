using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Offer
    {
        public int ID { get; set; }
        public DateTime StartDate { get;set;}
        public DateTime EndDate {get;set;}
        public double OfferValue { get; set; }

    }
}
