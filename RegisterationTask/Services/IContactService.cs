
namespace RegisterationTask.Services;

public interface IContactService
{
    Task<PaginatedData<ContactResponse>> GetAllContactsAsync(RequestedFilters filters, CancellationToken cancellationToken = default);
    Task<Result<ContactResponse>> GetContactByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result> CreateContactAsync(ContactRequest request, CancellationToken cancellationToken = default);
}
