using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorkTask.Model
{
    public class Trip
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
