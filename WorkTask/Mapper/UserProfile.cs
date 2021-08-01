using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Model;
using WorkTask.ViewModel;

namespace WorkTask.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationVM, ReservationDTO>();
            CreateMap<TripReservationVM, ReservationTripDTO>();
            CreateMap<Trip, TripDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
