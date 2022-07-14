using InformCPI.Server.BusinessLogic.Interfaces;
using InformCPI.Server.Models;
using InformCPI.Server.OutgoingPorts;

namespace InformCPI.Server.BusinessLogic
{
    public class EditContactsLogic : IEditContactsLogic
    {
        private readonly IDatabaseWriter databaseWriter;
        public EditContactsLogic(IDatabaseWriter writer)
        {
            databaseWriter = writer;
        }
        public void AddContact(Contact newContact)
        {
            databaseWriter.AddNewContactToDatabase(newContact);
        }

        public void EditContact(Contact updatedContact)
        {
            databaseWriter.UpdateExistingContact(updatedContact);
        }
    }
}
