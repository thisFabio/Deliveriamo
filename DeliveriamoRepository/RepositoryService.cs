﻿using DeliveriamoRepository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriamoRepository
{
    public class RepositoryService : IRepositoryService
    {
        private readonly DeliveriamoContext _context;

        public RepositoryService(DeliveriamoContext context)
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
            User output = null;
            
            try
            {
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(hash))
                {
                    return null;
                }

                // look into DB to see if username and password are valid (compare pwd with hash),
                output = await _context.User.Include(x => x.Role)
                    .FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && x.Password == hash.ToLower());

            }
            catch (Exception)
            {

                throw new NullReferenceException();
            }

            return output;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}