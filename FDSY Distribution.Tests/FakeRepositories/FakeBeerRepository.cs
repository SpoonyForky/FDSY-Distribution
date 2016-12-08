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
        private List<Beer> repo;

        public FakeBeerRepository()
        {
            repo = new List<Beer>();
        }
        public void Delete(int? id)
        {
            repo.Remove(repo.Where(z => z.BeerId == id).First());
        }

        public ICollection<Beer> Get()
        {
            return repo;
        }

        public Beer Get(int? id)
        {
            return repo.Where(b => b.BeerId == id).First();
        }

        public void Post(Beer _beer)
        {
            repo.Add(_beer);
        }

        public void Put(Beer _beer)
        {
            int index = repo.IndexOf(repo.Where(b => b.BeerId == _beer.BeerId).First());
            repo[index] = _beer;
        }
    }
}
