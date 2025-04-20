namespace RegisterationTask.Dto;

public record ContactResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateOnly BirthDay
);
