using WPFPrismNoModuleAutoView.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Unity;
using Prism.Regions;

namespace WPFPrismNoModuleAutoView
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
        }

        //// 在這裡指定 Region 要顯示的 View ，也是可行的
        //public override void Initialize()
        //{
        //    base.Initialize();
        //    //IContainerProvider container = (App.Current as PrismApplication).Container;
        //    IContainerProvider container = Container;
        //    IRegionManager regionManager = container.Resolve<IRegionManager>();
        //    regionManager.RegisterViewWithRegion("ContentRegion", typeof(MyView));
        //}
    }
}
