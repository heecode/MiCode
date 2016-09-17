using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.Core.Repository;

namespace MiCode.Service
{
  public  class BaseService <TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _uow;
        private readonly IRepository<TEntity> _repository;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.GetRepository<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Save(TEntity entity)
        {
           if (entity.Id == 0)
                _repository.Add(entity);
           else
           _repository.Update(entity);

            _uow.Complete();
           
        }

        public void Save(IEnumerable<TEntity> entities)
        {
            _repository.AddRange(entities);
            _uow.Complete();
        }

        public TEntity GetById(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<TEntity> GetByIds(IEnumerable<int> ids)
        {
            return _repository.GetAll().Where(x => ids.Contains(x.Id));
        }

        public void Delete(TEntity entity)
        {
           //var ent = _repository.Get()
           _repository.Remove(entity);
            _uow.Complete();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
           // entities.ToList().Select(x => Delete(x));
            var ids = entities.Select(x => x.Id);
            var ents =_repository.GetAll().Where(x => ids.Contains(x.Id)).ToList();
            foreach (var ent in ents)
            {
                Delete(ent);
            }
            _uow.Complete();
           
        }

        public void Delete(int id)
        {
            var ent = _repository.Get(id);
            Delete(ent);
            
        }

        public void Delete(IEnumerable<int> ids)
        {
            var ents = _repository.GetAll().Where(x => ids.Contains(x.Id));
            Delete(ents);
            
        }
    }
}
