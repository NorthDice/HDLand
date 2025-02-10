using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Entities
{
    public class PermissionRoleEntity
    {
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }

        public int PermissionId { get; set; }
        public PermissionEntity Permission { get; set; }
    }
}
