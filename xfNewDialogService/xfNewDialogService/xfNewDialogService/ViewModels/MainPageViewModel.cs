using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfNewDialogService.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Prism.Services.Dialogs;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public DelegateCommand OpenDialogCommand { get; set; }
        public string Response { get; set; }
        public MainPageViewModel(INavigationService navigationService,
            IDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            OpenDialogCommand = new DelegateCommand(() =>
            {
                var parameters = new DialogParameters
                {
                    { "Title", "警告提示" },
                    { "Message", "請確認是否要繼續執行下去?" }
                };
                dialogService.ShowDialog("MessageDialog", parameters, x=>
                {
                    Response = x.Parameters.GetValue<string>("Result");
                });
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
