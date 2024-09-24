using AddressBookAPI.DTOs;
using AddressBookAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace AddressBookAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [FeatureGate(MyFeatureFlags.GetContacsEndpoint)]
        [HttpGet]
        public async Task<IActionResult> AllContacts()
        {
            return Ok(await _contactService.GetAllContacts());
        }

        [FeatureGate(MyFeatureFlags.GetContactByIdEndpoint)]
        [HttpGet("{id}")]
        public async Task<IActionResult> ContactById(int id)
        {
            var contact = await _contactService.GetContactById(id);
            if (contact == null)
            {
                return BadRequest("Can not find this contact");
            }

            return Ok(contact);
        }

        [FeatureGate(MyFeatureFlags.CreateContactEndpoint)]
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactDTO newContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contact = await _contactService.CreateContact(newContact);

            if (contact == null)
            {
                return BadRequest("Can not find this contact to create");
            }

            return Ok(contact);
        }

        [FeatureGate(MyFeatureFlags.UpdateContactEndpoint)]
        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDTO updateContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contact = await _contactService.UpdateContact(updateContact);
            if (contact == null)
            {
                return BadRequest("Can not find this contact to update");
            }

            return Ok(contact);
        }

        [FeatureGate(MyFeatureFlags.DeleteContactEndpoint)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactService.DeleteContact(id);
            if (result == false)
            {
                return BadRequest("Can not find this contact to delete");
            }

            return Ok("The contact has been deleted");
        }
    }
}
