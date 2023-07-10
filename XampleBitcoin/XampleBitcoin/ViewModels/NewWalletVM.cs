using NBitcoin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XampleBitcoin.src;
using XampleBitcoin.Views;

namespace XampleBitcoin.ViewModels
{
    public  class NewWalletVM : BaseViewModel
    {
        public NewWalletVM(INavigation navigation)
        {
            Navigation = navigation;
            SendBcommand = new Command(async () => await Task.WhenAll(CreatewWallet()));
        }
        public INavigation Navigation;
        public Command SendBcommand { get; }
        public BitcoinViewModel Model { get; set; }
        public althashViewModel altModel { get; set; }
        public argoneumViewModel argModel { get; set; }
        public bcashViewModel bcashModel { get; set; }
        public bgoldViewModel bgoldModel { get; set; }
        public bitplusViewModel bitpModel { get; set; }
        public chaincoinViewModel chainModel { get; set; }
        public colossusViewModel colosModel { get; set; }
        public dashViewModel dashModel { get; set; }
        public dogecashViewModel dogcashModel { get; set; }
        public dogecoinViewModel dogcoinModel { get; set; }
        public dstemViewModel dstemModel { get; set; }
        public featherViewModel featrModel { get; set; }
        public gincoinViewModel gincoinModel { get; set; }
        public groestlViewModel groestModel { get; set; }
        public kotoViewModel kotoModel { get; set; }
        public lbryViewModel lbryModel { get; set; }
        public liquidViewModel liquidModel { get; set; }
        public litecoinViewModel litecoinModel { get; set; }
        public mogwaiViewModel mogwaiModel { get; set; }
        public monacoinViewModel monacoinModel { get; set; }
        public monetaryViewModel MonetaryModel { get; set; }
        public neblioViewModel neblioModel { get; set; }
        public polisViewModel polisModel { get; set; }
        public qtumViewModel qtumModel { get; set; }
        public stratisViewModel stratisModel { get; set; }
        public terracoinViewModel teracoinModel { get; set; }
        public triptourViewModel triptourModel { get; set; }
        public ufoViewModel ufoModel { get; set; }
        public vergeViewModel vergeModel { get; set; }
        public viacoinViewModel viacoinModel { get; set; }
        public xdsViewModel xdsModel { get; set; }
        public zclassicViewModel zclassicModel { get; set; }
        public zcoinViewModel zcoinModel { get; set; }

        private string newpassword4wallet;

        public string NewPassword4Wallet
        {
            get { return newpassword4wallet; }
            set { newpassword4wallet = value;
                OnPropertyChanged();
            }
           
        }

        private string createname;

