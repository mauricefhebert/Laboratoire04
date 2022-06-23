using Laboratoire04.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Laboratoire04.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using Laboratoire04.Views;

namespace Laboratoire04.ViewModels
{
    internal class ListContactViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand TapCmd { get; set; }

        public ListContactViewModel()
        {
            TapCmd = new Command(OnTap);

            if (ContactDbContext.GetContacts().Count == 0)
            {
                ContactDbContext.AddContact(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placebear.com/640/360",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.AddContact(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placebear.com/640/360",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.AddContact(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placebear.com/640/360",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.AddContact(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placebear.com/640/360",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.AddContact(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placebear.com/640/360",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
                ContactDbContext.AddContact(new Contact()
                {
                    Prenom = "Prenom 01",
                    Nom = "Nom 01",
                    Initial = "PN 01",
                    Photo = @"https://placebear.com/640/360",
                    TelephonePersonnel = "(555) 555-5555",
                    TelephoneTravail = "(333) 333-3333",
                    CourrielPersonnel = "CourrielPersonnel01@hotmail.com",
                    CourrielTravail = "CourrielTravail01@hotmail.com"
                });
            }
        }

        public List<Contact> contacts
        {
            get { return ContactDbContext.GetContacts().OrderBy(x => x.Prenom).ToList(); }
        }

        public async void OnTap(object obj)
        {
            var contact = obj as Contact;
            Routing.RegisterRoute(nameof(DetailsContactView), typeof(DetailsContactView));
            await Shell.Current.GoToAsync($"{nameof(DetailsContactView)}?Id={contact.Id}");
        }
    }
}
