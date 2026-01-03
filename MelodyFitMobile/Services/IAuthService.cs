using MelodyFitMobile.Models;

namespace MelodyFitMobile.Services
{
    public interface IAuthService
    {
        Task<Guid> RegisterAsync(RegisterUserRequest request);
    }
}
