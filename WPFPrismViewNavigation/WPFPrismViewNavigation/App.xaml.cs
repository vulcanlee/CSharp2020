using WPFPrismViewNavigation.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Regions;

namespace WPFPrismViewNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MyView>();
            containerRegistry.RegisterForNavigation<View1>();
            containerRegistry.RegisterForNavigation<View2>();
            //containerRegistry.RegisterForNavigation<object,MyView>(nameof(MyView));

        }

        // 在這裡指定 Region 要顯示的 View ，也是可行的
        public override void Initialize()
        {
            base.Initialize();
            //IContainerProvider container = (App.Current as PrismApplication).Container;
            IContainerProvider container = Container;
            IRegionManager regionManager = container.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(MyView));

            //var view = container.Resolve<MyView>();
            regionManager.RequestNavigate("ContentRegion", nameof(MyView));


            //IRegion region = regionManager.Regions["ContentRegion"];
            //var view = container.Resolve<MyView>();
            //region.Add(view);
        }
    }
}
