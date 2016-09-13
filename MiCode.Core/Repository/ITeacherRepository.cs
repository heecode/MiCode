using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;

namespace MiCode.Core.Repository
{
   public interface ITeacherRepository : IRepository<Teacher> , IBaseRepo
    {
    }
}
