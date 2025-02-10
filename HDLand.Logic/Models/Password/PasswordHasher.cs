using HDLand.Logic.Interfaces;


namespace HDLand.Logic.Models.Password
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) =>
             BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
             BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
