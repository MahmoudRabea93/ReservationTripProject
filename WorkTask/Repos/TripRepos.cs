using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Model;

namespace WorkTask.Repos
{
    public class TripRepos : IRepos<Trip>
    {
        DataBaseContext DB;
        public TripRepos()
        {
            DB = new DataBaseContext();
        }
        public void Create(Trip NewTrip)
        {
            DB.Trips.Add(NewTrip);
            DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var DeletedTrip = DB.Trips.Where(a => a.ID == Id).FirstOrDefault();
            DB.Trips.Remove(DeletedTrip);
            DB.SaveChanges();
        }

        public IList<Trip> GetAll()
        {
            var TripsList = DB.Trips.ToList();
            return TripsList;
        }
        public Trip GetById(int id)
        {
            return DB.Trips.Where(a => a.ID == id).FirstOrDefault();
        }

        public void Modfiy(int Id, Trip ModfiyTrip)
        {
            var OldTrip = DB.Trips.Where(a => a.ID == Id).FirstOrDefault();
            OldTrip.CityName = ModfiyTrip.CityName;
            OldTrip.Content = ModfiyTrip.Content;
            OldTrip.ImageUrl = ModfiyTrip.ImageUrl;
            OldTrip.Name = ModfiyTrip.Name;
            OldTrip.Price = ModfiyTrip.Price;
            DB.SaveChanges();
        }
    }
}
