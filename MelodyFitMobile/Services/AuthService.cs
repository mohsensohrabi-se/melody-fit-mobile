using MelodyFitMobile.Constants;
using MelodyFitMobile.Models;
using System.Net.Http.Json;


namespace MelodyFitMobile.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid> RegisterAsync(RegisterUserRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(
                ApiEndpoints.Register,
                request);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"registration failed: {error}");
            }
            var userId = await response.Content.ReadFromJsonAsync<Guid>();
            return userId;
        }
    }
}
