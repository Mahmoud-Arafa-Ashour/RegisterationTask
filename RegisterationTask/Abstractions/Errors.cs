namespace RegisterationTask.Abstractions;

public static class Errors
{
    public class UserErrors
    {
        public static readonly Error InvalidCredentionals =
            new Error("User.InvalidCredentionals", "Invalid Username or password", StatusCodes.Status401Unauthorized);
        public static readonly Error DuplicateEmail =
            new Error("User.DuplicatedEmail", "Another User with the same Email", StatusCodes.Status409Conflict);
        public static readonly Error NotFound =
            new Error("User.NotFound", "This Id is not valid", StatusCodes.Status404NotFound);
        public static readonly Error InvalidCode =
            new Error("User.InvalidCode", "InvalidCode", StatusCodes.Status400BadRequest);
    }
    public class ContactErrors
    {
        public static readonly Error DuplicateContact =
           new Error("Contact.DuplicatedContact", "Another Contact with the same Email", StatusCodes.Status409Conflict);
        public static readonly Error NotFound =
            new Error("Contact.NotFound", "No Contact with this id", StatusCodes.Status404NotFound);
        public static readonly Error Empty =
            new Error("Contact.Empty", "you can not send empty contact", StatusCodes.Status400BadRequest);
    }
}
