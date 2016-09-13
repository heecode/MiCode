using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;
using MiCode.Core.Repository;

namespace MiCode.Persistence.Repositories
{
   public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(RepositoryContext context) : base(context)
        {
           // context = Context;
        }
    }
}