        public string CreateName
        {
            get { return createname; }
            set
            {
                createname = value;
                SetProperty(ref createname, value);
            }
        }
        public async Task CreatewWallet()
        {
            //IsLoading = true;
            //await Device.InvokeOnMainThreadAsync(async () =>
            //{
                CreateName = "Defaultk";
                CreateName = CreateName.Trim();
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
                var Bitcoinpath = Path.Combine(walletsFolder, "bitcoin", walletData.DefaultWalletFileName);
            var Bcashpath = Path.Combine(walletsFolder, "bcash", walletData.DefaultWalletFileName);
            var Bgoldpath = Path.Combine(walletsFolder, "bgold", walletData.DefaultWalletFileName);
            var Bitpluspath = Path.Combine(walletsFolder, "bitplus", walletData.DefaultWalletFileName);
            var Chaincoinpath = Path.Combine(walletsFolder, "chaincoin", walletData.DefaultWalletFileName);
            var Colosuspath = Path.Combine(walletsFolder, "colosus", walletData.DefaultWalletFileName);
            var Dashpath = Path.Combine(walletsFolder, "dash", walletData.DefaultWalletFileName);
            var Dogecashpath = Path.Combine(walletsFolder, "dogecash", walletData.DefaultWalletFileName);
            var Dogecoinpath = Path.Combine(walletsFolder, "dogecoin", walletData.DefaultWalletFileName);
            var Feathercoinpath = Path.Combine(walletsFolder, "feather", walletData.DefaultWalletFileName);
            var Groestlpath = Path.Combine(walletsFolder, "groestl", walletData.DefaultWalletFileName);
            var Kotopath = Path.Combine(walletsFolder, "koto", walletData.DefaultWalletFileName);
            var Lbrypath = Path.Combine(walletsFolder, "lbry", walletData.DefaultWalletFileName);
            var Liquidpath = Path.Combine(walletsFolder, "liquid", walletData.DefaultWalletFileName);
            var Litecoinpath = Path.Combine(walletsFolder, "litecoin", walletData.DefaultWalletFileName);
            var Mogwaipath = Path.Combine(walletsFolder, "mogwai", walletData.DefaultWalletFileName);
            var Monacoinpath = Path.Combine(walletsFolder, "monacoin", walletData.DefaultWalletFileName);
            var MonetaryUnitpath = Path.Combine(walletsFolder, "monet", walletData.DefaultWalletFileName);
            var Nebliopath = Path.Combine(walletsFolder, "neblio", walletData.DefaultWalletFileName);
            var Polispath = Path.Combine(walletsFolder, "polis", walletData.DefaultWalletFileName);
            var Qtumpath = Path.Combine(walletsFolder, "qtum", walletData.DefaultWalletFileName);
            var Stratispath = Path.Combine(walletsFolder, "startis", walletData.DefaultWalletFileName);
            var Terracoinpath = Path.Combine(walletsFolder, "terracoin", walletData.DefaultWalletFileName);
            var Triptourpath = Path.Combine(walletsFolder, "triptor", walletData.DefaultWalletFileName);
            var Ufopath = Path.Combine(walletsFolder, "ufo", walletData.DefaultWalletFileName);
            var Vergepath = Path.Combine(walletsFolder, "verge", walletData.DefaultWalletFileName);
            var Viacoinpath = Path.Combine(walletsFolder, "viacoin", walletData.DefaultWalletFileName);
            var Zclassicpath = Path.Combine(walletsFolder, "zclasic", walletData.DefaultWalletFileName);
            var Zcoinpath = Path.Combine(walletsFolder, "zcoin", walletData.DefaultWalletFileName);
            var Althashpath = Path.Combine(walletsFolder, "althash", walletData.DefaultWalletFileName);
            var Argoneumpath = Path.Combine(walletsFolder, "argoneum", walletData.DefaultWalletFileName);
            var Xdspath = Path.Combine(walletsFolder, "xds", walletData.DefaultWalletFileName);
            var Gincoinpath = Path.Combine(walletsFolder, "gincoin", walletData.DefaultWalletFileName);
            var Dstempath = Path.Combine(walletsFolder, "dstem", walletData.DefaultWalletFileName);

            //if (File.Exists(pathToWallet))
            //{
            //    await App.Current.MainPage.DisplayAlert("Wallet exist", "Wallet with same name exist.", "OK");
            //    return;
            //}
            Mnemonic mnemonic = null;
                var Bitcoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Bitcoinpath, Network.Main);
            var bcashwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Bcashpath, NBitcoin.Altcoins.BCash.Instance.Mainnet);
            var bgoldwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Bgoldpath, NBitcoin.Altcoins.BGold.Instance.Mainnet);
            var bitcoinpluswallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Bitpluspath, NBitcoin.Altcoins.Bitcoinplus.Instance.Mainnet);
            var chaincoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Chaincoinpath, NBitcoin.Altcoins.Chaincoin.Instance.Mainnet);
            var colosuswallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Colosuspath, NBitcoin.Altcoins.Colossus.Instance.Mainnet);
            var dashwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Dashpath, NBitcoin.Altcoins.Dash.Instance.Mainnet);
            var dogecashwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Dogecashpath, NBitcoin.Altcoins.DogeCash.Instance.Mainnet);
            var dogecoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Dogecoinpath, NBitcoin.Altcoins.Dogecoin.Instance.Mainnet);
            var feathercoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Feathercoinpath, NBitcoin.Altcoins.Feathercoin.Instance.Mainnet);
            var groestlcoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Groestlpath, NBitcoin.Altcoins.Groestlcoin.Instance.Mainnet);
            var kotowallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Kotopath, NBitcoin.Altcoins.Koto.Instance.Mainnet);
            var lbrywallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Lbrypath, NBitcoin.Altcoins.LBRYCredits.Instance.Mainnet);
            var liquidwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Liquidpath, NBitcoin.Altcoins.Liquid.Instance.Mainnet);
            var litecoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Litecoinpath, NBitcoin.Altcoins.Litecoin.Instance.Mainnet);
            var mogwaiwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Mogwaipath, NBitcoin.Altcoins.Mogwai.Instance.Mainnet);
            var monacoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Monacoinpath, NBitcoin.Altcoins.Monacoin.Instance.Mainnet);
            var monetarywallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, MonetaryUnitpath, NBitcoin.Altcoins.MonetaryUnit.Instance.Mainnet);
            var nebliowallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Nebliopath, NBitcoin.Altcoins.Neblio.Instance.Mainnet);
            var poliswallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Polispath, NBitcoin.Altcoins.Polis.Instance.Mainnet);
            var qtumwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Qtumpath, NBitcoin.Altcoins.Qtum.Instance.Mainnet);
            var stratiswallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Stratispath, NBitcoin.Altcoins.Stratis.Instance.Mainnet);
            var terracoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Terracoinpath, NBitcoin.Altcoins.Terracoin.Instance.Mainnet);
            var triptourwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Triptourpath, NBitcoin.Altcoins.Triptourcoin.Instance.Mainnet);
            var ufowallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Ufopath, NBitcoin.Altcoins.Ufo.Instance.Mainnet);
            var vergewallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Vergepath, NBitcoin.Altcoins.Verge.Instance.Mainnet);
            var viacoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Viacoinpath, NBitcoin.Altcoins.Viacoin.Instance.Mainnet);
            var zclassicwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Zclassicpath, NBitcoin.Altcoins.Zclassic.Instance.Mainnet);
            var zcoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Zcoinpath, NBitcoin.Altcoins.ZCoin.Instance.Mainnet);
            var althashwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Althashpath, NBitcoin.Altcoins.Althash.Instance.Mainnet);
            var argoneumwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Argoneumpath, NBitcoin.Altcoins.Argoneum.Instance.Mainnet);
            var xdswallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Xdspath, NBitcoin.Altcoins.XDS.Instance.Mainnet);
            var gincoinwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Gincoinpath, NBitcoin.Altcoins.Gincoin.Instance.Mainnet);
            var dstemwallet = walletManagement.Create(out mnemonic, NewPassword4Wallet, Dstempath, NBitcoin.Altcoins.Dystem.Instance.Mainnet);
            //Mnemonics = mnemonic.ToString();
            Preferences.Set("Password4Wallet", NewPassword4Wallet);
                Model = new BitcoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Bitcoinpath);
                Model.Update();
            altModel = new althashViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Althashpath);
            altModel.Update();
            argModel = new argoneumViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Argoneumpath);
            argModel.Update();
            bcashModel = new bcashViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Bcashpath);
            bcashModel.Update();
            bgoldModel = new bgoldViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Bgoldpath);
            bgoldModel.Update();
            bitpModel = new bitplusViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Bitpluspath);
            bitpModel.Update();
            chainModel = new chaincoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Chaincoinpath);
            chainModel.Update();
            colosModel = new colossusViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Colosuspath);
            colosModel.Update();
            dashModel = new dashViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Dashpath);
            dashModel.Update();
            dogcashModel = new dogecashViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Dogecashpath);
            dogcashModel.Update();
            dogcoinModel = new dogecoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Dogecoinpath);
            dogcoinModel.Update();
            dstemModel = new dstemViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Dstempath);
            dstemModel.Update();
            featrModel = new featherViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Feathercoinpath);
            featrModel.Update();
            gincoinModel = new gincoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Gincoinpath);
            gincoinModel.Update();
            groestModel = new groestlViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Groestlpath);
            groestModel.Update();
            kotoModel = new kotoViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Kotopath);
            kotoModel.Update();
            lbryModel = new lbryViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Lbrypath);
            lbryModel.Update();
            liquidModel = new liquidViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Liquidpath);
            liquidModel.Update();
            litecoinModel = new litecoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Litecoinpath);
            litecoinModel.Update();
            mogwaiModel = new mogwaiViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Mogwaipath);
            mogwaiModel.Update();
            monacoinModel = new monacoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Monacoinpath);
            monacoinModel.Update();
            MonetaryModel = new monetaryViewModel(Navigation, Preferences.Get("Password4Wallet", ""), MonetaryUnitpath);
            MonetaryModel.Update();
            neblioModel = new neblioViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Nebliopath);
            neblioModel.Update();
            polisModel = new polisViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Polispath);
            polisModel.Update();
            qtumModel = new qtumViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Qtumpath);
            qtumModel.Update();
            stratisModel = new stratisViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Stratispath);
            stratisModel.Update();
            teracoinModel = new terracoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Terracoinpath);
            teracoinModel.Update();
            triptourModel = new triptourViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Triptourpath);
            triptourModel.Update();
            ufoModel = new ufoViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Ufopath);
            ufoModel.Update();
            vergeModel = new vergeViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Vergepath);
            vergeModel.Update();
            viacoinModel = new viacoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Viacoinpath);
            viacoinModel.Update();
            xdsModel = new xdsViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Xdspath);
            xdsModel.Update();
            zclassicModel = new zclassicViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Zclassicpath);
            zclassicModel.Update();
            zcoinModel = new zcoinViewModel(Navigation, Preferences.Get("Password4Wallet", ""), Zcoinpath);
            zcoinModel.Update();

            CreateName = "";
               var nh = mnemonic.ToString();
                //Preferences.Set("mena", nh);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushAsync(new MnemonicPage(nh)).ConfigureAwait(false);
                });
            //});
            //IsLoading = false;
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
