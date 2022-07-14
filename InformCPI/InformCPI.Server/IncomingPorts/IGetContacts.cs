using InformCPI.Server.Models;

namespace InformCPI.Server.IncomingPorts
{
    public interface IGetContacts
    {
        List<Contact> GetAllContacts();

        Contact GetContact(int id);
    }
}
