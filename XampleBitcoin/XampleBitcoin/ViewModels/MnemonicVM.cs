using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XampleBitcoin.Views;

namespace XampleBitcoin.ViewModels
{
    public class MnemonicVM : BaseViewModel
    {
        public Command gotoListWallet { get; }
        public INavigation Navigation { get; set; }
        private string walletseed;
       public MnemonicVM(INavigation navigation, string Walletseed)
        {
            Navigation = navigation;
            WalletSeed = Walletseed;
            gotoListWallet = new Command(async () => await WalletListNavigation());
        }
        private ObservableCollection<string> wordmnemenomic;

        public ObservableCollection<string> WordMnemonic
        {
            get { return wordmnemenomic; }
            set { wordmnemenomic = value; }
        }

        public string WalletSeed
        {
            get { return walletseed; }
            set
            {
                walletseed = value;
                OnPropertyChanged();
            }
        }
        private async Task WalletListNavigation()
        {
            IsLoading = true;

            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Navigation.PushAsync(new WalletHome()).ConfigureAwait(false);

            });
            IsLoading = false;
        }
        private float _opacity = 1f;
        public float Opacity
        {
            get => _opacity;
            set { _opacity = value; OnPropertyChanged(nameof(Opacity)); }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading == value)
                    return;

                _isLoading = value;

                if (_isLoading)
                    Opacity = 0.3f;
                else
                    Opacity = 1f;

                OnPropertyChanged(nameof(IsLoading));
            }
        }
    }
}
