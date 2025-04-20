namespace RegisterationTask.Mapping;

public class MappingConfiguartions : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //RegisterDto to ApplicationUser
        config.NewConfig<RegisterDto, ApplicationUser>()
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber);
        //ContactRequest to Contact
        config.NewConfig<ContactRequest, Contact>()
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.BirthDay, src => src.BirthDay);
    }

}
