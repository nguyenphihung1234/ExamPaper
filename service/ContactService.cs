using System;
using System.Collections;
using MySql.Data.MySqlClient;
using ExamPaper.model;

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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void FindContactByName(string name)
        {
            try
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
                            Console.WriteLine($"Name: {reader.GetString("name")}, Phone: {reader.GetDouble("phone")}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public Hashtable GetAllContacts()
        {
            Hashtable contacts = new Hashtable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Contacts";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString("name");
                            double phone = reader.GetDouble("phone");
                            
                            if (!contacts.ContainsKey(name))
                            {
                                contacts.Add(name, phone);
                            }
                            else
                            {
                                // Handle duplicate key according to your needs.
                                // Example: Skip duplicates
                                Console.WriteLine($"Duplicate key found: {name}. Skipping entry.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return contacts;
        }
    }
}
