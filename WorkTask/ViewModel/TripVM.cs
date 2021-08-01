using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WorkTask.Model;

namespace WorkTask.ViewModel
{
    public class TripVM
    {
        public string Name { get; set; }
        public string CityName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
      
    }
}
