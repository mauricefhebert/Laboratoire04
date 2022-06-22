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

        public List<Contact> contacts
        {
            get { return ContactDbContext.GetContacts().OrderBy(x => x.Prenom).ToList(); }
        }
        public ListContactViewModel()
        {

            TapCmd = new Command(OnTap);
        }

        public async void OnTap(object obj)
        {
            var contact = obj as Contact;
            //var contactAsJson = JsonConvert.SerializeObject(contact);
            Routing.RegisterRoute(nameof(DetailsContactView), typeof(DetailsContactView));
            await Shell.Current.GoToAsync($"{nameof(DetailsContactView)}?Id={contact.Id}");
        }
    }
}
