using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace CalcTempServices
{
    public class CalcTempServicesModule : IModule
    {
        private readonly IUnityContainer _container;

        public CalcTempServicesModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ICalcTempService, CalcTempService>(new ContainerControlledLifetimeManager());
        }
    }
}
