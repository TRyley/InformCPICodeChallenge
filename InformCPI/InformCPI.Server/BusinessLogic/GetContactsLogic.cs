using InformCPI.Server.BusinessLogic.Interfaces;
using InformCPI.Server.Models;
using InformCPI.Server.OutgoingPorts;

namespace InformCPI.Server.BusinessLogic
{
    public class GetContactsLogic : IGetContactsLogic
    {
        private readonly IDatabaseReader databaseReader;

        public GetContactsLogic(IDatabaseReader reader)
        {
            databaseReader = reader;
        }
        public List<Contact> GetAllContacts()
        {
            return databaseReader.GetAllContacts();
        }

        public Contact GetContact(int id)
        {
            return databaseReader.GetContact(id);
        }
    }
}
