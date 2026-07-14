using LoginApi.Models.Response;
using LoginApi.Models.Entities;

namespace LoginApi.Services.Interfaces
{
    public interface IJwtService
    {
        String GenerateToken(User user);
    }
}