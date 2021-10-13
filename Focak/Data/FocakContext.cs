using Microsoft.EntityFrameworkCore;

namespace Focak.Data
{
    public class FocakContext:DbContext
    {
        public FocakContext() { }
        public FocakContext(DbContextOptions<FocakContext> options):base(options)
        {

        }
        public DbSet<CrawlQueue> CrawlQueues { get; set; } = null!;
        public DbSet<CrawlItem> CrawlItems { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CrawlQueueConfiguration());
            modelBuilder.ApplyConfiguration(new CrawlItemConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
