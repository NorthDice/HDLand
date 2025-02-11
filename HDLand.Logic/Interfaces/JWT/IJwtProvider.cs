using HDLand.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Interfaces.JWT
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User user);
    }
}
