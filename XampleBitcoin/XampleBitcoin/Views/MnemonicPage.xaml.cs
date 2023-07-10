using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleBitcoin.ViewModels;

namespace XampleBitcoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MnemonicPage : ContentPage
    {
        public MnemonicVM mVM { get; set; }
        public MnemonicPage(string walletSeed)
        {
            InitializeComponent();
            BindingContext = mVM = new MnemonicVM(Navigation, walletSeed);
            Device.BeginInvokeOnMainThread(() =>
            {
                seedInFullName.Text = walletSeed;
            });
        }
    }
}