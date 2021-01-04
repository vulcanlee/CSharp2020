using Prism.Commands;
using System;

namespace xfMediaPicker.ViewModels
{
    using System.ComponentModel;
    using System.IO;
    using System.Threading.Tasks;
    using Prism.Navigation;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string FilePath { get; set; }
        public ImageSource Photo { get; set; }
        public DelegateCommand TakePhotoCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            TakePhotoCommand = new DelegateCommand(async () =>
            {
                try
                {
                    FileResult photo = await MediaPicker.CapturePhotoAsync();
                    await LoadPhotoAsync(photo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                }
            });
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                FilePath = "";
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, "MyPhoto.png");
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            File.Delete(photo.FullPath);
            FilePath = newFile;

            FileResult showFile = new FileResult(FilePath);
            Photo = ImageSource.FromStream( () =>
            {
                Stream stream = showFile.OpenReadAsync().Result;
                return stream;
            });
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

    }
}
