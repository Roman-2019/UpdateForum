using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);
        void Remove(int id);
        void Update(T model);
        T GetById(int id);
        IEnumerable<T> GetAll();

    }
}
