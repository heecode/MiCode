using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core.Domain;
using MiCode.Core.Repository;

namespace MiCode.Test
{
   public class MockRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public List<TEntity> Context;

        public MockRepository(List<TEntity> context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            
            return GetAll().Single(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
           
            return Context.AsQueryable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.AsQueryable().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.AsQueryable().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            entity.Id = GenerateId();
            Context.Add(entity);
        }

        private int GenerateId()
        {
            Random rnd = new Random();
            return rnd.Next(1000);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            //Context.
            Context.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Remove(entity);
            }
           
        }
    }
}
