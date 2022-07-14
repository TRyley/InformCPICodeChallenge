using InformCPI.Server.Models;

namespace InformCPI.Server.BusinessLogic.Interfaces
{
    public interface IEditContactsLogic
    {
        void AddContact(Contact newContact);
        void EditContact(Contact updatedContact);
    }
}
