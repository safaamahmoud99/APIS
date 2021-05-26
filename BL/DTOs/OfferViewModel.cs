using System;
using System.ComponentModel.DataAnnotations;

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
