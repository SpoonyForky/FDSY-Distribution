using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSY_Distribution.Models
{
    public interface IRepository<T>
    {

        ICollection<T> Get();

        T Get(int? id);

        void Post(T model);

        void Put(T model);

        void Delete(int? id);



    }
}