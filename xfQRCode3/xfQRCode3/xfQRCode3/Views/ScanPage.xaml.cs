using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace xfQRCode3.Views
{
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
            
        }

        private void ZXingDefaultOverlay_FlashButtonClicked(object sender, EventArgs e)
        {
            ZXingScannerView.ToggleTorch();
        }
    }
}
