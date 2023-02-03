using API.Models;
using System.Text.Json;

namespace API.Data
{
    public class JsonFileRepository
    {
        // create a property of List of Contacts
        public List<Contact> Contacts { get; set; }

        // create a repository that reads contents inside contacts.json and stores it on Contacts property
        public JsonFileRepository()
        {
            // read the contents of contacts.json
            var json = File.ReadAllText("contacts.json");

            // deserialize the json into a list of contacts
            Contacts = JsonSerializer.Deserialize<List<Contact>>(json);
        }

        // CRUD operations

        // Create a method to get all contacts
        public IEnumerable<Contact> GetContacts()
        {
            return Contacts;
        }

        // Create a method to get a single contact given id
        public Contact GetContact(Guid id)
        {
            return Contacts.FirstOrDefault(c => c.Id == id);
        }

        // Create a method to add a new contact
        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        // Create a method to update a contact
        public void UpdateContact(Contact contact)
        {
            var index = Contacts.FindIndex(c => c.Id == contact.Id);
            Contacts[index] = contact;
        }

        // Create a method to delete a contact
        public void DeleteContact(Guid id)
        {
            var index = Contacts.FindIndex(c => c.Id == id);
            Contacts.RemoveAt(index);
        }

        // Create a method to save changes
        public void SaveChanges()
        {
            var json = JsonSerializer.Serialize(Contacts, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("contacts.json", json);
        }
    }
}
