using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleBitcoin.src;
using XampleBitcoin.ViewModels;

namespace XampleBitcoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BitcoinSend : ContentPage
    {
        public BitcoinViewModel Model { get; set; }
        public SendBitcoinVM sVm { get; set; }
        public INavigation Navigationx { get; set; }
        public BitcoinSend(BitcoinViewModel model)
        {
            Model = model;
            InitializeComponent();
            BindingContext = sVm = new SendBitcoinVM(Navigationx, model);
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
            IsBusy = true;
            sVm.checkfirst();
        }

        private void ChangeToUsd(object sender, EventArgs e)
        {

            if (sVm.USD_amount == null)
            {
                return;
            }

            if (sVm.USD_amount != null)
            {
                sVm.ConvertUSD_toBTC();
            }
            else
            {
                return;
            }

        }

        private async void OnSetMaxAmountButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountsendBTC.Text) && !string.IsNullOrEmpty(amountsendUSD.Text))
                amountsendBTC.CursorPosition = amountsendBTC.Text.Length;

            await Device.InvokeOnMainThreadAsync(async () =>
            {
                amountsendBTC.Unfocus();
                amountsendUSD.Unfocus();

            });
        }

        private async void OnSetMaxAmount2ButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(amountsendBTC.Text) && !string.IsNullOrEmpty(amountsendUSD.Text))
                amountsendBTC.CursorPosition = amountsendBTC.Text.Length;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                amountsendBTC.Unfocus();
                amountsendUSD.Unfocus();

            });
        }
    }
}