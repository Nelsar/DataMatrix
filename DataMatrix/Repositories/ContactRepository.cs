using DataMatrix.Models;
using Microsoft.EntityFrameworkCore;

namespace DataMatrix.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        public ContactRepository(DatabaseContext database)
        {
            _database = database;    
        }

        private readonly DatabaseContext _database;
        public async Task<int> Add(Contact data)
        {
            Contact contact = new Contact();
            contact.Id = data.Id;
            contact.Name = data.Name;
            contact.Email = data.Email;
            contact.Phone = data.Phone;
            contact.Address = data.Address;
            contact.FirstName = data.FirstName;
            contact.LastName = data.LastName;
            await _database.AddAsync(contact);
            return await _database.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var getContact = await _database.Contacts.FindAsync(Id);
            if(getContact != null)
            {
                _database.Contacts.Remove(getContact);
                return await _database.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Contact>> GetAll()
        {
            return _database.Contacts.ToList();
        }

        public async Task<int> Update(Contact data)
        {
            var getContact = await _database.Contacts.FindAsync(data.Id);
            if (getContact != null)
            {
                getContact.FirstName = data.FirstName;
                getContact.LastName = data.LastName;
                getContact.Address = data.Address;
                getContact.Email = data.Email;
                getContact.Phone = data.Phone;

                _database.Contacts.Update(getContact);
                return await _database.SaveChangesAsync();
            }
            return 0;
        }
    }
}
