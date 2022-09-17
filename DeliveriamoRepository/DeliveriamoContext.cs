using DeliveriamoRepository.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // instructions how to delete Category record from DB. if there are products linked to the category, deletion is forbidden.
            modelBuilder
                .Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .OnDelete(DeleteBehavior.Restrict);

            // instructions how to delete User record from DB. if there are products linked to the User(checking UserProduct Table)
            // deletion is forbidden.

            modelBuilder
                .Entity<User>()
                .HasMany(e => e.UserProduct)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<BusinessType> BusinessType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }







        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=DeliveriamoDB;User Id=deliveriamoadm;password=Delivery123!;");
                //optionsBuilder.UseSqlite("Data Source=mydb.db;");
            }
        }


    }
}
