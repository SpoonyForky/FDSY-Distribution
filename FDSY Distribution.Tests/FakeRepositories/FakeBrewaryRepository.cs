using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDSY_Distribution.Models;
using FDSY_Distribution.Models.Repositories;

namespace FDSY_Distribution.Tests.FakeRepositories
{
    public class FakeBrewaryRepository : IRepository<Brewery>
    {
        private List<Brewery> brew;

        public FakeBrewaryRepository()
        {
            brew = new List<Brewery>();
        }


        public void Delete(int? id)
        {
            Brewery cheers = brew.Where(g => g.BreweryId == id).First();
            brew.Remove(cheers);
        }

        public ICollection<Brewery> Get()
        {
            return brew;
        }

        public Brewery Get(int? id)
        {
            return new Brewery() { BreweryId = (int)id };
        }

        public void Post(Brewery model)
        {
            brew.Add(model);
        }

        public void Put(Brewery model)
        {
            brew.Where(d => d.BreweryId == model.BreweryId).First().Name = "Molson";
        }
    }
}
