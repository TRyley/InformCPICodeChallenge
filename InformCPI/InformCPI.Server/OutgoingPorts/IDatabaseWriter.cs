using InformCPI.Server.Models;

namespace InformCPI.Server.OutgoingPorts
{
    public interface IDatabaseWriter
    {
        void AddNewContactToDatabase(Contact newContact);
        void UpdateExistingContact(Contact updatedContact);
    }
}
