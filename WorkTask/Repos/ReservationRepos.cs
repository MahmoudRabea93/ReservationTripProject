using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkTask.Model;


namespace WorkTask.Repos
{
    public class ReservationRepos : IRepos<Reservation>
    {
       private DataBaseContext DB;

        public ReservationRepos()
        {
            DB = new DataBaseContext();
        }
        public void Create(Reservation NewReservation)
        {
            DB.Reservations.Add(NewReservation);
            DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var DeletedTrip = DB.Reservations.Where(a => a.ID == Id).FirstOrDefault();
            DB.Reservations.Remove(DeletedTrip);
            DB.SaveChanges();
        }

        public IList<Reservation> GetAll()
        {
            var ReservationList = DB.Reservations.ToList();
            return ReservationList;
        }
        public Reservation GetById(int id)
        {
            return DB.Reservations.Where(a => a.ID == id).FirstOrDefault();
        }

        public void Modfiy(int Id, Reservation ModfiyReservation)
        {
          
            var OldReservation = DB.Reservations.Where(a => a.ID == Id).FirstOrDefault();
            OldReservation.CreationDate = DateTime.Now;
            OldReservation.TripID = ModfiyReservation.TripID;
            OldReservation.ReservationDate = ModfiyReservation.ReservationDate;
            OldReservation.ReservedBy = ModfiyReservation.ReservedBy;
            OldReservation.Notes = ModfiyReservation.Notes;
            OldReservation.CustomerName = ModfiyReservation.CustomerName;
            DB.SaveChanges();
        }
    }
}
