using Laboratoire04.Data;
using Laboratoire04.Models;
using Laboratoire04.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Contact = Laboratoire04.Models.Contact;

namespace Laboratoire04.ViewModels
{
    internal class UpdateContactViewModel : INotifyPropertyChanged, IQueryAttributable
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

        public ICommand UpdateContactCmd { get; set; }
        public ICommand SupprimerContactCmd { get; set; }
        public ICommand UploadImageCmd { get; set; }

        public UpdateContactViewModel()
        {
            UpdateContactCmd = new Command(UpdateContact);
            SupprimerContactCmd = new Command(SupprimerContact);
            this.UploadImageCmd = new Command(ImagePicker);
        }

        private async void SupprimerContact()
        {
            Contact contact = ContactDbContext.GetContacts().Find(c => c.Id == Id);
            var result = await Application.Current.MainPage.DisplayAlert("Confirmation", "Voulez-vous supprimer ce contact?", "Confirmer", "Annuler");
            if (result)
            {
                //Create a new connection to the database the constructor take the Database location that we defined in the App.cs
                using (SQLiteConnection cn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //Create a new table of the type of the model's
                    cn.CreateTable<Contact>();

                    //Insert into the database the parameter is the object we want to insert
                    int rowsAffected = cn.Delete(contact);

                    //Notify the user of success or failure
                    if (rowsAffected > 0)
                        await Application.Current.MainPage.DisplayAlert("Success", "Le contact à été supprimer", "Ok");
                    else
                        await Application.Current.MainPage.DisplayAlert("Failure", "Le contact n'a pu etre supprimer", "Ok");
                }
                await Shell.Current.GoToAsync($"///{nameof(ListContactView)}");
            }
        }

        private async void UpdateContact()
        {
            Contact contact = ContactDbContext.GetContacts().Find(c => c.Id == Id);
            contact.Prenom = this.Prenom;
            contact.Nom = this.Nom;
            contact.Initial = this.Initial;
            contact.Photo = this.Photo;
            contact.TelephonePersonnel = this.TelephonePersonnel;
            contact.TelephoneTravail = this.TelephoneTravail;
            contact.CourrielPersonnel = this.CourrielPersonnel;
            contact.CourrielTravail = this.CourrielTravail;

            var result = await Application.Current.MainPage.DisplayAlert("Confirmation", "Voulez-vous modifier ce contact?", "Confirmer", "Annuler");
            if (result)
            {
            //Create a new connection to the database the constructor take the Database location that we defined in the App.cs
            using (SQLiteConnection cn = new SQLiteConnection(App.DatabaseLocation))
            {
                //Create a new table of the type of the model's
                cn.CreateTable<Contact>();

                //Insert into the database the parameter is the object we want to insert
                int rowsAffected = cn.Update(contact);

                //Notify the user of success or failure
                if (rowsAffected > 0)
                    await Application.Current.MainPage.DisplayAlert("Success", "Le contact à été modifier avec success", "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert("Failure", "Le contact n'a pu etre modifier", "Ok");
                }
            await Shell.Current.Navigation.PopAsync();
            }
        }

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

        //Method pour ajouter une image avec les photo du telephone
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
        //Permet l'utilisation de PropertyChanged sans specifier la proprieter a changer
        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
