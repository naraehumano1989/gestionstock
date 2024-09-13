using GestionDeStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Application.Common
{
    public interface IToken
    {
        string GenerateToken(UserEntity user);
    }
}
