using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Domain.Entities
{
    public class UserEntity
    {
            public int Id { get; set; }
            public required string Username { get; set; }
            public string? Password { get; set; }
            public required string Token { get; set; }
            public DateTime TokenExpiration { get; set; }
    }
}
