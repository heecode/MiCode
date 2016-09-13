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

        TIEntity Repository<TEntity, TIEntity>() where TEntity : IBaseRepo, TIEntity;
 
        //IStudentRepository Repository<T>() where T : Student;
        // ITeacherRepository Repository<Student>();
        //IStudentRepository Repository();
         IStudentRepository Students { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Standard> Standards { get; }
        int Complete();
    }
}
