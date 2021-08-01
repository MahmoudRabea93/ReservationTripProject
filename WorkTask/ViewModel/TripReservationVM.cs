using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Model;

namespace WorkTask.ViewModel
{
    public class TripReservationVM
    {
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public string TripName { get; set; }
        public string CityName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime TripCreationDate { get; set; }
        public string ReservedBy { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
