namespace RegisterationTask.Dto;

public record ContactRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateOnly BirthDay
);
