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

        private Contact contact;
        Contact Contact 
        { 
            get { return contact; } 
            set
            {
                contact = value;
                OnProperyChanged();
            }
        }

        private int id;
        public int Id 
        { 
            get { return id; } 
            set
            {
                id = value;
                OnProperyChanged();
            }
        }

        private string prenom;
        public string Prenom 
        { 
            get { return prenom; }
            set
            {
                prenom = value;
                OnProperyChanged();
            }
        }
        private string nom;
        public string Nom 
        { 
            get { return nom; }
            set
            {
                nom = value;
                OnProperyChanged();
            }
        }
        private string initial;
        public string Initial 
        {   get { return initial; }
            set
            {
                initial = value;
                OnProperyChanged();
            }
        }

        private string photo;
        public string Photo
        {
            get { return photo; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    photo = @"https://placebear.com/640/360";
                }
                else
                {
                photo = value;
                }
                OnProperyChanged();
            }
        }
        private string telephonePersonnel;
        public string TelephonePersonnel
        {
            get { return telephonePersonnel; }
            set
            {
                telephonePersonnel = value;
                OnProperyChanged();
            }
        }
        private string telephoneTravail;
        public string TelephoneTravail
        {
            get { return telephoneTravail; }
            set
            {
                telephoneTravail = value;
                OnProperyChanged();
            }
        }
        private string courrielPersonnel;
        public string CourrielPersonnel
        {
            get { return courrielPersonnel; }
            set
            {
                courrielPersonnel = value;
                OnProperyChanged();
            }
        }
        private string courrielTravail;
        public string CourrielTravail
        {
            get { return courrielTravail; }
            set
            {
                courrielTravail = value;
                OnProperyChanged();
            }
        }

        public ICommand EditContactCmd { get; set; }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string id = HttpUtility.UrlDecode(query["Id"]);
            LoadContact(id);
        }

        void LoadContact(string id)
        {
            contact = ContactDbContext.GetContacts().Find(c => c.Id == int.Parse(id));
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
            //need contact id
            Routing.RegisterRoute(nameof(UpdateContactView), typeof(UpdateContactView));
            await Shell.Current.GoToAsync($"{nameof(UpdateContactView)}?Id={contact.Id}");
        }

        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
