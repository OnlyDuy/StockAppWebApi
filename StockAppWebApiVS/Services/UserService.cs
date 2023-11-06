using Microsoft.AspNetCore.Mvc.Formatters;
using StockAppWebApiVS.Models;
using StockAppWebApiVS.Repositories;
using StockAppWebApiVS.ViewModels;
using System.Linq.Expressions;

namespace StockAppWebApiVS.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Register(RegisterViewModel registerViewModel)
        {
            // Tạo đối tượng User từ RegisterViewModel
            // Kiểm tra xem username hoặc email đã tồn tại trong database hay chưa
            var existingUserByUsername = await _userRepository
                .GetByUsername(registerViewModel.Username ?? "");
            if (existingUserByUsername != null)
            {
                throw new ArgumentException("Username already exists");
            }

            var existingUserByEmail = await _userRepository.GetByEmail(registerViewModel.Email);
            if (existingUserByEmail != null)
            {
                throw new ArgumentException("Email already exists");
            }

            return await _userRepository.Create(registerViewModel);
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            return await _userRepository.Login(loginViewModel);
        }

        public async Task<User?> GetUserById(int userId)
        {
            User? user = await _userRepository.GetById(userId);
            return user;
        }
    }
}
