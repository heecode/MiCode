﻿using System;
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
            using (var unitOfWork = new UnitOfWork<RepositoryContext>())
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var studentName = "Heemi" + timeStamp;
                var standard = new Standard { Name = standardName };
                var standardRepo = unitOfWork.GetRepository<Standard>();
                standardRepo.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = standardRepo.GetAll().Where(x => x.Name == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);

                var student = new Student
                {
                    DateOfBirth = DateTime.Now,
                    Height = 123,
                    Standard = ableToGetMelur,
                    Name = studentName
                };
                var studentRepo = unitOfWork.GetRepository<Student>();
                studentRepo.Add(student);
                unitOfWork.Complete();
                var ableToGetHeemi = studentRepo.GetAll().Where(x => x.Name == studentName).FirstOrDefault();
                Assert.IsNotNull(ableToGetHeemi);

            }
        }

        [TestMethod]
        public void AbleToGetGeneralRepoStudent()
        {
            using (var unitOfWork = new UnitOfWork<RepositoryContext>())
            {
                var timeStamp = DateTime.Now.Ticks.ToString();
                var standardName = "Melur" + timeStamp;
                var studentName = "Heemi" + timeStamp;
                var standard = new Standard { Name = standardName };
                var standardRepo = unitOfWork.GetRepository<Standard>();
                standardRepo.Add(standard);
                //unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
                var ableToGetMelur = standardRepo.GetAll().Where(x => x.Name == standardName).FirstOrDefault();
                Assert.IsNotNull(ableToGetMelur);

                var student = new Student
                {
                    DateOfBirth = DateTime.Now,
                    Height = 123,
                    Standard = ableToGetMelur,
                    Name = studentName
                };
                var studentRepo = unitOfWork.GetRepository<Student>();
                studentRepo.Add(student);
                unitOfWork.Complete();
                var ableToGetHeemi = studentRepo.GetAll().Where(x => x.Name == studentName).FirstOrDefault();
                Assert.IsNotNull(ableToGetHeemi);
                studentRepo.Remove(ableToGetHeemi);

                standardRepo.Remove(ableToGetMelur);
                unitOfWork.Complete();
                ableToGetHeemi = studentRepo.GetAll().Where(x => x.Name == studentName).FirstOrDefault();
                ableToGetMelur = standardRepo.GetAll().Where(x => x.Name == standardName).FirstOrDefault();
                Assert.IsNull(ableToGetHeemi);
                Assert.IsNull(ableToGetMelur);


            }
        }
    }
}
