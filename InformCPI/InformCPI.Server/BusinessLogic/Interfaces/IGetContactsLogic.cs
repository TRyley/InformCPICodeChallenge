using InformCPI.Server.Models;

namespace InformCPI.Server.BusinessLogic.Interfaces
{
    public interface IGetContactsLogic
    {
        public List<Contact> GetAllContacts();
        public Contact GetContact(int id);
    }
}
