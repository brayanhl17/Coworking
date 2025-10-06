using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;

namespace Cwk.Business.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequest);

        Task<UserResponseDto> Register(CreateUserDto createUser);
    }
}