using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
  public   class ReviewViewModel
    {
        public string Comment { get; set; }
    
        public int Rating { get; set; }

        public int ProductID { get; set; }
       
        public string UserID { get; set; }
       
    }
}
