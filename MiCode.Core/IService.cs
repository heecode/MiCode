using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCode.Core
{
  public  interface IService<TEntity> where TEntity : class
  {
      IEnumerable<TEntity> GetAll();
      void Save(TEntity entity);
      void Save(IEnumerable<TEntity> entities);
      TEntity GetById(int id);
      IEnumerable<TEntity> GetByIds(IEnumerable<int> ids);
      void Delete(TEntity entity);
      void Delete(IEnumerable<TEntity> entities);
      void Delete(int id);
      void Delete(IEnumerable<int> ids);




  }
}
