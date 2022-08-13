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

        Task<User> AddUser (User user);

        Task<Product> AddProduct (Product product);

        Task<bool> UsernameAlreadyExist(string username);

        Task SaveChanges();

        Task<User> AddUserShop(User user);

    }
}
