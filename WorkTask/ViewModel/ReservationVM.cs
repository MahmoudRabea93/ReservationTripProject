using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTask.ViewModel
{
    public class ReservationVM
    {
        
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }  
        public string Notes { get; set; }
        public int TripID { get; set; }
    }
}
