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

        Task<User> AddUser (User user);

        Task SaveChanges();


    }
}
