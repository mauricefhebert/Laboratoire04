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
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placeimg.com/150/150/people",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placeimg.com/150/150/people",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placeimg.com/150/150/people",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placeimg.com/150/150/people",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placeimg.com/150/150/people",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.SeedDatabase(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placeimg.com/150/150/people",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
            }
        }
    }
}