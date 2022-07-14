using InformCPI.Server.Models;

namespace InformCPI.Server.IncomingPorts
{
    public interface IEditContacts
    {
        void AddContact(Contact newContact);
        void EditContact(Contact updatedContact);
    }
}
