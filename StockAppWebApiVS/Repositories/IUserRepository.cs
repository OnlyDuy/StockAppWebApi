using StockAppWebApiVS.Models;
using StockAppWebApiVS.ViewModels;

namespace StockAppWebApiVS.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> Create(RegisterViewModel registerViewModel);
        Task<string> Login(LoginViewModel loginViewModel);
    }
}
