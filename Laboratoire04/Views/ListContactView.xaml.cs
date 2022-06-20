using Laboratoire04.Data;
using Laboratoire04.Models;
using Laboratoire04.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratoire04.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactView : ContentPage
    {
        public ListContactView()
        {
            InitializeComponent();
            this.BindingContext = new ListContactViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //actualiser le binding contexte
            this.BindingContext = null;
            this.BindingContext = new ListContactViewModel();
        }
    }
}