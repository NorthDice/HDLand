using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLand.Logic.Entities;

namespace HDLand.Logic.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            FavoriteMovies = new List<FavoriteMovieEntity>();
        }

        [Key]
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }

        public string UserName { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }

        public ICollection<FavoriteMovieEntity> FavoriteMovies { get; set; }

        public static User Create(Guid id, string username, string passwordHash, string email)
        {
            return new User(id, username, passwordHash, email);
        }
    }
}
