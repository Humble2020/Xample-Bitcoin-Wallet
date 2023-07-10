using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleBitcoin.Services;
using XampleBitcoin.src;
using XampleBitcoin.Views;

namespace XampleBitcoin
{
    public partial class App : Application
    {
        //INavigation navigation;
        public BitcoinViewModel Model { get; set; }
        public App()
        {
            InitializeComponent();

          //DependencyService.Register<MockDataStore>();
         // MainPage = new AppShell();
        MainPage = new NavigationPage(new WalletHome());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
