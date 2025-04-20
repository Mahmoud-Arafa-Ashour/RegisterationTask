
using RegisterationTask.Authentication;
using static RegisterationTask.Abstractions.Errors;

namespace RegisterationTask.Services
{
    public class AuthServices(UserManager<ApplicationUser> userManager , IJwtProvider jwtProvider) : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user is null)
            {
                return Result.Failure<AuthResponse>(UserErrors.NotFound);
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid)
            {
                return Result.Failure<AuthResponse>(UserErrors.InvalidCredentionals);
            }
            var (token , expiresin) = _jwtProvider.GenerateToken(user);
            var AuthResponse = new AuthResponse(user.Id, user.Email!, user.FirstName, user.LastName, token, expiresin);
            return Result.Success(AuthResponse);
        }

        public async Task<Result<AuthResponse>> RegisterAsync(RegisterDto request, CancellationToken cancellationToken)
        {
            var existingEmail = await _userManager.Users.AnyAsync(x=>x.Email == request.Email , cancellationToken);
            if(existingEmail)
                return Result.Failure<AuthResponse>(UserErrors.DuplicateEmail);

            var user = request.Adapt<ApplicationUser>();
            user.UserName = request.Email;

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
            var (token, expiresIn) = _jwtProvider.GenerateToken(user);
            var authResponse = new AuthResponse(user.Id, user.Email!, user.FirstName, user.LastName, token, expiresIn);
            return Result.Success(authResponse);
            }

            var error = result.Errors.First();
            return Result.Failure<AuthResponse>(new Error(error!.Code, error.Description, StatusCodes.Status400BadRequest));
        }

    }
}
