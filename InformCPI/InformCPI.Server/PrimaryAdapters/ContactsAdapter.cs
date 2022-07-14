using InformCPI.Server.BusinessLogic.Interfaces;
using InformCPI.Server.IncomingPorts;
using InformCPI.Server.Models;

namespace InformCPI.Server.PrimaryAdapters
{
    public class ContactsAdapter : IGetContacts, IEditContacts
    {
        private readonly IEditContactsLogic editContacts;
        private readonly IGetContactsLogic getContacts;
        public ContactsAdapter(IEditContactsLogic edit, IGetContactsLogic get)
        {
            editContacts = edit;
            getContacts = get;
        }
        public void AddContact(Contact newContact)
        {
            editContacts.AddContact(newContact);
        }

        public void EditContact(Contact updatedContact)
        {
            editContacts.EditContact(updatedContact);
        }

        public List<Contact> GetAllContacts()
        {
            return getContacts.GetAllContacts();
        }

        public Contact GetContact(int id)
        {
            return getContacts.GetContact(id);
        }
    }
}
