    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace CalcTempModule
{
    public class CalcTempModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public CalcTempModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<Views.CalcTempView>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ViewModels.CalcTempViewModel>(new ContainerControlledLifetimeManager());

            var view = _container.Resolve<Views.CalcTempView>();
            var vm = _container.Resolve<ViewModels.CalcTempViewModel>();
            view.DataContext = vm;
            _regionManager.RegisterViewWithRegion("TempConvertRegion", () => view);
        }
    }
}
