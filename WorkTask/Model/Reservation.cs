using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTask.Model
{
    public class Reservation
    {
        public int ID { get; set; }
        public string ReservedBy { get; set; }
        public string CustomerName { get; set; }
        public Trip trip { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public int TripID { get; set; }
    }
}
