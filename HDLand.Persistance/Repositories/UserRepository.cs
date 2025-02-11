using AutoMapper;
using HDLand.Logic.Entities;
using HDLand.Logic.Enums;
using HDLand.Logic.Interfaces;
using HDLand.Logic.Models;
using HDLand.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLand.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(User user)
        {
            var roleEntity = await _context.Roles
                .SingleOrDefaultAsync(r => r.Id == (int)Role.User)
            ?? throw new InvalidOperationException("User role not found in the database.");

            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) 
            ?? throw new InvalidOperationException("User not found in the database.");

            return _mapper.Map<User>(userEntity);
        }

        public async Task<HashSet<Permissions>> GetUserPermissions(Guid userId)
        {
            var roles = await _context.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ThenInclude(r => r.Permissions)
                .Where(u => u.Id == userId)
                .ToArrayAsync();

            return roles
                .SelectMany(r => r.Roles)
                .SelectMany(r => r.Permissions)
                .Select(p => (Permissions)p.Id)
                .ToHashSet();
        }



    }

}
