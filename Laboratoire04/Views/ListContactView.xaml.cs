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
            SeedData();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //actualiser le binding contexte
            this.BindingContext = null;
            this.BindingContext = new ListContactViewModel();
        }

        private void SeedData()
        {
            if (ContactDbContext.GetContacts().Count == 0)
            {
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Noreen",
                    Nom = "Cremer",
                    Initial = "NC",
                    Photo = @"https://this-person-does-not-exist.com/img/avatar-97719ae2aac2eff173d8f210a7211c81.jpg",
                    TelephonePersonnel = "(924) 897-5338",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "ncremer1@mozilla.org",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Frazer",
                    Nom = "Garretts",
                    Initial = "FG",
                    Photo = @"https://this-person-does-not-exist.com/img/avatar-3d29ae993ae8332a7585a06ba25cbdd2.jpg",
                    TelephonePersonnel = "(282) 860-6300",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Nikolaus",
                    Nom = "Dashkovich",
                    Initial = "ND",
                    Photo = @"https://this-person-does-not-exist.com/img/avatar-128240b8ab415dbc1f66845c372c12f1.jpg",
                    TelephonePersonnel = "(733) 723-3469",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "ndashkovich3@mtv.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Dorolice",
                    Nom = "Alf",
                    Initial = "DA",
                    Photo = @"https://this-person-does-not-exist.com/img/avatar-52bd5b0d48d84c43e8498c8d2e60484f.jpg",
                    TelephonePersonnel = "(309) 351-8274",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "dalf4@creativecommons.org",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Estevan",
                    Nom = "Gatch",
                    Initial = "EG",
                    Photo = @"https://this-person-does-not-exist.com/img/avatar-a0e73a11ab38784298b031db724a69b5.jpg",
                    TelephonePersonnel = "(295) 268-1091",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "egatch2@istockphoto.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
            }
        }
    }
}