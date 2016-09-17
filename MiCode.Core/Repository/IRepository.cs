using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MiCode.Core.Domain;


namespace MiCode.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity 
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
