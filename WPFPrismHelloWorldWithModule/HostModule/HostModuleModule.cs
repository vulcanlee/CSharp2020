using HostModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostModule
{
    public class HostModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //IContainerRegistry container = containerProvider.Resolve<IContainerRegistry>();
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("ContentRegion",typeof(MyView));
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(YourView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MyView>();
            containerRegistry.RegisterForNavigation<YourView>();
        }
    }
}
