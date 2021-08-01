using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Mapper;
using WorkTask.Model;
using WorkTask.Repos;
using WorkTask.ViewModel;

namespace WorkTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private DataBaseContext DB =new DataBaseContext();
        private List<Reservation> ReservationList=new List<Reservation>();
        private IRepos<Trip> TripRep;
        private IMapper mapper;    
        public TripController(IRepos<Trip> _TripRep, IMapper _mapper)
        {
            this.TripRep = _TripRep;
            this.mapper = _mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var TripList = TripRep.GetAll();
            List<TripDTO> Data = mapper.Map<List<TripDTO>>(TripList);
            return Ok(Data);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var TripByID = TripRep.GetById(id);
            TripDTO Data = mapper.Map<TripDTO>(TripByID);
            return Ok(Data);
        }
        #region Commented
        //[HttpGet("{id}")]
        //public TripVM Get(int id)
        //{

        //    var TripDetails = DB.Trips.Where(T => T.ID == id).FirstOrDefault();
        //    var ReservationDetails = DB.Reservations.Where(T => T.TripID == id).ToList();
        //    TripVM TripReservation = new TripVM();

        //    //TripReservation.TripName = TripDetails.Name;
        //    TripReservation.CityName = TripDetails.CityName;
        //    //TripReservation.TripCreationDate = TripDetails.CreationDate;
        //    TripReservation.Content = TripDetails.Content;
        //    TripReservation.ImageUrl = TripDetails.ImageUrl;
        //    TripReservation.Price = TripDetails.Price;

        //    foreach (var item in ReservationDetails)
        //    {
        //        TripReservation.Reservations.Add(item);
        //    }
        //    //TripReservation.Reservations = ReservationList;
        //    return TripReservation;
        //}
        #endregion


        [HttpPost]
        public ActionResult Post(TripVM trip)
        {
            Trip newTrip = new Trip
            {
                CityName = trip.CityName,
                Content = trip.Content,
                CreationDate = DateTime.Now,
                ImageUrl = trip.ImageUrl,
                Name = trip.Name,
                Price = trip.Price,

            };
            TripRep.Create(newTrip);
            return CreatedAtAction("Get", new { id = newTrip.ID }, TripRep.GetAll());
        }

        // PUT api/<Trip>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, TripVM trip)
        {
            Trip newTrip = new Trip
            {
                CityName = trip.CityName,
                Content = trip.Content,
                CreationDate = DateTime.Now,
                ImageUrl = trip.ImageUrl,
                Name = trip.Name,
                Price = trip.Price,

            };
            TripRep.Modfiy(id, newTrip);
            return Ok(TripRep.GetAll());
        }

        // DELETE api/<Trip>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            TripRep.Delete(id);
            return Ok(TripRep.GetAll());
        }
    }
}
