using UESAN.SHOPPING.CORE.core.Entities;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignIn(string email, string password);
        Task<int> Sigup(User user);
    }
}