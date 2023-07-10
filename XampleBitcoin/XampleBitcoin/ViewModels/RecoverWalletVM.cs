using NBitcoin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XampleBitcoin.src;
using XampleBitcoin.Views;

namespace XampleBitcoin.ViewModels
{
    public class RecoverWalletVM : BaseViewModel
    {

        public RecoverWalletVM(INavigation navigation)
        {

        }
        public Command recovercommand { get; }
        public INavigation Navigation;
        private string meenterpassowrd4wallet;
        public BitcoinViewModel Model { get; set; }
        string CreateName = "Default";
        public async Task RecoverrWallet()
        {
            IsLoading = true;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                string walletsFolder = null;
                string pathToDocuments;
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        pathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        walletsFolder = Path.Combine(pathToDocuments, "..", "Library", walletData.DefaultWalletsDirectory);
                        break;
                    case Device.Android:
                        pathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        walletsFolder = Path.Combine(pathToDocuments, walletData.DefaultWalletsDirectory);
                        break;
                    default:
                        break;
                }
                if (!Directory.Exists(walletsFolder))
                {
                    Directory.CreateDirectory(walletsFolder);
                }
                var pathToWallet = Path.Combine(walletsFolder, $"{CreateName}", walletData.DefaultWalletFileName);
                if (File.Exists(pathToWallet))
                {
                    IsLoading = false;
                    //the main wallet will be replaced? have you saved your wallet seed?
                    await App.Current.MainPage.DisplayAlert("Wallet exist", "Wallet with same name exist.", "OK");
                    return;
                }
              
                // 3. Recover wallet

                var wallet = walletManagement.Recover(new Mnemonic(MnemonicString), MEEnterPassword4Wallet, pathToWallet, Network.Main);
                Model = new BitcoinViewModel(Navigation, MEEnterPassword4Wallet, pathToWallet);
                Model.Update();
                MnemonicString = "";
                CreateName = "";
                IsLoading = false;
                //StringBuilder builder = new StringBuilder();
                //builder.AppendLine("Check to see your seeds are correct.");
                //var actionn = await App.Current.MainPage.DisplayAlert("Check details?", builder.ToString(), "OK", "Cancel");
                //if (actionn)
                //{
                //    DefaultVM myVm = new DefaultVM(Navigation);
                    await Navigation.PushAsync(new WalletHome()).ConfigureAwait(false);
                //}
                //else
                //{
                //    //BusyBusy.IsRunning = false;
                //    return;

                //}
            });
            IsLoading = false;
        }
        public string MEEnterPassword4Wallet
        {
            get { return meenterpassowrd4wallet; }
            set
            {
                meenterpassowrd4wallet = value;
                SetProperty(ref meenterpassowrd4wallet, value);
            }
        }
        private string mnemonicString;

        public string MnemonicString
        {
            get { return mnemonicString; }
            set
            {
                mnemonicString = value;
                SetProperty(ref mnemonicString, value);
            }
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
