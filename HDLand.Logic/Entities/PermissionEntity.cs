﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Entities
{
    public class PermissionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<RoleEntity> Roles { get; set; } = [];
    }
}
