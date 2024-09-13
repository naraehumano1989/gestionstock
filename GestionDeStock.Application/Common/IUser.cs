using GestionDeStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Application.Common
{
    public interface IUser
    {
        Task<UserEntity> ValidateUserAsync(string username, string password);

        Task<int> CreateUser(UserEntity user);
        Task<int> UpdateUser(UserEntity user);
        Task<int> DeleteUser(int userId);
        Task<IEnumerable<UserEntity>> GetAllUsers();

    }
}
