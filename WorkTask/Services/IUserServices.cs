using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTask.Services
{
    public interface IUserServices
    {
        bool ValidateCredentials(string username, string password);
    }
}
