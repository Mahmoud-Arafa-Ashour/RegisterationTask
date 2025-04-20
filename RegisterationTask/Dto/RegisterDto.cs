namespace RegisterationTask.Dto;

public record RegisterDto(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber
);
