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
    public partial class EnterPassword : ContentPage
    {
        public EnterPasswordVM EnVm { get; set; }
        public EnterPassword(INavigation navigation)
        {
            InitializeComponent();
            BindingContext = EnVm = new EnterPasswordVM(Navigation);
        }

    }
}