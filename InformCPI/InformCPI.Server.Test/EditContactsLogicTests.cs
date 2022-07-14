
using InformCPI.Server.BusinessLogic;
using InformCPI.Server.BusinessLogic.Interfaces;
using InformCPI.Server.Models;
using InformCPI.Server.OutgoingPorts;
using InformCPI.Server.PrimaryAdapters;
using Moq;

namespace InformCPI.Server.Test
{
    [TestClass]
    public class EditContactsLogicTests
    {
        private  EditContactsLogic editContactsLogic;

        private Mock<IDatabaseWriter> writerMock;

        private Contact newContact = new Contact(1);
        private Contact updatedContact = new Contact(4);

        [TestInitialize]
        public void Setup()
        {
            writerMock = new Mock<IDatabaseWriter>();
            editContactsLogic = new EditContactsLogic(writerMock.Object);
        }

        [TestMethod]
        public void UpdateContact_ShouldCallCorrectMethodOnWriter()
        {
            editContactsLogic.EditContact(updatedContact);

            writerMock.Verify(x => x.UpdateExistingContact(It.Is<Contact>(x => x.Id == updatedContact.Id)));
        }

        [TestMethod]
        public void AddContact_ShouldCallCorrectMethodOnWriter()
        {
            editContactsLogic.AddContact(newContact);

            writerMock.Verify(x => x.AddNewContactToDatabase(It.Is<Contact>(x => x.Id == newContact.Id)));
        }
    }
}