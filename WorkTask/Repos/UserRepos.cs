using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Model;

namespace WorkTask.Repos
{
    public class UserRepos : IRepos<User>
    {
        DataBaseContext DB;
        public UserRepos()
        {
            DB = new DataBaseContext();
        }
        public void Create(User NewUser)
        {
            DB.Users.Add(NewUser);
            DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var DeletedUser =  DB.Users.Where(a => a.ID == Id).FirstOrDefault();
            DB.Users.Remove(DeletedUser);
        }

        public IList<User> GetAll()
        {
            var UsersList=DB.Users.ToList();
            return UsersList;
        }
        public User GetById(int id)
        {
            return DB.Users.Where(a => a.ID == id).FirstOrDefault();
        }

        public void Modfiy(int Id, User ModfiyUser)
        {
            var OldUser = DB.Users.Where(a => a.ID == Id).FirstOrDefault();
            OldUser.Email = ModfiyUser.Email;
            OldUser.PassWord = ModfiyUser.PassWord;
            DB.SaveChanges();
        }
    }
}
