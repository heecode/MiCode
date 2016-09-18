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
                        Name = "John Doe",
                        
                    },
                    new Student
                    {
                        Id = 2,
                        Name = "Victor Sagev",
                    },
                    new Student
                    {
                        Id = 3,
                        Name = "Wayne Johnson",
                    }
                };
            }
        }

        public List<School> School
        {
            get
            {
                return new List<School>
                {
                    new School
                    {
                        Id = 1,
                        Name = "SMK1",
                    },
                    new School
                    {
                        Id = 2,
                        Name = "SMK2",
                    },
                    new School
                    {
                        Id = 3,
                        Name = "SMK3",
                    }
                };
            }
        }


    }
}

