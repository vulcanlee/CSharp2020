using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFNFC.ViewModels
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Plugin.NFC;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string Tag { get; set; }
        public DelegateCommand ReadNFCCommand { get; set; }
        public DelegateCommand StopReadNFCCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ReadNFCCommand = new DelegateCommand(async () =>
            {
                if (CrossNFC.Current.IsAvailable == false)
                {
                    Tag = "你的裝置沒有 NFC 感應功能";
                    return;
                }
                if (CrossNFC.Current.IsEnabled == false)
                {
                    Tag = "裝置上 NFC 感應功能沒有啟用";
                    return;
                }

                SubscribeEvents();
                await StartListeningIfNotiOS();
            });
            StopReadNFCCommand = new DelegateCommand(() =>
              {
                  Tag = "";
                  UnsubscribeEvents();
                  CrossNFC.Current.StopListening();
              });
        }
        void SubscribeEvents()
        {
            CrossNFC.Current.OnTagDiscovered += OnTagDiscovered;
            CrossNFC.Current.OnMessageReceived += OnMessageReceived;
            CrossNFC.Current.OnMessagePublished += OnMessagePublished;
        }
        void UnsubscribeEvents()
        {
            CrossNFC.Current.OnTagDiscovered -= OnTagDiscovered;
            CrossNFC.Current.OnMessageReceived -= OnMessageReceived;
            CrossNFC.Current.OnMessagePublished -= OnMessagePublished;
        }
        /// <summary>
        /// Task to start listening for NFC tags if the user's device platform is not iOS
        /// </summary>
        /// <returns>Task to be performed</returns>
        async Task StartListeningIfNotiOS()
        {
            if (Device.RuntimePlatform == Device.iOS)
                return;
            await BeginListening();
        }
        /// <summary>
        /// Task to safely start listening for NFC Tags
        /// </summary>
        /// <returns>The task to be performed</returns>
        async Task BeginListening()
        {
            try
            {
                CrossNFC.Current.StartListening();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnMessagePublished(ITagInfo tagInfo)
        {
            Tag = tagInfo.SerialNumber;
        }

        private void OnMessageReceived(ITagInfo tagInfo)
        {
            Tag = tagInfo.SerialNumber;
        }

        private void OnTagDiscovered(ITagInfo tagInfo, bool format)
        {
            Tag = tagInfo.SerialNumber;
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
