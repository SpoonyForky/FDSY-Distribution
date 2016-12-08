using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDSY_Distribution.Models.Repositories;
using FDSY_Distribution.Models;
using FDSY_Distribution.Controllers;
using FDSY_Distribution.Controllers.ApiControllers;
using System.Web.Mvc;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Web.Http;

namespace FDSY_Distribution.Tests.Controllers
{
    [TestClass]
    public class Breweries_UnitTest
    {
        [TestMethod]
        public void BrewariesController_AddAction()
        {
            BreweriesController controller = new BreweriesController(new FakeRepositories.FakeBreweryRepository());

            Brewery brew = new Brewery()
            {
                Name = "Sleeman",
                Address = "Oakville",
                YTDSales = 500,
                BreweryId = 5
            };

            System.Web.Mvc.RedirectToRouteResult result = controller.Create(brew) as System.Web.Mvc.RedirectToRouteResult;

            Assert.IsNotNull(result);

        }



        [TestMethod]
        public void BreweriesController_GetOne()
        {
            BreweriesController controller = new BreweriesController(new FakeRepositories.FakeBreweryRepository());
            ViewResult result = controller.Details(5) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BreweriesController_GetAll()
        {
            BreweriesController controller = new BreweriesController(new FakeRepositories.FakeBreweryRepository());
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BreweriesController_Delete()
        {
            BreweriesController controller = new BreweriesController(new FakeRepositories.FakeBreweryRepository());

            Brewery brew = new Brewery()
            {
                Name = "Molson",
                Address = "Toronto",
                YTDSales = 5030,
                BreweryId = 1
            };

            System.Web.Mvc.RedirectToRouteResult result = controller.Create(brew) as System.Web.Mvc.RedirectToRouteResult;

            System.Web.Mvc.RedirectToRouteResult deleteResult = controller.DeleteConfirmed(1) as System.Web.Mvc.RedirectToRouteResult;

            System.Web.Mvc.RedirectToRouteResult model = controller.Details(1) as System.Web.Mvc.RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(deleteResult);
            Assert.IsNull(model);

        }

        [TestMethod]
        public void BreweriesController_Edit()
        {
            BreweriesController controller = new BreweriesController(new FakeRepositories.FakeBreweryRepository());

            Brewery brew = new Brewery()
            {
                Name = "Molson",
                Address = "Toronto",
                YTDSales = 5030,
                BreweryId = 1
            };

            System.Web.Mvc.RedirectToRouteResult result = controller.Create(brew) as System.Web.Mvc.RedirectToRouteResult;
            System.Web.Mvc.RedirectToRouteResult edit = controller.Edit(brew) as System.Web.Mvc.RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(edit);

        }


        [TestMethod]
        public void BreweriesApiController_GetOne()
        {
            BreweriesApiController controller = new BreweriesApiController(new FakeRepositories.FakeBreweryRepository());
            OkNegotiatedContentResult<Brewery> result = controller.GetBrewery(1) as OkNegotiatedContentResult<Brewery>;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BreweriesApiController_GetAll()
        {
            BreweriesApiController controller = new BreweriesApiController(new FakeRepositories.FakeBreweryRepository());
            var result = controller.GetBreweries() as List<Brewery>;
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void BrewariesApiController_Delete()
        {
            BreweriesApiController controller = new BreweriesApiController(new FakeRepositories.FakeBreweryRepository());

            Brewery brew = new Brewery()
            {
                Name = "Molson",
                Address = "Toronto",
                YTDSales = 5030,
                BreweryId = 7
            };
            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Brewery> result = controller.PostBrewery(brew) as System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Brewery>;

            OkNegotiatedContentResult<Brewery> deleteResult = controller.DeleteBrewery(7) as OkNegotiatedContentResult<Brewery>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(deleteResult);

        }

        [TestMethod]
        public void BreweriesApiController_Edit()
        {
            BreweriesApiController controller = new BreweriesApiController(new FakeRepositories.FakeBreweryRepository());

            Brewery brew = new Brewery()
            {
                Name = "Molson",
                Address = "Toronto",
                YTDSales = 5030,
                BreweryId = 7
            };
            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Brewery> result = controller.PostBrewery(brew) as System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Brewery>;
            IHttpActionResult edit = controller.PutBrewery(10, brew) as IHttpActionResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(edit);

        }


    }
}
