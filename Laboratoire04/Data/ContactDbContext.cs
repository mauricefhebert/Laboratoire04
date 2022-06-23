using Laboratoire04.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Laboratoire04.Data
{
    internal class ContactDbContext
    {
        //Retourn une liste de tous les contact dans la base de données
        public static List<Contact> GetContacts()
        {
            //Crée la liste de contact
            List<Contact> contacts = new List<Contact>();
            
            //Crée la connection et fait la lecture des données
            using (SQLiteConnection cn = new SQLiteConnection(App.DatabaseLocation))
            {
                cn.CreateTable<Contact>();
                contacts = cn.Table<Contact>().ToList();
            }

            //Retourn la liste de contact
            return contacts;
        }

        public static void AddContact(Contact contact)
        {

            //Create a new connection to the database the constructor take the Database location that we defined in the App.cs
            using (SQLiteConnection cn = new SQLiteConnection(App.DatabaseLocation))
            {
                //Create a new table of the type of the model's
                cn.CreateTable<Contact>();

                //Insert into the database the parameter is the object we want to insert
                int rowsAffected = cn.Insert(contact);

                //Notify the user of success or failure
                if (rowsAffected > 0)
                    Application.Current.MainPage.DisplayAlert("Success", "Le contact à été ajouter avec succes", "Ok");
                else
                    Application.Current.MainPage.DisplayAlert("Failure", "Erreur lors de l'ajout du contact", "Ok");
            }
        }

        // Cette method est seulement utiliser pour remplir la base de données si elle est vide
        public static void SeedDatabase(Contact contact)
        {

            //Create a new connection to the database the constructor take the Database location that we defined in the App.cs
            using (SQLiteConnection cn = new SQLiteConnection(App.DatabaseLocation))
            {
                //Create a new table of the type of the model's
                cn.CreateTable<Contact>();

                //Insert into the database the parameter is the object we want to insert
                cn.Insert(contact);
            }
        }
    }
}
