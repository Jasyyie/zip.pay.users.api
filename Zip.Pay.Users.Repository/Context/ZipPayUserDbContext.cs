using Zip.Pay.Users.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Zip.Pay.Users.Repository.Context
{
    public class ZipPayUserDbContext : DbContext
    {
        public ZipPayUserDbContext(DbContextOptions<ZipPayUserDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<User>()
            //     .HasMany(t => t.Accounts)
            //     .WithOne(c => c.User)
            //     .IsRequired();
        }
    }
}
