using System.Threading.Tasks;
using WebApplication2.Data.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IAuthService
    {
        Task<User> Login(string email, string password);
        Task<int> Register(UserRegisterDto userRegisterDto);
        string CreateToken(User user);
    }
}
