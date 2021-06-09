using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class AdvertisementViewModel
    {
        public int ID { get; set; }

        public string Image { get; set; }
       
        public string StartDate { get; set; }
      
        public string EndDate { get; set; }
    }
}
