using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MiCode.Core;
using MiCode.Persistence;

namespace MiCode.DependencyInjector
{
    public class MiCodeUnity : UnityContainer
    {
        private static MiCodeUnity _instance;

        public static MiCodeUnity Instance =>
            _instance ?? (_instance = new MiCodeUnity());

        private MiCodeUnity()
        {
            this.RegisterType<IUnitOfWork, UnitOfWork<RepositoryContext>>();

        }
    }
}
