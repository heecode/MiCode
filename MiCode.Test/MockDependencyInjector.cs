using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MiCode.Core;

namespace MiCode.Test
{
  public  class MockDependencyInjector : UnityContainer
    {
        private static MockDependencyInjector _instance;

        public static MockDependencyInjector Instance =>
            _instance ?? (_instance = new MockDependencyInjector());

        private MockDependencyInjector()
        {
           this.RegisterType<IUnitOfWork, MockUnitOfWork<MockDataContext>>();
          
        }
    }
}
