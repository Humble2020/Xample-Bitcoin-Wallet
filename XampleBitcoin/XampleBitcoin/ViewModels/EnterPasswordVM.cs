using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XampleBitcoin.Services;
using XampleBitcoin.src;
using XampleBitcoin.Views;

namespace XampleBitcoin.ViewModels
{
    public class EnterPasswordVM : BaseViewModel
    {
        public EnterPasswordVM(INavigation navigation)
        {
            Navigation = navigation;
            EnterBcommand = new Command(async () => await Task.WhenAll(TakenPasswordDigested()));
            ToastService = DependencyService.Get<IToastService>();
        }
        public INavigation Navigation;
        public Command EnterBcommand { get; }
        public BitcoinViewModel Model { get; set; }
        private IToastService ToastService;
        private string enterpassword4wallet;

        public string EnterPassword4Wallet
        {
            get { return enterpassword4wallet; }
            set { enterpassword4wallet = value;
                OnPropertyChanged();
            }
        }

        public async Task TakenPasswordDigested()
        {
            //IsLoading = true;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                try
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
                    var pathToWallet = Path.Combine(walletsFolder, "Default", walletData.DefaultWalletFileName);
                    var wallet = walletManagement.Load(EnterPassword4Wallet, pathToWallet);
                    Preferences.Set("NewPassword4Wallet", EnterPassword4Wallet);
                    Preferences.Set("Bookset", "Yeah");
                    await WalletListNavigation();
                }
                catch
                {
                    ToastService?.Show("Wrong Password! Try again", ToastPosition.Bottom, Application.Current.RequestedTheme.ToString());
                    Preferences.Remove("NewPassword4Wallet", "");
                    Preferences.Remove("Bookset", "");
                }

                //if (EnterPassword4Wallet.Contains(""))//check to see password can open wallets...
                //{
                    
                //    Device.BeginInvokeOnMainThread(async () =>
                //    {
                        
                      
                //    });
                //}
                //else if (EnterPassword4Wallet.Contains(""))
                //{
                    
                //}
            });
            //IsLoading = false;
        }
        private async Task WalletListNavigation()
        {
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Navigation.PushAsync(new WalletHome()).ConfigureAwait(false);

            });
        }
    }
}
