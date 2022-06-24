using Laboratoire04.Data;
using Laboratoire04.Models;
using Laboratoire04.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratoire04.ViewModels
{
    internal class DetailsContactViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id;
        private string prenom;
        private string nom;
        private string initial;
        private string photo;
        private string courrielPersonnel;
        private string courrielTravail;
        private string telephonePersonnel;
        private string telephoneTravail;
        public int Id { get => id; set { id = value; OnProperyChanged(); } }
        public string Prenom { get => prenom; set { prenom = value; OnProperyChanged(); } }
        public string Nom { get => nom; set { nom = value; OnProperyChanged(); } }
        public string Initial { get => initial; set { initial = value; OnProperyChanged(); } }
        public string Photo { get => photo; set { photo = value; OnProperyChanged(); } }
        public string CourrielPersonnel { get => courrielPersonnel; set { courrielPersonnel = value; OnProperyChanged(); } }
        public string CourrielTravail { get => courrielTravail; set { courrielTravail = value; OnProperyChanged(); } }
        public string TelephonePersonnel { get => telephonePersonnel; set { telephonePersonnel = value; OnProperyChanged(); } }
        public string TelephoneTravail { get => telephoneTravail; set { telephoneTravail = value; OnProperyChanged(); } }

        public ICommand EditContactCmd { get; set; }
        //Recupere le contact utiliser avec l'interface IQueryAttributable
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string id = HttpUtility.UrlDecode(query["Id"]);
            LoadContact(id);
        }
        //Charge le contact method utiliser avec l'interface IQueryAttributable
        void LoadContact(string id)
        {
            Contact contact = ContactDbContext.GetContacts().Find(c => c.Id == int.Parse(id));
            this.Id = contact.Id;
            this.Prenom = contact.Prenom;
            this.Nom = contact.Nom;
            this.Initial = contact.Initial;
            this.Photo = contact.Photo;
            this.TelephonePersonnel = contact.TelephonePersonnel;
            this.TelephoneTravail = contact.TelephoneTravail;
            this.CourrielPersonnel = contact.CourrielPersonnel;
            this.CourrielTravail = contact.CourrielTravail;
        }

        public DetailsContactViewModel()
        {
            EditContactCmd = new Command(EditContact);
        }

        private async void EditContact()
        {
            Routing.RegisterRoute(nameof(UpdateContactView), typeof(UpdateContactView));
            await Shell.Current.GoToAsync($"{nameof(UpdateContactView)}?Id={this.Id}");
        }

        //Permet l'utilisation de PropertyChanged sans specifier la proprieter a changer
        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
