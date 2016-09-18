using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiCode.Core;
using MiCode.Service;

namespace MiCode.Test.ServiceTest
{
    [TestClass]
    public class SchoolServiceTest
    {
        IUnitOfWork _uow;
        SchoolService _schoolService;
        private readonly UnityContainer _uc = MockDependencyInjector.Instance;

        [TestInitialize]
        public void SetUp()
        {
            //_uow = new MockUnitOfWork<MockDataContext>();
            _uow = _uc.Resolve<IUnitOfWork>();
            _schoolService = new SchoolService(_uow);
        }

        [TestMethod]
        public void GetSchoolSMK1()
        {
            var student = _schoolService.GetById(1);
            Assert.AreEqual(student.Name, "SMK1");
        }
    }
}
