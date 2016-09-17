using System;
using System.Configuration;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.Core.Repository;
using MiCode.DependencyInjector;
using MiCode.Persistence;

namespace MiCode.Test.RepositoryTest
{
    [TestClass]
    public class StandardTest
    {
        private readonly UnityContainer _uc = MiCodeUnity.Instance;
        [TestMethod]
        public void AbleToSaveStandard()
        {
            using (var unitOfWork = new UnitOfWork<RepositoryContext>())
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var standard = new Standard {StandardName = standardName };
                var standardRepo = unitOfWork.GetRepository<Standard>();
                standardRepo.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = standardRepo.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);
            }

        }

        [TestMethod]
        public void AbleToSaveStandardUsingUnity()
        {

            var unitOfWork = _uc.Resolve<IUnitOfWork>();
            var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var standard = new Standard { StandardName = standardName };
                var standardRepo = unitOfWork.GetRepository<Standard>();
                standardRepo.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = standardRepo.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);
            unitOfWork.Dispose();



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
                var ableToGetMelur = standardRepo.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                var newStandardName = "Melati" + timeStamp;
                Assert.IsNotNull(ableToGetMelur);
                var id = ableToGetMelur.Id;
                ableToGetMelur.StandardName = newStandardName;
                standardRepo.Update(ableToGetMelur);
                unitOfWork.Complete();
                ableToGetMelur = standardRepo.Get(id);
                Assert.AreEqual(ableToGetMelur.StandardName,newStandardName);
                standardRepo.Remove(ableToGetMelur);
                unitOfWork.Complete();
                ableToGetMelur = standardRepo.Get(id);
                Assert.IsNull(ableToGetMelur);
            }

         //   IUnitOfWork _uow;

         //IRepository<Student> _Student;


    }
}
}
