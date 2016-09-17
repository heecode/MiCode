using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.Core.Repository;

namespace MiCode.Test
{
  public  class MockUnitOfWork<TContext> : IUnitOfWork where TContext:class , new ()
    {
        private readonly MockDataContext _context;
        private readonly Dictionary<Type, object> _repositories;
        

        public MockUnitOfWork()
        {
            
            _context = new MockDataContext();
            _repositories = new Dictionary<Type, object>();
          
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var entityName = typeof(TEntity).Name;
            var prop = _context.GetType().GetProperty(entityName);
            MockRepository<TEntity> repository = null;
            if (prop != null)
            {
                var entityValue = prop.GetValue(_context, null);
                repository = new MockRepository<TEntity>(entityValue as List<TEntity>);
            }
            else
            {
                repository = new MockRepository<TEntity>(new List<TEntity>());
            }
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public TIEntity Repository<TEntity, TIEntity>() where TEntity : IBaseRepo, TIEntity
        {
            throw new NotImplementedException();
        }

      
        public IRepository<Teacher> Teachers { get; }
        public IRepository<Standard> Standards { get; }
        public int Complete()
        {
            return 1;
        }
    }
}
