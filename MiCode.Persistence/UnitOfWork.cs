using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.Core.Repository;
using MiCode.Persistence.Repositories;

namespace MiCode.Persistence
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext: DbContext, new()
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;
     
        public IRepository<Teacher> Teachers { get; }
        public IRepository<Standard> Standards { get; }


        public UnitOfWork()
        {
           // _context = context;
            _context = new TContext();
            _repositories = new Dictionary<Type, object>();
          
            Teachers = new Repository<Teacher>(_context);
            Standards = new Repository<Standard>(_context);
            _disposed = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            // Checks if the Dictionary Key contains the Model class
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                // Return the repository for that Model class
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            // If the repository for that Model class doesn't exist, create it
            var repository = new Repository<TEntity>(_context);

            // Add it to the dictionary
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

      

        public TIEntity Repository<TEntity, TIEntity>() where TEntity : IBaseRepo, TIEntity
        {
            var repo = typeof(TEntity);
            var obj = Activator.CreateInstance(repo, _context);
            return (TIEntity)obj;
           
            
        }




        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this._disposed = true;
            }
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }
    }

    
}
