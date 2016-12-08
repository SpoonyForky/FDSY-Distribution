using FDSY_Distribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDSY_Distribution.Tests.FakeRepositories
{
    class FakeBeerRepository : IRepository<Beer>
    {
        private List<Beer> beers;

        public FakeBeerRepository()
        {
            beers = new List<Beer>();
        }
        public void Delete(int? id)
        {
            Beer cheersBeers = beers.Where(z => z.BeerId == id).First();
            beers.Remove(cheersBeers);
        }

        public ICollection<Beer> Get()
        {
            return beers;
        }

        public Beer Get(int? id)
        {
            return new Beer() { BeerId = (int)id };
            
        }

        public void Post(Beer model)
        {
            beers.Add(model);
        }

        public void Put(Beer model)
        {
            beers.Where(z => z.BeerId == model.BeerId).First().Name = "Blake Chugging Blue";
        }
    }
}
