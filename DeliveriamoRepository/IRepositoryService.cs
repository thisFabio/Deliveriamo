using DeliveriamoRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriamoRepository
{
    public interface IRepositoryService
    {
        Task<User> CheckLogin (string username,string hash);


        /*************************** USER ************************************/
        Task<User> AddUser (User user);
        Task<User> AddUserShop(User user);
        Task<bool> UsernameAlreadyExist(string username);

        /*************************** PRODUCT ************************************/

        Task<Product> AddProduct (Product product, string userId);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Product product);
        Task<List<Product>> GetProducts(string userId);
        Task<Product> GetProductById(int productId);


        /*************************** GENERAL ************************************/
        Task SaveChanges();


    }
}
