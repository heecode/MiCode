using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;
using MiCode.Core.Repository;

namespace MiCode.Persistence.Repositories
{
  public  class StudentRepository : Repository<Student>, IStudentRepository
  {
        private readonly RepositoryContext _context;
        public StudentRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudentByMonthOfBirth(int month)
        {
            return _context.Students.Where(x => x.DateOfBirth.Value.Month == month);
        }
    }
}
