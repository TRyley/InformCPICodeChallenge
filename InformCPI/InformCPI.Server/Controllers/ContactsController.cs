using InformCPI.Server.IncomingPorts;
using InformCPI.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace InformCPI.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IEditContacts editContacts;
        private readonly IGetContacts getContacts;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger, IEditContacts edit, IGetContacts get)
        {
            _logger = logger;
            editContacts = edit;
            getContacts = get;
        }

        //GetAll
        [HttpGet]
        [Route("GetAll")]
        public List<Contact> GetAll()
        {
            _logger.LogInformation("Get All Contacts Called");
            return getContacts.GetAllContacts();
        }

        //GetOne
        [HttpGet]
        [Route("Get/{id}")]
        public Contact GetOne([FromQuery]int id)
        {
            _logger.LogInformation("Get Contact Called");
            return getContacts.GetContact(id);
        }
        //AddContact
        //GetOne
        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] Contact newContact)
        {
            _logger.LogInformation("Add new contact Called");
            editContacts.AddContact(newContact);
        }
        //EditContact
        [HttpPut]
        [Route("Edit")]
        public void Edit([FromBody] Contact updatedContact)
        {
            _logger.LogInformation("update contact Called");
            editContacts.EditContact(updatedContact);
        }
    }
}