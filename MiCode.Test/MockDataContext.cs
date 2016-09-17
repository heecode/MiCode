using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;

namespace MiCode.Test
{
    public class MockDataContext
    {
        public List<Student> Student
        {
            get
            {
                return new List<Student>
                {
                    new Student
                    {
                        Id = 1,
                        StudentName = "John Doe",
                    },
                    new Student
                    {
                        Id = 2,
                        StudentName = "Victor Sagev",
                    },
                    new Student
                    {
                        Id = 3,
                        StudentName = "Wayne Johnson",
                    }
                };
            }
        }
    }
}

