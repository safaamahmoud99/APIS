using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Offer")]
    public class Offer
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get;set;}
        [DataType(DataType.Date)]
        public DateTime EndDate {get;set;}
        public double OfferValue { get; set; }
    }
}
