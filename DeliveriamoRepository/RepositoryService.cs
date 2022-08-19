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
        /****************************** PRODUCT *******************************/
        public async Task<Product> AddProduct(Product product, string userId)
        {
            await _context.Product.AddAsync(product);
            await _context.UserProduct.AddAsync(new UserProduct()
            {
                ProductId = product.Id,
                UserId = Convert.ToInt32(userId)
            });
            return product;
        }

        public async Task<Product> DeleteProduct(Product product)
        {
             _context.Product.Remove(product);
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            return product;
        }
        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);

        }
        public async Task<List<Product>> GetAllProducts()

        {
            var dbResult = _context.Product.Select(x => new Product()
           {
                Id = x.Id,
                Name = x.Name,
                PriceUnit = x.PriceUnit,
                Description = x.Description,
                CategoryId = x.CategoryId,
                Barcode = x.Barcode,
                UrlImage = x.UrlImage,
                Status = x.Status,
                CreationTime = x.CreationTime,
                LastUpdate = x.LastUpdate

           }).ToList();

            return dbResult;

        }

        public async Task<List<Product>> GetProducts(string userId)
        {
            // converting string to int in order to check if statement.
            int id;
            Int32.TryParse(userId, out id);

            if (String.IsNullOrEmpty(userId) || id == 0)
            {
                // get all products because there is no valid entry
                return await _context.Product.ToListAsync();
            }
            else
            {
                // getting a list of products filtered by shopkeeper ID 
                var result = _context.UserProduct
                    .Where(x => x.UserId == uint.Parse(userId))
                    .Select(y => y.Product).ToList();

                if (result.Count == 0)
                {
                    result = await _context.Product.ToListAsync();
                }
                return result;
            }
        }

        /****************************** USER *******************************/


        public async Task<User> AddUser(User user)
        {

            await _context.User.AddAsync(user);
            return user;
        }

        public async Task<User> AddUserShop(User user)
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
            catch (Exception ex)
            {

                throw new NullReferenceException();
            }

            return output;
        }
        public async Task<bool> UsernameAlreadyExist(string username)
        {
            return _context.User.Any(x => x.Username == username);
        }

        /****************************** GENERAL *******************************/


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
