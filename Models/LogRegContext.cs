using Microsoft.EntityFrameworkCore;
using UpdatedLogReg.Models;

namespace UpdatedLogReg.Models
{
    public class LogRegContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LogRegContext(DbContextOptions<LogRegContext> options) : base(options) { }
        public DbSet<UserObject> Users { get; set; }
    }
}