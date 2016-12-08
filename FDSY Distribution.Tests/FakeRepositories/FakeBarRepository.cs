using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDSY_Distribution.Models;

namespace FDSY_Distribution.Tests.FakeRepositories
{
    public class FakeBarRepository : IRepository<Bar>
    {
        private List<Bar> repo;

        public FakeBarRepository()
        {
            repo = new List<Bar>();
        }

        public void Delete(int? id)
        {
            repo.Remove(repo.Where(b => b.StoreId == id).First());
        }

        public ICollection<Bar> Get()
        {
            return repo;
        }

        public Bar Get(int? id)
        {
            return repo.Where(b => b.StoreId == id).First();
        }

        public void Post(Bar _bar)
        {
            repo.Add(_bar);
        }

        public void Put(Bar _bar)
        {
            int index = repo.IndexOf(repo.Where(b => b.StoreId == _bar.StoreId).First());
            repo[index] = _bar;
        }
    }
}
