using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCode.Core.Domain
{
    public class Standard:BaseEntity
    {
        public Standard()
        {

        }
        //public int StandardId { get; set; }
        public string StandardName { get; set; }


        public ICollection<Student> Students { get; set; }

    }


}
