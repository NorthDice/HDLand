using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Entities
{
    public class UserRoleEntity
    {
        [Key]
        [Column(TypeName = "uuid")]
        public Guid UserId { get; set; }

        public int RoleId { get; set; }
    }
}
