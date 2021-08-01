using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Model;

namespace WorkTask.Mapper
{
    public class ReservationDTO
    {
        public string ReservedBy { get; set; }
        public string CustomerName { get; set; }
      
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public int TripID { get; set; }

    }
}
