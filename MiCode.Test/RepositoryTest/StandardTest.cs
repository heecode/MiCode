using System;
using System.Configuration;
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
            using (var unitOfWork = new UnitOfWork<RepositoryContext>())
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
            using (var unitOfWork = new UnitOfWork<RepositoryContext>())
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
                var newStandardName = "Melati" + timeStamp;
                Assert.IsNotNull(ableToGetMelur);
                var id = ableToGetMelur.Id;
                ableToGetMelur.StandardName = newStandardName;
                standardRepo.Update(ableToGetMelur);
                unitOfWork.Complete();
                ableToGetMelur = unitOfWork.Standards.Get(id);
                Assert.AreEqual(ableToGetMelur.StandardName,newStandardName);
                standardRepo.Remove(ableToGetMelur);
                unitOfWork.Complete();
                ableToGetMelur = unitOfWork.Standards.Get(id);
                Assert.IsNull(ableToGetMelur);
            }

         //   IUnitOfWork _uow;

         //IRepository<Student> _Student;


    }
}
}
