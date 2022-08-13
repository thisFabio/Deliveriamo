
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnittestDeliveriamo.Entity;

namespace IntegrationTest.Deliveriamo
{
    public static class Utilities
    {
        internal static void InitializeDbForTests(DeliveriamoContext db)
        {
            var role = new Role()
            {
                Id = 1,
                RoleName = "Admin"
            };

            var category = new Category()
            {
                Id = 1,
                Name = "Category 1",
                Description = "Category 1 Description"
            };

            db.Category.Add(category);
            db.SaveChanges();

            var user= new UserBuilder()
                .WithEnabled(true)
                .WithUsername("ciccio")
                .WithPassword("57ffec0a0664048a8d7142d12d9ed6eb")
                .WithFirstname("pippo")
                .WithDob(new DateTime(2001 - 01 - 01))
                .WithLastname("Rossi")
                .WithGender('M')
                .WithRole(role)
                .WithRoleId(2)
                .WithId(1)
                .Build();

           db.Role.Add(role);
            db.SaveChanges();
           db.User.Add(user);
            db.SaveChanges();

            var test = db.User.ToList();
        }


    }
}
