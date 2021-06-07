using System;
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
        [DataType(DataType.Date)]
        public DateTime StartDate { get;set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate {get;set;}
        public double OfferValue { get; set; }
    }
}
