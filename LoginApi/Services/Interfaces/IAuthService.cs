using LoginApi.Models.GetProfile;
using LoginApi.Models.GetProfileRequest;
using LoginApi.Models.Request;
using LoginApi.Models.Response;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request);

    Task<RegisterResponse> RegisterAsync(RegisterRequest request);

    Task<GetProfileResponse?> GetProfileAsync(GetProfileRequest request);
    
}