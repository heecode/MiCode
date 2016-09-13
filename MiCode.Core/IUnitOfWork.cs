using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;
using MiCode.Core.Repository;

namespace MiCode.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

         TEntity Repository<TEntity>() where TEntity : IBaseRepo;
 
        //IStudentRepository Repository<T>() where T : Student;
        // ITeacherRepository Repository<Student>();
        //IStudentRepository Repository();
         IStudentRepository Students { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Standard> Standards { get; }
        int Complete();
    }
}
