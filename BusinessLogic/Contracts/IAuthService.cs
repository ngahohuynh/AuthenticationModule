using BusinessLogic.DTOs;
using DataAccess.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface IAuthService
    {
        Task<User> Login(UserLogin userLogin);

        Task<User> Login(string username);

        Task<UserResponse> Register(UserRegister userRegister);
    }
}
