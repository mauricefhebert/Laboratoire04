using Laboratoire04.Data;
using Laboratoire04.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratoire04.ViewModels
{
    [QueryProperty(nameof(Id), "Id")]
    internal class DetailsContactViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Initial { get; set; }
        public string Photo { get; set; }
        public string CourrielPersonnel { get; set; }
        public string CourrielTravail { get; set; }
        public string TelephonePersonnel { get; set; }
        public string TelephoneTravail { get; set; }
        public ICommand EditCmd { get; set; }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string id = HttpUtility.UrlDecode(query["Id"]);
            LoadContact(id);
        }

        void LoadContact(string id)
        {
            Contact contact = ContactDbContext.GetContacts().Find(c => c.Id == int.Parse(id));
            this.Prenom = contact.Prenom;
            this.Nom = contact.Nom;
            this.Initial = contact.Initial;
            this.Photo = contact.Photo;
            this.CourrielPersonnel = contact.CourrielPersonnel;
            this.CourrielTravail = contact.CourrielTravail;
            this.TelephonePersonnel = contact.TelephonePersonnel;
            this.TelephoneTravail = contact.TelephoneTravail;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Prenom)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nom)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Initial)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Photo)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourrielPersonnel)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourrielTravail)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TelephonePersonnel)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TelephoneTravail)));
        }

        public DetailsContactViewModel()
        {
            EditCmd = new Command(EditContact);
        }

        public void EditContact()
        {
            
        }
    }
}
