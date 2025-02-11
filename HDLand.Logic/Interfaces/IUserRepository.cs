using HDLand.Logic.Enums;
using HDLand.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
        Task<HashSet<Permissions>> GetUserPermissions(Guid userId);
    }
}
