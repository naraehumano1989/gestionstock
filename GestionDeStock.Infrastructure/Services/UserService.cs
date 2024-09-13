using GestionDeStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeStock.Application.Common;
using GestionDeStock.Infrastructure.Persistence;

namespace GestionDeStock.Infrastructure.Services
{
    public class UserService : IUser
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public Task<int> CreateUser(UserEntity user)
        {
            var userNew = _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return Task.FromResult(userId);
        }

        public Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return Task.FromResult(_context.Users.AsEnumerable());
        }


        public Task<int> UpdateUser(UserEntity user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Token = user.Token;
                existingUser.TokenExpiration = user.TokenExpiration;
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(user.Id);
        }

        public Task<UserEntity> ValidateUserAsync(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            return Task.FromResult(user);
        }
    }
}
