using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDSY_Distribution.Controllers;
using FDSY_Distribution.Models;
using System.Web.Mvc;
using FDSY_Distribution.Controllers.ApiControllers;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace FDSY_Distribution.Tests.Controllers
{
    [TestClass]
    public class Bars_UnitTest
    {
        [TestMethod]
        public void BarsController_AddAction()
        {
            BarsController controller = new BarsController(new FakeRepositories.FakeBarRepository());

            Bar bar = new Bar()
            {
                Name = "Monaghans",
                Address = "Oakville",
                StoreId = 1,
                UnitsOrdered = 5,
            };

            System.Web.Mvc.RedirectToRouteResult result = controller.Create(bar) as System.Web.Mvc.RedirectToRouteResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BarsController_GetOne()
        {
            BarsController controller = new BarsController(new FakeRepositories.FakeBarRepository());
            ViewResult result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BarsController_GetAll()
        {
            BarsController controller = new BarsController(new FakeRepositories.FakeBarRepository());
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BarsController_Delete()
        {
            BarsController controller = new BarsController(new FakeRepositories.FakeBarRepository());

            Bar bar = new Bar()
            {
                Name = "Cheers",
                Address = "Toronto",
                StoreId = 10,
                UnitsOrdered = 100,
            };

            System.Web.Mvc.RedirectToRouteResult result = controller.Create(bar) as System.Web.Mvc.RedirectToRouteResult;

            System.Web.Mvc.RedirectToRouteResult deleteResult = controller.DeleteConfirmed(10) as System.Web.Mvc.RedirectToRouteResult;

            System.Web.Mvc.RedirectToRouteResult model = controller.Details(10) as System.Web.Mvc.RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(deleteResult);
            Assert.IsNull(model);

        }

        [TestMethod]
        public void BarsController_Edit()
        {
            BarsController controller = new BarsController(new FakeRepositories.FakeBarRepository());

            Bar bar = new Bar()
            {
                Name = "Cheers",
                Address = "Toronto",
                StoreId = 10,
                UnitsOrdered = 100,
            };

            System.Web.Mvc.RedirectToRouteResult result = controller.Create(bar) as System.Web.Mvc.RedirectToRouteResult;
            System.Web.Mvc.RedirectToRouteResult edit = controller.Edit(bar) as System.Web.Mvc.RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(edit);

        }

        [TestMethod]
        public void BarsApiController_AddAction()
        {
            BarsApiController controller = new BarsApiController(new FakeRepositories.FakeBarRepository());

            Bar bar = new Bar()
            {
                Name = "Kelsey's",
                Address = "Oakville",
                StoreId = 7,
                UnitsOrdered = 8,
            };

            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Bar> result = controller.PostBar(bar) as CreatedAtRouteNegotiatedContentResult<Bar>;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BarsApiController_GetOne()
        {
            BarsApiController controller = new BarsApiController(new FakeRepositories.FakeBarRepository());
            OkNegotiatedContentResult<Bar> result = controller.GetBar(10) as OkNegotiatedContentResult<Bar>;
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void BarsApiController_GetAll()
        {
            BarsApiController controller = new BarsApiController(new FakeRepositories.FakeBarRepository());
            var result = controller.GetBars() as List<Bar>;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BarsApiController_Delete()
        {
            BarsApiController controller = new BarsApiController(new FakeRepositories.FakeBarRepository());

            Bar bar = new Bar()
            {
                Name = "Cheers",
                Address = "Toronto",
                StoreId = 10,
                UnitsOrdered = 100,
            };

            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Bar> result = controller.PostBar(bar) as System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Bar>;

            OkNegotiatedContentResult<Bar> deleteResult = controller.DeleteBar(10) as OkNegotiatedContentResult<Bar>;
       
            Assert.IsNotNull(result);
            Assert.IsNotNull(deleteResult);
   
        }


        [TestMethod]
        public void BarsApiController_Edit()
        {
            BarsApiController controller = new BarsApiController(new FakeRepositories.FakeBarRepository());

            Bar bar = new Bar()
            {
                Name = "Cheers",
                Address = "Toronto",
                StoreId = 10,
                UnitsOrdered = 100,
            };

            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Bar> result = controller.PostBar(bar) as  System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Bar>;
            IHttpActionResult edit = controller.PutBar(10,bar) as IHttpActionResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(edit);

        }


    }
}
