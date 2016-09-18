using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCode.Core.Domain
{
  public  class School: BaseEntity
    {
        public ICollection<Standard> Standards { get; set; }
    }
}
