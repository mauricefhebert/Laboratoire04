using Laboratoire04.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratoire04.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsContactView : ContentPage
    {
        public DetailsContactView()
        {
            InitializeComponent();
            this.BindingContext = new DetailsContactViewModel();
        }
    }
}