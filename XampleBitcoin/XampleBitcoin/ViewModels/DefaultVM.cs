using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XampleBitcoin.Common;
using XampleBitcoin.src;
using XampleBitcoin.Views;

namespace XampleBitcoin.ViewModels
{
    public class DefaultVM : BaseViewModel, INotifyPropertyChanged
    {
        public List<WalletInfo> Wallets { get; set; }
        public BitcoinViewModel wVm { get; set; }
        public INavigation Navigation;
        WalletInfo WalletInfo = new WalletInfo();
       
        public DefaultVM(INavigation navigation)
        {
            Navigation = navigation;
            Wallets = WalletInfo.AvailableWallets().ToList();
        }
        public void CheckIfEmpty()
        {
            //IsLoading = true;
           if (Wallets.Count() <= 0)
            {
                //await Device.InvokeOnMainThreadAsync(async () =>
                //{
                    //create a default wallet.....
                    Navigation.PushAsync(new NewWalletPassword(Navigation)).ConfigureAwait(false);

                //});

                // Routing.RegisterRoute("CreateWallet", typeof(CreateBitcoin));

            }
            //else if (Wallets.Count() > 0 & String.IsNullOrEmpty(Hpass))
            //{
            //    //Enter password to your default wallet to unlock.....
            //    Navigation.PushAsync(new EnterPassword(Navigation)).ConfigureAwait(false);
            //}
            //else if (Wallets.Count() > 0 & !String.IsNullOrEmpty(Hpass))
            //{
            //    //Enter password to your default wallet to unlock.....
            //    Navigation.PushAsync(new EnterPassword(Navigation)).ConfigureAwait(false);
            //}
            //IsLoading = false;
        }
        private string btcstring;

        public string BTCString
        {
            get { return btcstring; }
            set
            {
                btcstring = value;
                OnPropertyChanged();
            }
        }
        private string BASE_URI = "https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD";
        public double hj;
        public async void firstrun()
        {
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                IsLoading = true;
                HttpResponseMessage response2;
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                        response2 = await httpClient.GetAsync($"{BASE_URI}").ConfigureAwait(false);
                    }
                    string stud = await response2.Content.ReadAsStringAsync().ConfigureAwait(false);
                    dynamic array = JsonConvert.DeserializeObject(stud);
                    decimal jhk;
                    foreach (var item in array)
                    {
                        var nk = item;
                        var j = nk.ToString();
                        var bk = j.Replace("USD", "").Replace(":", "").Replace(@"""", "").Replace(@"\", "").Replace(@"/", "");
                        var jh = bk;
                        jhk = Decimal.Parse(jh); // BTC price in USD
                        BTCString = "Exchange: " + jhk.ToString("C", new CultureInfo("en-US"));
                    }
                    IsLoading = false;
            });
        }
        private ICommand _selectWalletCommand;
        public ICommand SelectWalletCommand => _selectWalletCommand ??= new Command<WalletInfo>(async (value) => await Task.WhenAll(OnWalletTapped(value)));
        private async Task OnWalletTapped(WalletInfo wallet)
        {
            IsLoading = true;
            var lstColltn = wallet;
            //await Task.Delay(0);
            //wVm = new BitcoinViewModel(Navigation, "password9s0ru89iwuQO7852keirsopsovjisolijsntnlrsuhtusilIKSNCIH937484kgd", lstColltn.Path);//wallet path
            //Preferences.Set("Pref_WalletPath", lstColltn.Path);
            //wVm.Update();
            //await Navigation.PushAsync(new ClickPage(wVm)).ConfigureAwait(false);
            BitcoinViewModel mainViewModel = null;

            await Task.Run(() =>
            {
                //preferfrence password..
                mainViewModel = new BitcoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), lstColltn.Path);
                mainViewModel.Update();
            });

            await Navigation.PushAsync(new BitcoinHome(mainViewModel, Navigation)).ConfigureAwait(false);

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
