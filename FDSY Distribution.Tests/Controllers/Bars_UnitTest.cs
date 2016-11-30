using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDSY_Distribution.Controllers;
using FDSY_Distribution.Models;
using System.Web.Mvc;

namespace FDSY_Distribution.Tests.Controllers
{
    [TestClass]
    public class Bars_UnitTest
    {
        [TestMethod]
        public void BarsController_AddAction()
        {
            BarsController controller = new BarsController();
            Bar model = new Bar()
            {
               Name = "Monaghans",
               Address = "Oakville",
               StoreId = 1,
               UnitsOrdered = 5
            };

            ViewResult result = controller.Create() as ViewResult;

            Bar bar = result.Model as Bar;

          ///  Assert.IsNotNull(bar);

        }
    }
}
