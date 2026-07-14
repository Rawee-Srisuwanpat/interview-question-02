using LoginApi.Models.Request;
using LoginApi.Models.Response;
using LoginApi.Common.ResponseCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LoginApi.Models.GetProfileRequest;
using LoginApi.Models.GetProfile;

namespace LoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Register User
        /// </summary>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                            .Where(x => x.Value?.Errors.Count > 0)
                            .SelectMany(x => x.Value!.Errors)
                            .Select(x => x.ErrorMessage)
                            .ToList();

                return BadRequest(new RegisterResponse()
                {
                    StatusCode = ResponseCode.SYSTEM_ERROR,
                    StatusText = string.Join(", ", errors)
                });

            }

            var result = await _authService.RegisterAsync(request);

            if (result == null)
            {
                return BadRequest(new RegisterResponse()
                {
                    StatusCode =  ResponseCode.SYSTEM_ERROR,
                    StatusText = "Register data is incorrect."
                });
            }

            return Ok(new RegisterResponse()
            {
                StatusCode = result.StatusCode,
                StatusText = result.StatusText
            });
        }

        /// <summary>
        /// Login
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            if (!ModelState.IsValid) {

                 var errors = ModelState
                            .Where(x => x.Value?.Errors.Count > 0)
                            .SelectMany(x => x.Value!.Errors)
                            .Select(x => x.ErrorMessage)
                            .ToList();

                return BadRequest(new LoginResponse()
                {
                    StatusCode = ResponseCode.SYSTEM_ERROR,
                    StatusText = string.Join(", ", errors)
                });
            }

            var result = await _authService.LoginAsync(request);

            if (result == null)
            {
                return BadRequest(new LoginResponse()
                {
                    StatusCode = ResponseCode.SYSTEM_ERROR,
                    StatusText = "Username or Password is incorrect."
                });
            }

            return Ok(new LoginResponse()
            {
                StatusCode = result.StatusCode,
                StatusText = result.StatusText,
                UserId = result.UserId,
                Username = result.Username,
                Token = result.Token
            });
        }


        [HttpPost("getProfile")]
        [Authorize]
        public async Task<ActionResult<GetProfileResponse>> GetProfile(GetProfileRequest request)
        {
            if (!ModelState.IsValid) {

                 var errors = ModelState
                            .Where(x => x.Value?.Errors.Count > 0)
                            .SelectMany(x => x.Value!.Errors)
                            .Select(x => x.ErrorMessage)
                            .ToList();

                return BadRequest(new GetProfileResponse()
                {
                    StatusCode = ResponseCode.SYSTEM_ERROR,
                    StatusText = string.Join(", ", errors)
                });
            }

            var result = await _authService.GetProfileAsync(request);

            if (result == null)
            {
                return BadRequest(new GetProfileResponse()
                {
                    StatusCode = ResponseCode.SYSTEM_ERROR,
                    StatusText = "Profile is incorrect."
                });
            }

            return Ok(new GetProfileResponse()
            {
                StatusCode = result.StatusCode,
                StatusText = result.StatusText,
                UserId = result.UserId,
                Username = result.Username,
            });
        }



    }
}