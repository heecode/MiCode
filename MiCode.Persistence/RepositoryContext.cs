using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;

namespace MiCode.Persistence
{
  
        public class RepositoryContext : DbContext
        {
            public RepositoryContext() : base("name=DBConnectionString")
            {

            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Standard> Standards { get; set; }
        }
    
}
