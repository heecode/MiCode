using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiCode.Core;
using MiCode.Core.Domain;
using MiCode.Service;
using MiCode.Web.Api.Models;

namespace MiCode.Web.Api.Controllers
{
    public class SchoolsController : BaseApiController
    {
        protected readonly SchoolService _schoolService;
        public SchoolsController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _schoolService = new SchoolService(UnitOfWork);
        }

        // GET: api/Schools
        public IEnumerable<SchoolModel> Get()
        {
            return _schoolService.GetAll().ToList().Select(x=>ModelFactory.Create(x));
        }

        // GET: api/Schools/5
        public SchoolModel Get(int id)
        {
            return ModelFactory.Create(_schoolService.GetById(id));
        }

        // POST: api/Schools
        public void Post(SchoolModel schoolModel)
        {
            var school = ModelFactory.Create(schoolModel);
            _schoolService.Save(school);
        }

        // PUT: api/Students/5
        public void Put(int id, SchoolModel schoolModel)
        {
            var school = ModelFactory.Create(schoolModel);
            _schoolService.Save(school);
        }

    }
}
