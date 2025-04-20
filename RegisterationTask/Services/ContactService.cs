
using static RegisterationTask.Abstractions.Errors;

namespace RegisterationTask.Services;

public class ContactService(ApplicationDBContext applicationDBContext , ILogger<ContactResponse> logger) : IContactService
{
    private readonly ApplicationDBContext _DBContext = applicationDBContext;
    private readonly ILogger<ContactResponse> _logger = logger;

    public async Task<Result> CreateContactAsync(ContactRequest request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            return Result.Failure(ContactErrors.Empty);
        }
        var isExistingEmail = await _DBContext.Contacts.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (isExistingEmail)
        {
            return Result.Failure(ContactErrors.DuplicateContact);
        }
        var contact = request.Adapt<Contact>();
        _DBContext.Contacts.Add(contact);
        await _DBContext.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<PaginatedData<ContactResponse>> GetAllContactsAsync(RequestedFilters filters, CancellationToken cancellationToken = default)
    {
        var result = _DBContext.Contacts.ProjectToType<ContactResponse>();
        var PaginatedData = await PaginatedData<ContactResponse>.CreateAsync(result, filters.PageNumber, filters.PageSize, cancellationToken);
        return PaginatedData;
    }

    public async Task<Result<ContactResponse>> GetContactByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var contact = await _DBContext.Contacts
            .Where(x => x.Id == id)
            .ProjectToType<ContactResponse>()
            .FirstOrDefaultAsync(cancellationToken);

        if (contact == null)
        {
            return Result.Failure<ContactResponse>(ContactErrors.NotFound);
        }

        return Result.Success(contact);
    }

}
