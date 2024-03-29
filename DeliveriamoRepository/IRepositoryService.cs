﻿using DeliveriamoRepository.Entity;
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

        /*************************** CATEGORY ************************************/

        Task<Category> GetCategoryById(int categoryId);
        Task<List<Category>> GetCategories();

        Task<Category> UpdateCategory(Category category);

        Task<Category> AddCategory(Category category);


        Task<Category> DeleteCategory(Category category);



        /*************************** USER ************************************/

        Task<User> AddUser (User user);
        Task<User> AddUserShop(User user);
        Task<bool> UsernameAlreadyExist(string username);

        Task<List<User>> GetUsers();
        Task<User> GetUserById(int Id);

        Task<User> GetShopkeeperIdByProductId(int Id);

        Task<User> DeleteUser(User user);
        Task<User> UpdateUser(User user);

        /*************************** USERADDRESS ************************************/


        Task<UserAddress> GetUserAddressById(int id);
        Task<List<UserAddress>> GetUserAddressListByUserId(int id);

        Task<UserAddress> AddUserAddress(UserAddress userAddress);

        Task<UserAddress> UpdateUserAddress(UserAddress userAddress);
        Task<UserAddress> DeleteUserAddress(UserAddress userAddress);




        /*************************** PRODUCT ************************************/

        Task<Product> AddProduct (Product product, string userId);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Product product);
        Task<List<Product>> GetProducts(string userId);
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();

        /*************************** ORDER ************************************/

        Task<Order> AddOrder(Order order, string userId);

        Task<Order> AddOrderProduct(Order order, List<int> products);

        Task<Order> UpdateOrder(Order order);
        Task<Order> DeleteOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetAllOrdersByUserId(int userId);
        Task<List<Order>> GetAllOrdersByShopKeeperId(int userId);
        Task<Order> GetOrderById(int id);

        /*************************** ORDER STATUS ************************************/

        Task<OrderStatus> AddOrderStatus(OrderStatus orderStatus);
        Task<OrderStatus> GetOrderStatusByOrderId(int orderId);

        /*************************** STATUS FLOW ************************************/

        Task<StatusFlow> GetStatusFlowByStatusId(int statusId);


        /*************************** DASHBOARD ************************************/
        Task<List<User>> GetAllShopKeepers();
        

        /*************************** GENERAL ************************************/
        Task SaveChanges();


    }
}
