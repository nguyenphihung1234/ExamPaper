using System.Collections;
using ExamPaper.model;
using ExamPaper.service;

namespace ExamPaper.controller
{
    public class ContactController
    {
        private readonly IContactRepository contactService;

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

        public Hashtable GetAllContacts()
        {
            return contactService.GetAllContacts();
        }
    }
}
