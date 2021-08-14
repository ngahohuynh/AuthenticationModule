using BusinessLogic.Contracts;
using BusinessLogic.DTOs;
using DataAccess;
using DataAccess.Exceptions;
using DataAccess.Models;
using DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(DataContext context) : base(context) { }

        public async Task<User> Login(UserLogin userLogin)
        {
            var user = await Login(userLogin.Username);

            if (string.IsNullOrEmpty(userLogin.Password))
            {
                throw new BadRequestException("Empty Password");
            }

            if (!userLogin.Password.Verify(user.Password))
            {
                throw new BadRequestException("Invalid Password");
            }

            return user;
        }

        public async Task<User> Login(string username)
        {
            var user = await GetUser(username) ?? throw new BadRequestException("Invalid Username");

            if (!user.Valid)
            {
                throw new ForbiddenException("Invalid User");
            }

            return user;
        }

        public async Task<UserResponse> Register(UserRegister userRegister)
        {
            if (await Context.Users.AnyAsync(u => u.Username == userRegister.Username))
            {
                throw new BadRequestException("Username Existed");
            }

            var user = new User()
            {
                Name = userRegister.Name,
                Username = userRegister.Username,
                Password = userRegister.Password.EncodePassword(),
                Type = userRegister.Type,
                Valid = true,
                CreatedDate = DateTime.Now
            };

            base.AddEntry(user);
            await Context.SaveChangesAsync();

            return new UserResponse() { Id = user.Id, Name = user.Name, Username = user.Username, Type = user.Type };
        }

        private async Task<User> GetUser(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
