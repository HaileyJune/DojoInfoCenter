using Microsoft.EntityFrameworkCore;

namespace DojoInfoCenter.Models
{
    public class DojoInfoCenterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DojoInfoCenterContext(DbContextOptions<DojoInfoCenterContext> options) : base(options) { }
        public DbSet<UserObject> Users { get; set; }
        public DbSet<LocationObject> Locations { get; set; }
        public DbSet<MessageObject> Messages { get; set; }
    }
}