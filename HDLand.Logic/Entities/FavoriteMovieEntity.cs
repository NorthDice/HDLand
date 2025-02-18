using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Logic.Entities
{
    public class FavoriteMovieEntity
    {
        [Key]
        [Column(TypeName = "uuid")]
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public int MovieId { get; set; }
    }
}
