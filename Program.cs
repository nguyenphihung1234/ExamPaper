using System;
using ExamPaper.model;
using ExamPaper.service;
using ExamPaper.controller;

namespace ExamPaper
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;database=book_management;user=root;password=";

            // Create an instance of ContactService and ContactController
            IContactRepository contactService = new ContactService(connectionString);
            ContactController contactController = new ContactController(contactService);

            while (true)
            {
                Console.WriteLine("Contact Manager");
                Console.WriteLine("1. Add new contact");
                Console.WriteLine("2. Find contact by name");
                Console.WriteLine("3. Display all contacts");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter phone: ");
                        double phone = Convert.ToDouble(Console.ReadLine());
                        Contact newContact = new Contact { Name = name, Phone = phone };
                        contactController.AddContact(newContact);
                        Console.WriteLine("Contact added successfully!");
                        break;
                    case 2:
                        Console.WriteLine("Enter name to search: ");
                        string searchName = Console.ReadLine();
                        contactController.FindContactByName(searchName);
                        break;
                    case 3:
                        List<Contact> contacts = contactController.GetAllContacts();
                        Console.WriteLine("List of all contacts:");
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear(); // Clear console for better user experience
            }
        }
    }
}
