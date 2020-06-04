using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfQRCode3.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;
    using ZXing;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string BarcodeFormatType { get; set; }
        public string BarcodeResult { get; set; }

        public DelegateCommand ScanCommand { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ScanCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("ScanPage");
            });
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Result"))
            {
                var fooReslut = parameters["Result"] as Result;
                BarcodeFormatType = fooReslut.BarcodeFormat.ToString();
                BarcodeResult = fooReslut.Text;
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
