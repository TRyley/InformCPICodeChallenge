
using InformCPI.Server.BusinessLogic;
using InformCPI.Server.BusinessLogic.Interfaces;
using InformCPI.Server.Models;
using InformCPI.Server.OutgoingPorts;
using InformCPI.Server.PrimaryAdapters;
using Moq;

namespace InformCPI.Server.Test
{
    [TestClass]
    public class GetContactsLogicTests
    {
        private  GetContactsLogic getContactsLogic;

        private Mock<IDatabaseReader> readerMock;

        private Contact newContact = new Contact(1);
        private Contact updatedContact = new Contact(4);

        [TestInitialize]
        public void Setup()
        {
            readerMock = new Mock<IDatabaseReader>();
            getContactsLogic = new GetContactsLogic(readerMock.Object);
        }

        [TestMethod]
        public void GetAllContacts_ShouldCallCorrectMethodOnWriter()
        {
            getContactsLogic.GetAllContacts();

            readerMock.Verify(x => x.GetAllContacts());
        }

        [DataTestMethod]
        [DataRow(0, DisplayName = "first contact")]
        [DataRow(4, DisplayName = "middle contact")]
        [DataRow(9, DisplayName = "last contact")]
        public void GetContact_ShouldCallCorrectMethodOnWriter(int id)
        {
            getContactsLogic.GetContact(id);

            readerMock.Verify(x => x.GetContact(id));
        }
    }
}