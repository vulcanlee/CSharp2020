using Prism.Mvvm;
using Prism.Regions;
using WPFPrismNoModuleAutoView.Views;

namespace WPFPrismNoModuleAutoView.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager regionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MyView));
        }
    }
}
