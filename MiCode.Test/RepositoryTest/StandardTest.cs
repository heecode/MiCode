using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.Core.Repository;
using MiCode.Persistence;

namespace MiCode.Test.RepositoryTest
{
    [TestClass]
    public class StandardTest
    {
        [TestMethod]
        public void AbleToSaveStandard()
        {
            using (var unitOfWork = new UnitOfWork(new RepositoryContext()))
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var standard = new Standard {StandardName = standardName };
                unitOfWork.Standards.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = unitOfWork.Standards.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);
            }

        }

        [TestMethod]
        public void AbleToSaveStandardUsingGenericIoW()
        {
            using (var unitOfWork = new UnitOfWork(new RepositoryContext()))
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var standard = new Standard { StandardName = standardName };
                var standardRepo = unitOfWork.GetRepository<Standard>();
               // standardRepo.
                standardRepo.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = unitOfWork.Standards.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);
            }

         //   IUnitOfWork _uow;

         //IRepository<Student> _Student;


    }
}
}
