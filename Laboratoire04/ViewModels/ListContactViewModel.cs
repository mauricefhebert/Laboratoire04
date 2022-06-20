using Laboratoire04.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Laboratoire04.Models;

namespace Laboratoire04.ViewModels
{
    internal class ListContactViewModel
    {
        public List<Contact> contacts
        {
            get { return ContactDbContext.GetContacts(); }
        }
    }
}
