using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.Service;

namespace MiCode.Test.ServiceTest
{
    [TestClass]
    public class StudentServiceTest
    {
        IUnitOfWork _uow;
        StudentService _studentService;
        private readonly UnityContainer _uc = MockDependencyInjector.Instance;

        [TestInitialize]
        public void SetUp()
        {
            //_uow = new MockUnitOfWork<MockDataContext>();
            _uow = _uc.Resolve<IUnitOfWork>();
            _studentService = new StudentService(_uow);
        }

        [TestMethod]
        public void GetStudentJohnDoe()
        {
            var student = _studentService.GetById(1);
            Assert.AreEqual(student.StudentName, "John Doe");
        }

        [TestMethod]
        public void AbleToAddStudentNoraDanish()
        {
            var name = "Nora Danish";
            var student = new Student {Id = 0, StudentName = name};
            _studentService.Save(student);
            var studentNora = _studentService.GetByName(name);
            Assert.AreEqual(studentNora.StudentName, name);
        }
    }
}
