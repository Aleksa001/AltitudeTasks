using AltitudeTasks.Class;
using Microsoft.EntityFrameworkCore;

namespace AltitudeTasks.Infrastructure
{
    public class InputDBContext: DbContext
    {
        public DbSet<Input> Inputs { get; set; }
        public InputDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InputDBContext).Assembly);
        }
    }
}
