using Laboratoire04.Data;
using Laboratoire04.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratoire04.ViewModels
{
    internal class AddContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AjouterContactCmd { get; private set; }
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Initital { get; set; }
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
        public string CourrielPersonnel { get; set; }
        public string CourrielTravail { get; set; }
        public string TelephonePersonnel { get; set; }
        public string TelephoneTravail { get; set; }

        public Contact contact = new Contact();
        public AddContactViewModel()
        {
            this.AjouterContactCmd = new Command(AddContact);
        }

        public async void AddContact()
        {
            Contact contact = new Contact()
            {
                Prenom = this.Prenom, 
                Nom = this.Nom, 
                Initial = this.Initital, 
                Photo = this.Photo, 
                CourrielPersonnel = this.CourrielPersonnel, 
                CourrielTravail = this.CourrielTravail,
                TelephonePersonnel = this.TelephonePersonnel,
                TelephoneTravail = this.TelephoneTravail,
            };

            ContactDbContext.AddContact(contact);
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(contact)));
            await Shell.Current.GoToAsync("//ListContactView");
            
        }
        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
