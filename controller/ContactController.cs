using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPaper.model;
using ExamPaper.service;

namespace ExamPaper.controller
{
    public class ContactController
    {
        private  IContactRepository contactService;

        public ContactController(IContactRepository contactService)
        {
            this.contactService = contactService;
        }

        public void AddContact(Contact contact)
        {
            contactService.AddContact(contact);
        }

        public void FindContactByName(string name)
        {
            contactService.FindContactByName(name);
        }

         public List<Contact> GetAllContacts(){
            return contactService.GetAllContacts();
        }
    }
    }
