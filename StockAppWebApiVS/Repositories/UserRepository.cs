using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockAppWebApiVS.Models;
using StockAppWebApiVS.ViewModels;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;

namespace StockAppWebApiVS.Repositories
{
    public class UserRepository : IUserRepository
    {
        // DbContext: đối tượng để kết nối với csdl    
        private readonly StockAppContext _context;
        private readonly IConfiguration _config;

        public UserRepository(StockAppContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            string sql = "EXEC dbo.RegisterUser @username, @email, @password, @phone, " +
                "@full_name, @date_of_birth, @country";
            // Đoạn này sẽ gọi 1 procedure trong sql
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                new SqlParameter("@username", registerViewModel.Username ?? ""),
                new SqlParameter("@password", registerViewModel.Email),
                new SqlParameter("@email", registerViewModel.Password),
                new SqlParameter("@phone", registerViewModel.Phone ?? ""),
                new SqlParameter("@full_name", registerViewModel.FullName ?? ""),
                new SqlParameter("@date_of_birth", registerViewModel.DateOfBirth),
                new SqlParameter("@country", registerViewModel.Country ?? "")).ToListAsync();

            User? user = result.FirstOrDefault();

            return user;
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            string sql = "EXEC dbo.CheckLogin @Email, @password";
            // Đoạn này sẽ gọi 1 procedure trong sql
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                new SqlParameter("@Email", loginViewModel.Email),
                new SqlParameter("@password", loginViewModel.Password)).ToListAsync();

            User? user = result.FirstOrDefault();
            if (user != null)
            {
                // Tạo ra jwt string để gửi cho client
                // Nếu xác thực thành công, tạo JWT Token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"] ?? "");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials
                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return jwtToken;
            } else
            {
                throw new Exception("Wrong email or password");
            }
        }
    }
}
    