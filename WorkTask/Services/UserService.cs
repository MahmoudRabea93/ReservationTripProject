using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Model;

namespace WorkTask.Services
{
    public class UserService : IUserServices
    {
        public bool ValidateCredentials(string Email, string password)
        {

            DataBaseContext DB = new DataBaseContext();
            var UserLogin = DB.Users.Where(a => a.Email == Email && a.PassWord == password).FirstOrDefault();
            if(UserLogin!=null)
            {
                return Email.Equals(UserLogin.Email) && password.Equals(UserLogin.PassWord);
            }
           else
           {
                return false;
           }
        }
    }
}
