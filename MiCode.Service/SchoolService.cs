using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core;
using MiCode.Core.Domain;

namespace MiCode.Service
{
  public  class SchoolService : BaseService<School>
    {
        public SchoolService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
