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
    internal class ListContactViewModel
    {
        public ICommand TapCmd { get; set; }

        public ListContactViewModel()
        {
            TapCmd = new Command(OnTap);
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
