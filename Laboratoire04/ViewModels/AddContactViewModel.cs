using Laboratoire04.Data;
using Laboratoire04.Models;
using Laboratoire04.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Contact = Laboratoire04.Models.Contact;

namespace Laboratoire04.ViewModels
{
    internal class AddContactViewModel : INotifyPropertyChanged
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
        public ICommand AjouterContactCmd { get; private set; }
        public ICommand UploadImageCmd { get; set; }
        public int Id { get => id; set { id = value; OnProperyChanged(); } }
        public string Prenom { get => prenom; set { prenom = value; OnProperyChanged(); } }
        public string Nom { get => nom; set { nom = value; OnProperyChanged(); } }
        public string Initial { get => initial; set { initial = value; OnProperyChanged(); } }
        public string Photo { get => photo; set { photo = value; OnProperyChanged(); } }
        public string CourrielPersonnel { get => courrielPersonnel; set { courrielPersonnel = value; OnProperyChanged(); } }
        public string CourrielTravail { get => courrielTravail; set { courrielTravail = value; OnProperyChanged(); } }
        public string TelephonePersonnel { get => telephonePersonnel; set { telephonePersonnel = value; OnProperyChanged(); } }
        public string TelephoneTravail { get => telephoneTravail; set { telephoneTravail = value; OnProperyChanged();} }

        public AddContactViewModel()
        {
            this.AjouterContactCmd = new Command(AddContact);
            this.UploadImageCmd = new Command(ImagePicker);
        }

        private async void ImagePicker(object obj)
        {
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Choisir une image"
            });

            if (pickResult != null)
            {
                var stream = pickResult.FullPath;
                this.Photo = stream;
            }
        }

        public void AddContact()
        {

            Contact contact = new Contact()
            {
                Prenom = this.Prenom,
                Nom = this.Nom,
                Initial = this.Initial,
                Photo = Photo == null ? @"https://placeimg.com/150/150/people" : this.Photo.ToString(),
                CourrielPersonnel = this.CourrielPersonnel,
                CourrielTravail = this.CourrielTravail,
                TelephonePersonnel = this.TelephonePersonnel,
                TelephoneTravail = this.TelephoneTravail,
            };

            ContactDbContext.AddContact(contact);
        }

        //Permet l'utilisation de PropertyChanged sans specifier la proprieter a changer
        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
