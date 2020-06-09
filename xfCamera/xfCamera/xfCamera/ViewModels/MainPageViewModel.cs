using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfCamera.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService; 
        public ImageSource MyImageSource { get; set; }
        public DelegateCommand TapCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            TapCommand = new DelegateCommand(async () =>
            {
                // 進行 Plugin.Media 套件的初始化動作
                await Plugin.Media.CrossMedia.Current.Initialize();

                // 啟動拍照功能，並且儲存到指定的路徑與檔案中
                var file = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "Sample.jpg"
                });

                if (file == null)
                    return;

                // 讀取剛剛拍照的檔案內容，轉換成為 ImageSource，如此，就可以顯示到螢幕上了

                MyImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
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
