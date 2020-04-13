using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using WPFPrismHelloWorld.Views;

namespace WPFPrismHelloWorld.ViewModels
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
        public DelegateCommand SayHiCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand ThankYouCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager, IContainerExtension container)
        {
            SayHiCommand = new DelegateCommand(() =>
            {
                IRegion region = regionManager.Regions["ContentRegion"];
                region.RemoveAll();
                var view = container.Resolve<MyView>();
                region.Add(view);
            });
            ThankYouCommand = new DelegateCommand(() =>
            {
                IRegion region = regionManager.Regions["ContentRegion"];
                region.RemoveAll();
                var view = container.Resolve<YourView>();
                region.Add(view);
            });
            RemoveCommand = new DelegateCommand(() =>
            {
                IRegion region = regionManager.Regions["ContentRegion"];
                region.RemoveAll();
            });
        }
    }
}
