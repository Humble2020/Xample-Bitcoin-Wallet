using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleBitcoin.Common;
using XampleBitcoin.src;
using XampleBitcoin.ViewModels;

namespace XampleBitcoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletHome : ContentPage
    {
        DefaultVM MywVM;
        public BitcoinViewModel wVm;
        //public List<WalletInfo> Wallets { get; set; }
       // WalletInfo WalletInfo = new WalletInfo();
        public WalletHome()
        {
            InitializeComponent();
            BindingContext = MywVM = new DefaultVM(Navigation);
           // Wallets = WalletInfo.AvailableWallets().ToList();
        }
        private async void OnItemTapped(object sender, EventArgs args)
        {

            await Device.InvokeOnMainThreadAsync(async () =>
            {
                Frame selectedItem = (Frame)sender;
                selectedItem.IsEnabled = false;
                Color initColor = selectedItem.BackgroundColor;
                selectedItem.BackgroundColor = Color.FromHex("#6A2C8B");
                await Task.Delay(500);
                selectedItem.BackgroundColor = initColor;
                selectedItem.IsEnabled = true;

            });
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (String.IsNullOrEmpty(passBook))
            //{
              //MywVM.CheckIfEmpty();
           // Wallets = WalletInfo.AvailableWallets().ToList();
            //}
            //else
            //{

            //}
           //MywVM.firstrun();
        }
    }
}