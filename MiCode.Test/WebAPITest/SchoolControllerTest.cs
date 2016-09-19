using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiCode.Core;
using MiCode.Service;
using MiCode.Web.Api.Controllers;
using MiCode.Web.Api.Models;

namespace MiCode.Test.WebAPITest
{
    [TestClass]
    public class SchoolControllerTest
    {
        IUnitOfWork _uow;
        private readonly UnityContainer _uc = MockDependencyInjector.Instance;

        [TestInitialize]
        public void SetUp()
        {
            
            _uow = _uc.Resolve<IUnitOfWork>();
            
        }

        [TestMethod]
        public void AbleToGetSmk1()
        {
            var controller = new SchoolsController(_uow)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

           
            var response = controller.Get(1);

            
            Assert.AreEqual("SMK1", response.Name);
        }

        [TestMethod]
        public void AbleToSaveSmk4()
        {
            var controller = new SchoolsController(_uow)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var schoolModel = new SchoolModel {Name = "SMK4"};
            controller.Post(schoolModel);

            var response = controller.Get();


            Assert.AreEqual(4, response.Count());
        }

        [TestMethod]
        public void AbleToUpdateSmk1ToSmk5()
        {
            var controller = new SchoolsController(_uow)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = controller.Get(1);
            response.Name = "SMK5";

            //var schoolModel = new SchoolModel { Name = "SMK4" };
            controller.Put(response);
            response = controller.Get(1);

            //response = controller.Get();


            Assert.AreEqual(response.Name, "SMK5");
        }
    }
}
