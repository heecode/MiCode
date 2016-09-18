using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCode.Core.Domain
{
    public class Student : BaseEntity
    {
        public Student()
        {

        }
       // public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public Teacher Teacher { get; set; }
        public Standard Standard { get; set; }
    }
}
