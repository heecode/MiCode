using MiCode.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core;

namespace MiCode.Service
{
   public class StandardService : BaseService<Standard>
    {
        public StandardService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
