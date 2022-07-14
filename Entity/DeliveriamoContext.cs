using Microsoft.EntityFrameworkCore;

namespace Deliveriamo.Entity
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


        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=DeliveriamoDB;User Id=deliveriamoadm;password=Delivery123!;");
            }
            }
        

    }
}
