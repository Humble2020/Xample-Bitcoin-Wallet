using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleBitcoin.ViewModels;

namespace XampleBitcoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWalletPassword : ContentPage
    {
        public NewWalletVM NwVm { get; set; }
     

        public NewWalletPassword(INavigation navigation)
        {
            Navigation = navigation;
            InitializeComponent();
            BindingContext = NwVm = new NewWalletVM(Navigation);
        }
        public new INavigation Navigation;
    }
}