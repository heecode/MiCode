using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiCode.Core.Domain;
using MiCode.Core.Repository;
using MiCode.Persistence;
using MiCode.Persistence.Repositories;

namespace MiCode.Test.RepositoryTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void AbleToSaveStudent()
        {
            using (var unitOfWork = new UnitOfWork(new RepositoryContext()))
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var studentName = "Heemi" + timeStamp;
                var standard = new Standard { StandardName = standardName };
                unitOfWork.Standards.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = unitOfWork.Standards.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);

                var student = new Student
                {
                    DateOfBirth = DateTime.Now,
                    Height = 123,
                    Standard = ableToGetMelur,
                    StudentName = studentName
                };
                unitOfWork.Students.Add(student);
                unitOfWork.Complete();
                var ableToGetHeemi = unitOfWork.Students.GetAll().Where(x => x.StudentName == studentName).FirstOrDefault();
                Assert.IsNotNull(ableToGetHeemi);

            }
        }

        [TestMethod]
        public void AbleToGetGeneralRepoStudent()
        {
            using (var unitOfWork = new UnitOfWork(new RepositoryContext()))
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var studentName = "Heemi" + timeStamp;
                var standard = new Standard { StandardName = standardName };
                unitOfWork.Standards.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = unitOfWork.Standards.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);

                var student = new Student
                {
                    DateOfBirth = DateTime.Now,
                    Height = 123,
                    Standard = ableToGetMelur,
                    StudentName = studentName
                };
                var studentRepo = unitOfWork.Repository<StudentRepository, IStudentRepository>();
                studentRepo.Add(student);
                unitOfWork.Complete();
                var ableToGetHeemi = studentRepo.GetAll().Where(x => x.StudentName == studentName).FirstOrDefault();
                Assert.IsNotNull(ableToGetHeemi);
                studentRepo.Remove(ableToGetHeemi);
                
                unitOfWork.Standards.Remove(ableToGetMelur);
                unitOfWork.Complete();
                ableToGetHeemi = studentRepo.GetAll().Where(x => x.StudentName == studentName).FirstOrDefault();
                ableToGetMelur = unitOfWork.Standards.GetAll().Where(x => x.StandardName == standardName).FirstOrDefault();
                Assert.IsNull(ableToGetHeemi);
                Assert.IsNull(ableToGetMelur);


            }
        }
    }
}
