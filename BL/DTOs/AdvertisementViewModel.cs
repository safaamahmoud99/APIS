using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class AdvertisementViewModel
    {
        public int ID { set; get; }
        public string Image { get; set; }
       
        public DateTime StartDate { get; set; }
      
        public DateTime EndDate { get; set; }
    }
}
