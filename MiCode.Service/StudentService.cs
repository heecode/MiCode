using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core;
using MiCode.Core.Domain;

namespace MiCode.Service
{
    public class StudentService:BaseService<Student>
    {
        public StudentService(IUnitOfWork uow) : base(uow)
        {
        }

        public Student GetByName(string name)
        {
            return GetAll().SingleOrDefault(x => x.StudentName == name);
        }
    }
}
