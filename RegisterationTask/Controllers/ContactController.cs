using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterationTask.Services;

namespace RegisterationTask.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        private readonly IContactService _contactService = contactService;

        [HttpGet]
        public async Task<IActionResult> GetAll(RequestedFilters filters, CancellationToken cancellationToken = default)
        {
            return Ok(await _contactService.GetAllContactsAsync(filters , cancellationToken));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken = default)
        {
            var result = await _contactService.GetContactByIdAsync(Id, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] ContactRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _contactService.CreateContactAsync(request, cancellationToken);
            return result.IsSuccess ? Created() : result.ToProblem();
        }
    }
}
