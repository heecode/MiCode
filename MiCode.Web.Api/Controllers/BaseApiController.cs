using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using MiCode.Core;
using MiCode.DependencyInjector;
using MiCode.Web.Api.Models;

namespace MiCode.Web.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        //private readonly UnityContainer container = MiCodeUnity.Instance;
        private ModelFactory _modelFactory;
        protected ModelFactory ModelFactory =>
           _modelFactory ?? (_modelFactory = new ModelFactory());
        protected  IUnitOfWork UnitOfWork;
    }
}
