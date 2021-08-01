using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorkTask.Model;
using WorkTask.Repos;
using WorkTask.Pagination;
using WorkTask.ViewModel;
using AutoMapper;
using WorkTask.Mapper;
using MediatR;
using WorkTask.Queries;

namespace WorkTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private DataBaseContext DB = new DataBaseContext();
        private IRepos<Reservation> ReservationRep;
        private IMapper mapper;
        public ReservationController(IRepos<Reservation> _ReservationRep, IMapper _mapper)
        {
            ReservationRep = _ReservationRep;
            mapper = _mapper;
         
        }
        [HttpGet]
        public ActionResult Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var AllData = ReservationRep.GetAll()
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToList();

            var totalRecords = ReservationRep.GetAll().Count();
            int TotalPage = 0;
            if (totalRecords % filter.PageSize == 0)
            {
                TotalPage = totalRecords / filter.PageSize;
            }
            else
            {
                TotalPage = (totalRecords / filter.PageSize) + 1;
            }
            List<ReservationDTO> Data = mapper.Map<List<ReservationDTO>>(AllData);
            return Ok(new PagedResponse<List<ReservationDTO>>(Data, validFilter.PageNumber, validFilter.PageSize, totalRecords, TotalPage));
        }


        [HttpGet("{ReservationID}")]
        public ReservationTripDTO Details(int ReservationID)
        {
            var ReservationDetails = DB.Reservations.Where(T => T.ID == ReservationID).FirstOrDefault();
            var TripDetails = DB.Trips.Where(T => T.ID == ReservationDetails.TripID).FirstOrDefault();

            TripReservationVM TripReservation = new TripReservationVM
            {
                TripName = TripDetails.Name,
                CityName = TripDetails.CityName,
                TripCreationDate = TripDetails.CreationDate,
                Content = TripDetails.Content,
                ImageUrl = TripDetails.ImageUrl,
                Price = TripDetails.Price,
                CustomerName = ReservationDetails.CustomerName,
                Notes = ReservationDetails.Notes,
                ReservationDate = ReservationDetails.ReservationDate,
                ReservedBy = ReservationDetails.ReservedBy
            };
            ReservationTripDTO Data = mapper.Map<ReservationTripDTO>(TripReservation);
            return Data;


        }

        [HttpPost]
        public ActionResult Post(ReservationVM Reservation)
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
            var username = credentials.FirstOrDefault();

            Reservation newReservation = new Reservation
            {
                CustomerName = Reservation.CustomerName,
                ReservedBy = username,
                CreationDate = DateTime.Now,
                Notes = Reservation.Notes,
                ReservationDate = Reservation.ReservationDate,
                TripID = Reservation.TripID,
            };
            ReservationRep.Create(newReservation);
            return CreatedAtAction("Get", new { id = newReservation.ID }, ReservationRep.GetAll());

        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, ReservationVM Reservation)
        {
            var found = ReservationRep.GetById(id);
            if (found != null)
            {
                Reservation newReservation = new Reservation
                {
                    CustomerName = Reservation.CustomerName,
                    CreationDate = DateTime.Now,
                    Notes = Reservation.Notes,
                    ReservationDate = Reservation.ReservationDate,
                    TripID = Reservation.TripID,

                };
                ReservationRep.Modfiy(id, newReservation);
                return Ok(ReservationRep.GetAll());
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var found = ReservationRep.GetById(id);
            if (found != null)
            {
                ReservationRep.Delete(id);
                return Ok(ReservationRep.GetAll());
            }
            else
            {
                return NotFound();
            }
        }
    }
}
