using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xfNewDialogService.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageDialog : ContentView
    {
        public MessageDialog()
        {
            InitializeComponent();
        }
    }
}