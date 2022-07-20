using DeliveriamoRepository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriamoRepository
{
    public class Repository : IRepository
    {
        private readonly DeliveriamoContext _context;

        public Repository(DeliveriamoContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.User.AddAsync(user);
            return user;
        }

        public async Task<User> CheckLogin(string username, string hash)
        {
            // look into DB to see if username and password are valid (compare pwd with hash),
           return await _context.User.Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && x.Password == hash.ToLower());
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
