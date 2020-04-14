using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPFPrismViewNavigation.Views;

namespace WPFPrismViewNavigation.ViewModels
{
    public class MyViewModel : BindableBase , INavigationAware
    {
        private string message;
        private readonly IRegionManager regionManager;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
        public DelegateCommand GoNextCommand { get; set; }
        public int Counter { get; set; }
        public MyViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            GoNextCommand = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate("ContentRegion", nameof(View1));
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            await Task.Yield();
            Message = navigationContext.NavigationService.Journal.CanGoBack == false ? "尚未開始導航 "+ Counter++ : "可以回上一頁";
            //regionManager.Regions["ContentRegion"].NavigationService.Journal.Clear();
        }
    }
}
