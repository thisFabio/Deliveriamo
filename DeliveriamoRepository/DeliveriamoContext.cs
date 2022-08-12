using DeliveriamoRepository.Entity;
using Microsoft.EntityFrameworkCore;

namespace DeliveriamoRepository
{
    public class DeliveriamoContext : DbContext
    {

        public DeliveriamoContext()
        {

        }
        public DeliveriamoContext(DbContextOptions<DeliveriamoContext> context)
            : base(context)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<BusinessType> BusinessType { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=DeliveriamoDB;User Id=deliveriamoadm;password=Delivery123!;");
            }
        }


    }
}
