using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratoire04.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Initital { get; set; }
        public string Photo { get; set; }
        public string CourrielPersonnel { get; set; }
        public string CourrielTravail { get; set; }
        public string TelephonePersonnel { get; set; }
        public string TelephoneTravail { get; set; }
    }
}
