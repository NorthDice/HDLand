using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserEntity> Users { get; set; } = [];
        public ICollection<PermissionEntity> Permissions { get; set; } = [];
    }
}
