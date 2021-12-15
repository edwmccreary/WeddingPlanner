using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models
{ 
    public class MyContext : DbContext
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        //Add your tables below:
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings {get;set;}
        public DbSet<RSVP> RSVPs {get;set;}
    }
}