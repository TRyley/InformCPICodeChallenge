
using InformCPI.Server.BusinessLogic.Interfaces;
using InformCPI.Server.Models;
using InformCPI.Server.PrimaryAdapters;
using Moq;

namespace InformCPI.Server.Test
{
    [TestClass]
    public class ContactsAdapterTests
    {
        private  ContactsAdapter contactsAdapter;
        private List<Contact> testContacts;

        private Mock<IGetContactsLogic> getContactsMock;
        private Mock<IEditContactsLogic> editContactsMock;

        [TestInitialize]
        public void Setup()
        {
            testContacts = SetTestContacts();

            getContactsMock = new Mock<IGetContactsLogic>();
            getContactsMock.Setup(x => x.GetAllContacts()).Returns(testContacts);

            editContactsMock = new Mock<IEditContactsLogic>();

            contactsAdapter = new ContactsAdapter(editContactsMock.Object, getContactsMock.Object);
        }

        [TestMethod]
        public void GetAllContacts_ShouldReturnListOfContacts()
        {
            var actualList = contactsAdapter.GetAllContacts();

            CollectionAssert.AreEqual(testContacts, actualList);
        }

        [TestMethod]
        public void GetAllContacts_ShouldCallIGetContactsLogicMethod()
        {
            var actualList = contactsAdapter.GetAllContacts();

            getContactsMock.Verify(x => x.GetAllContacts());
        }

        [DataTestMethod]
        [DataRow(0, DisplayName = "Get first contact")]
        [DataRow(9, DisplayName = "Get last contact")]
        [DataRow(4, DisplayName = "Get middle contact")]
        public void GetContact_ShouldReturnSingleContact(int id)
        {
            var expected = testContacts.First(x => x.Id == id);

            getContactsMock.Setup(x => x.GetContact(id)).Returns(expected);

            var actual = contactsAdapter.GetContact(id);

            Assert.AreEqual(expected.Id, actual.Id);
        }

        [DataTestMethod]
        [DataRow(0, DisplayName = "Get first contact")]
        [DataRow(9, DisplayName = "Get last contact")]
        [DataRow(4, DisplayName = "Get middle contact")]
        public void GetContact_ShouldCallIGetContactsLogicMethod(int id)
        {
            var actualList = contactsAdapter.GetContact(id);

            getContactsMock.Verify(x => x.GetContact(id));
        }

        [TestMethod]
        public void EditContact_ShouldCallIEditContactsLogicMethod()
        {
            Contact updatedContact = new Contact(1);

            contactsAdapter.EditContact(updatedContact);

            editContactsMock.Verify(x => x.EditContact(updatedContact));
        }

        [TestMethod]
        public void AddContact_ShouldCallIEditContactsLogicMethod()
        {
            Contact updatedContact = new Contact(1);

            contactsAdapter.AddContact(updatedContact);

            editContactsMock.Verify(x => x.AddContact(updatedContact));
        }

        private List<Contact> SetTestContacts()
        {
            List<Contact> list = new List<Contact>();

            for(var i = 0; i < 10; i++)
            {
                Contact newContact = new Contact(
                        i,
                        $"name_{i}",
                        $"address_{i}",
                        $"email_{i}",
                        $"phoneNum_{i}"
                    );
                list.Add(newContact);
            }

            return list;
        }
    }
}