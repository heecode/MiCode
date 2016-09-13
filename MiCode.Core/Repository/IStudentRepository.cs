using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;

namespace MiCode.Core.Repository
{
  public  interface IStudentRepository : IRepository<Student>, IBaseRepo
    {
      IEnumerable<Student> GetStudentByMonthOfBirth(int month);
  }
}
