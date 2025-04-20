namespace RegisterationTask.Services
{
    public interface IAuthServices
    {
        Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken);
        Task<Result<AuthResponse>> RegisterAsync(RegisterDto register, CancellationToken cancellationToken);
    }
}
