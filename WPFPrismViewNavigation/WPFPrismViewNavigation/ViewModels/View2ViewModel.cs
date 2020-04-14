using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPFPrismViewNavigation.ViewModels
{
    public class View2ViewModel : BindableBase, INavigationAware
    {
        private string message;
        private readonly IRegionManager regionManager;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
        public int Counter { get; set; }
        public DelegateCommand GoPrevCommand { get; set; }
        public View2ViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            GoPrevCommand = new DelegateCommand(() =>
            {
                regionManager.Regions["ContentRegion"].NavigationService.Journal.GoBack();
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
            Message = navigationContext.NavigationService.Journal.CanGoBack == false ? "尚未開始導航 " + this.GetHashCode() : "可以回上一頁 " + Counter++;
        }
    }
}
