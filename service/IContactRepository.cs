using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPaper.model;

namespace ExamPaper.service
{
    public interface IContactRepository
    {
         void AddContact(Contact contact);
        void FindContactByName(string name);
         Hashtable GetAllContacts();
    }
}