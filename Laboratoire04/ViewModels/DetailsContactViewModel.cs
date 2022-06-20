﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Laboratoire04.ViewModels
{
    internal class DetailsContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _prenom;
        string _nom;
        string _initital;
        string _photo;
        string _courrielPersonnel;
        string _courrielTravail;
        string _telephonePersonnel;
        string _telephoneTravail;
        public int Id { get; set; }
        public string Prenom 
        { 
            get { return _prenom; }
            set
            { 
                _prenom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prenom"));
            }
        }
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nom"));
            }
        }
        public string Initital
        {
            get { return _initital; }
            set
            {
                _initital = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Initial"));
            }
        }
        public string Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Photo"));
            }
        }
        public string CourrielPersonnel
        {
            get { return _courrielPersonnel; }
            set
            {
                _courrielPersonnel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourrielPersonnel"));
            }
        }
        public string CourrielTravail
        {
            get { return _courrielTravail; }
            set
            {
                _courrielTravail = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourrielTravail"));
            }
        }
        public string TelephonePersonnel
        {
            get { return _telephonePersonnel; }
            set
            {
                _telephonePersonnel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TelephonePersonnel"));
            }
        }
        public string TelephoneTravail
        {
            get { return _telephoneTravail; }
            set
            {
                _telephoneTravail = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TelephoneTravail"));
            }
        }
        public DetailsContactViewModel()
        {

        }

        
    }
}
