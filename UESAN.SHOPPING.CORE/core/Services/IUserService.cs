using UESAN.SHOPPING.CORE.core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public interface IUserService
    {
        Task<UserDTO> SignIn(string email, string password);
        Task<int> Signup(UserCreateDTO userCreateDTO);
    }
}