using Microsoft.EntityFrameworkCore;

namespace EvoWeb
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Worker> Workers { get; set; }


        public void CreateBDNew()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //модификация таблиц в бд
        }
    }
}