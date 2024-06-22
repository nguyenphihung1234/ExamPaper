using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPaper.model;
using MySql.Data.MySqlClient;

namespace ExamPaper.service
{
    public class ContactService : IContactRepository
    {
         private readonly string connectionString;

        public ContactService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddContact(Contact contact)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Contacts (name, phone) VALUES (@Name, @Phone)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.ExecuteNonQuery();
            }
        }

        public void FindContactByName(string name)
        {
             using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Contacts WHERE name = @Name";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($" Name: {reader.GetString("name")}, Phone: {reader.GetDouble("phone")}");
                    }
                }
            }
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Contacts";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact
                        {
                            Name = reader.GetString("name"),
                            Phone = reader.GetDouble("phone")
                        };
                        contacts.Add(contact);
                    }
                }
            }
            return contacts;
        }
    }
        }
    


