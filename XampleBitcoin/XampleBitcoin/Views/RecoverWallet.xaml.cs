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
    public partial class RecoverWallet : ContentPage
    {
        public RecoverWalletVM RcVM { get; set; }
        public RecoverWallet()
        {
            InitializeComponent();
            BindingContext = RcVM = new RecoverWalletVM(Navigation);
        }

        private void OnSetMaxAmount2ButtonClicked(object sender, EventArgs e)
        {

        }
    }
}