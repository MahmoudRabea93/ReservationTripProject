using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTask.Repos
{
    public interface IRepos<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Create(T Obj);
        void Modfiy(int Id, T Obj);
        void Delete(int Id);
    }
}
