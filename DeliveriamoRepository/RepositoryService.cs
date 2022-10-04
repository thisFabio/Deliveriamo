using DeliveriamoRepository.Entity;
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
            return await _context.Product.ToListAsync();

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


        public async Task<List<User>> GetUsers()
        {
            return await  _context.User.ToListAsync();   
        }

        public async Task<User> GetUserById(int Id)
        {
            return await _context.User.FirstOrDefaultAsync(x=>x.Id == Id);

        }
        public async Task<User> DeleteUser(User user)
        {
            _context.User.Remove(user);
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.User.Update(user);
            return user;
        }
        /****************************** USERADDRESS *******************************/

        public async Task<List<UserAddress>> GetUserAddressListByUserId(int id)
        {
            var result = new List<UserAddress>();
            if (_context.User.Any(x => x.Id == id))
            {
                 result =  await _context.UserAddress.Where(x => x.UserId == id).ToListAsync();
            }

            return result;
        }
        public async Task<UserAddress> GetUserAddressById(int id)
        {
            return  await _context.UserAddress.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserAddress> AddUserAddress(UserAddress userAddress)
        {
             await _context.UserAddress.AddAsync(userAddress);
            return userAddress;
        }

        public async Task<UserAddress> UpdateUserAddress(UserAddress userAddress)
        {
             _context.UserAddress.Update(userAddress);
            return userAddress;
        }

        public async Task<UserAddress> DeleteUserAddress(UserAddress userAddress)
        {
            _context.UserAddress.Remove(userAddress);
            return userAddress;
        }


        /*************************** DASHBOARD ************************************/
        public async Task<List<User>> GetAllShopKeepers(){
            
            return await _context.User.Where(x => x.ShopKeeper == true).ToListAsync();
        }



        /****************************** CATEGORY *******************************/


        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _context.Category.FirstOrDefaultAsync(x=> x.Id == categoryId);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> DeleteCategory(Category category)
        {
             _context.Category.Remove(category);
            return category;
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Category.Update(category);
            return category;
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.AddAsync(category);
            return category;
        }

        /****************************** ORDER *******************************/

        public async Task<Order> AddOrder(Order order, string userId)
        {
            await _context.Order.AddAsync(order);
 
            return order;
        }
        public async Task<Order> AddOrderProduct(Order order, List<int> productsId)
        {
            foreach (var product in productsId)
            {
                await _context.OrderProduct.AddAsync(new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = product

                }); 

            }
                return null;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _context.Order.Update(order);
            return order;
        }

        public async Task<Order> DeleteOrder(Order order)
        {
            _context.Order.Remove(order);
            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Order.Include(x => x.OrderProducts).ThenInclude(y => y.Product).ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Order.FirstOrDefaultAsync(x => x.Id == id);
        }
        /****************************** GENERAL *******************************/


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }




    }

}
