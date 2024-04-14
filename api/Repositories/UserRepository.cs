using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Existed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Include(u => u.Massions).ThenInclude(m => m.SubMissions).Include(u => u.Massions).ThenInclude(m => m.Tags).ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users.Include(u => u.Massions).ThenInclude(m => m.SubMissions).Include(u => u.Massions).ThenInclude(m => m.Tags).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}