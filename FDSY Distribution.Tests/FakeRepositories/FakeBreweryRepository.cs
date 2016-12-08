using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDSY_Distribution.Models;
using FDSY_Distribution.Models.Repositories;

namespace FDSY_Distribution.Tests.FakeRepositories
{
    public class FakeBreweryRepository : IRepository<Brewery>
    {
        private List<Brewery> repo;

        public FakeBreweryRepository()
        {
            repo = new List<Brewery>();
        }


        public void Delete(int? id)
        {
            repo.Remove(repo.Where(g => g.BreweryId == id).First());
        }

        public ICollection<Brewery> Get()
        {
            return repo;
        }

        public Brewery Get(int? id)
        {
            return repo.Where(b => b.BreweryId == id).First();
        }

        public void Post(Brewery _brewery)
        {
            repo.Add(_brewery);
        }

        public void Put(Brewery _brewery)
        {
            int index = repo.IndexOf(repo.Where(b => b.BreweryId == _brewery.BreweryId).First());
            repo[index] = _brewery;
        }
    }
}
