using System;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.DependencyInjector;

namespace MiCode.Test.RepositoryTest
{
    [TestClass]
    public class SchoolTest
    {
        private readonly UnityContainer _uc = MiCodeUnity.Instance;
        [TestMethod]
        public void AddedSchoolWithUnity()
        {
            using (var unitOfWork = _uc.Resolve<IUnitOfWork>())
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var schoolName = "Sekolah" + timeStamp;
                var school = new School() { Name = schoolName };
                var repo = unitOfWork.GetRepository<School>();
                repo.Add(school);
                unitOfWork.Complete();
                var ableToGetMelur = repo.GetAll().Where(x => x.Name == schoolName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);
            }
        }
    }
}
