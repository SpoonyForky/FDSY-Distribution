using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDSY_Distribution.Controllers;
using FDSY_Distribution.Models;
using System.Web.Mvc;
using FDSY_Distribution.Controllers.ApiControllers;
using System.Web.Http.Results;
using System.Web.Http;

namespace FDSY_Distribution.Tests.Controllers
{
    /// <summary>
    /// Summary description for Beer_UnitTest
    /// </summary>
    [TestClass]
    public class Beer_UnitTest
    {
     
        [TestMethod]
        public void BeerController_AddAction()
        {

            BeersController controller = new BeersController(new FakeRepositories.FakeBeerRepository());
            Beer beer = new Beer()
            {
                BeerId = 1,
                Name = "Blue Brew",
                Type = "Ale",
                UnitPrice = 69,
                ABV = 69
            };
            System.Web.Mvc.RedirectToRouteResult result = controller.Create(beer) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BeerController_DeleteAction()
        {
            BeersController controller = new BeersController(new FakeRepositories.FakeBeerRepository());

            Beer beer = new Beer()
            {

                BeerId = 1,
                Name = "BeeBrew",
                Type = "Ale",
                UnitPrice = 5,
                ABV = 4

            };
            System.Web.Mvc.RedirectToRouteResult createBeer = controller.Create(beer) as System.Web.Mvc.RedirectToRouteResult;
            System.Web.Mvc.RedirectToRouteResult delete = controller.DeleteConfirmed(1) as System.Web.Mvc.RedirectToRouteResult;
            System.Web.Mvc.RedirectToRouteResult result = controller.Details(1) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNull(result);

        }

        [TestMethod]
        public void BeerController_GetOne()
        {
            BeersController controller = new BeersController(new FakeRepositories.FakeBeerRepository());
            ViewResult result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);
        }
      
        [TestMethod]
        public void BeerController_GetAll()
        {
            BeersController controller = new BeersController(new FakeRepositories.FakeBeerRepository());
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void BeerController_Edit()
        {
            BeersController controller = new BeersController(new FakeRepositories.FakeBeerRepository());
            Beer beer = new Beer()
            {

                BeerId = 1,
                Name = "GreasyKev",
                Type = "Ale",
                UnitPrice = 1,
                ABV = 1

            };
            System.Web.Mvc.RedirectToRouteResult createBeer = controller.Create(beer) as System.Web.Mvc.RedirectToRouteResult;
            System.Web.Mvc.RedirectToRouteResult result = controller.Edit(beer) as System.Web.Mvc.RedirectToRouteResult;
            Assert.IsNotNull(createBeer);
            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void BeersApiController_AddAction()
        {

            BeersApiController controller = new BeersApiController(new FakeRepositories.FakeBeerRepository());
            Beer beer = new Beer()
            {
                BeerId = 1,
                Name = "Blue Brew",
                Type = "Ale",
                UnitPrice = 69,
                ABV = 69
            };
            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Beer> result = controller.PostBeer(beer) as CreatedAtRouteNegotiatedContentResult<Beer>;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void BeersApiController_DeleteAction()
        {
            BeersApiController controller = new BeersApiController(new FakeRepositories.FakeBeerRepository());

            Beer beer = new Beer()
            {

                BeerId = 1,
                Name = "BeeBrew",
                Type = "Ale",
                UnitPrice = 5,
                ABV = 4

            };
            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Beer> createBeer = controller.PostBeer(beer) as CreatedAtRouteNegotiatedContentResult<Beer>;
            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Beer> delete = controller.DeleteBeer(1) as CreatedAtRouteNegotiatedContentResult<Beer>;
            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Beer> result = controller.GetBeer(1) as CreatedAtRouteNegotiatedContentResult<Beer>;
            Assert.IsNotNull(createBeer);
            Assert.IsNull(result);

        }

        [TestMethod]
        public void BeersApiController_GetOne()
        {
            BeersApiController controller = new BeersApiController(new FakeRepositories.FakeBeerRepository());
            OkNegotiatedContentResult<Beer> result = controller.GetBeer(10) as OkNegotiatedContentResult<Beer>;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BeersApiController_GetAll()
        {
            BeersApiController controller = new BeersApiController(new FakeRepositories.FakeBeerRepository());
            var result = controller.GetBeers() as List<Beer>;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BeersApiController_Edit()
        {
            BeersApiController controller = new BeersApiController(new FakeRepositories.FakeBeerRepository());
            Beer beer = new Beer()
            {

                BeerId = 1,
                Name = "GreasyKev",
                Type = "Ale",
                UnitPrice = 1,
                ABV = 1

            };
            System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<Beer> createBeer = controller.PostBeer(beer) as CreatedAtRouteNegotiatedContentResult<Beer>;
            IHttpActionResult edit = controller.PutBeer(10, beer) as IHttpActionResult;

            Assert.IsNotNull(createBeer);
            Assert.IsNotNull(edit);


        }


    }
}
