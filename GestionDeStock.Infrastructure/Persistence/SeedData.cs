using GestionDeStock.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context, IToken tokenService)
        {
            if (!context.Users.Any())
            {
                var adminUser = new Domain.Entities.UserEntity
                {
                    Username = "admin",
                    Password = "admin",
                    Token = "",
                    TokenExpiration = DateTime.UtcNow.AddHours(1)
                };

                adminUser.Token = tokenService.GenerateToken(adminUser);

                var normalUser = new Domain.Entities.UserEntity
                {
                    Username = "user",
                    Password = "user",
                    Token = "",
                    TokenExpiration = DateTime.UtcNow.AddHours(1)
                };

                normalUser.Token = tokenService.GenerateToken(normalUser);

                context.Users.AddRange(adminUser, normalUser);
                context.SaveChanges();
            }
        }
    }
}
