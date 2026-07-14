using LoginApi.Models.Request;
using LoginApi.Models.Response;
using LoginApi.Services.Interfaces;
using LoginApi.Common.ResponseCode;
using LoginApi.Models.Entities;
using LoginApi.Models.GetProfile;
using LoginApi.Models.GetProfileRequest;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<GetProfileResponse?> GetProfileAsync(GetProfileRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            return new GetProfileResponse
            {
                StatusCode = ResponseCode.DATA_NOT_FOUND,
                StatusText = "User name not found",
                UserId = 0,
                Username = "",
            };
        }

        return new GetProfileResponse
        {
            StatusCode = ResponseCode.SUCCESS,
            StatusText = "Load profile successfully",
            UserId = user.Id,
            Username = user.Username,
        };
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);

        if (user == null)
        {
            return new LoginResponse
            {
                StatusCode = ResponseCode.DATA_NOT_FOUND,
                StatusText = "User name not found",
                UserId = 0,
                Username = "",
                Token = ""
            };
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return new LoginResponse
            {
                StatusCode = ResponseCode.PASSWORD_INCORRECT,
                StatusText = "PASSWORD INCORRECT",
                UserId = 0,
                Username = "",
                Token = ""
            };
        }

        return new LoginResponse
        {
            StatusCode = ResponseCode.SUCCESS,
            StatusText = "Login successfully",
            UserId = user.Id,
            Username = user.Username,
            Token = _jwtService.GenerateToken(user)
        };
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _userRepository.ExistsAsync(request.Username))
        {
            return new RegisterResponse()
            {
                StatusCode = ResponseCode.SYSTEM_ERROR,
                StatusText = "Username already exists."
            };
        }


        var user = new User
        {
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreateDate = DateTime.Now
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return new RegisterResponse()
        {
            StatusCode = ResponseCode.SUCCESS,
            StatusText = "Register successfully."
        };
    }


}