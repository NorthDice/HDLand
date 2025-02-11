using HDLand.Logic.Interfaces.JWT;
using HDLand.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLand.Logic.Models;

namespace HDLand.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository usersRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = usersRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, hashedPassword, email);

            await _userRepository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid email.");
            }

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new InvalidOperationException("Invalid password.");
            }

            var token = _jwtProvider.GenerateJwtToken(user);

            return token;

        }

    }
}
