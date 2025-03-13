using Microsoft.EntityFrameworkCore;

namespace Battleship.Users.Model.Data.Postgre
{
    public class UserDbContext : DbContext
    {
        private string _connect = "";
        public DbSet<UserDB> Users { get; set; }

        public UserDbContext(string connect)
        {
            _connect = connect;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql(_connect);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDB>().HasKey(u => u.ShortID);

        }
    }
}
