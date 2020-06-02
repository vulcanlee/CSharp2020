using System;
using System.Collections.Generic;
using System.Text;

namespace xfNewDialogService.Dialogs
{
    using System.ComponentModel;
    using System.Reflection;
    using Prism.AppModel;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Prism.Services.Dialogs;

    public class MessageDialogViewModel : INotifyPropertyChanged, IDialogAware, IAutoInitialize
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<IDialogParameters> RequestClose;
        public string Title { get; set; }
        public string Message { get; set; }
        public DelegateCommand OKCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public MessageDialogViewModel()
        {
            OKCommand = new DelegateCommand(() =>
            {
                var parameters = new DialogParameters();
                parameters.Add("Result", "OK");
                RequestClose?.Invoke(parameters);
            });
            CancelCommand = new DelegateCommand(() =>
            {
                var parameters = new DialogParameters();
                parameters.Add("Result", "Cancel");
                RequestClose?.Invoke(parameters);
            });
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
            Message = parameters.GetValue<string>("Message");
        }
    }
}
