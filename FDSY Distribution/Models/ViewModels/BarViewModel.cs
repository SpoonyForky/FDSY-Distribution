using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSY_Distribution.Models.ViewModels
{
    public class BarViewModel
    {

        public int StoredID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int UnitsOrdered { get; set; }

        public List<int> BeersId { get; set; }
        public List<int> SalesOrderId { get; set; }

    }
}