using InformCPI.Server.Models;

namespace InformCPI.Server.OutgoingPorts
{
    public interface IDatabaseReader
    {
        List<Contact> GetAllContacts();
        Contact GetContact(int id);
    }
}
