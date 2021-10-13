using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Focak.Data
{
    public class CrawlQueue
    {
        public int Id { get; set; }
        public string? Source { get; set; }
        public double Running { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public virtual ICollection<CrawlItem>? CrawlItems { get; set; }
        public CrawlQueue()
        {
            Created = DateTime.Now;
        }
    }
    public class CrawlQueueConfiguration : IEntityTypeConfiguration<CrawlQueue>
    {
        public void Configure(EntityTypeBuilder<CrawlQueue> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Created).IsRequired(true);
            builder.Property(p => p.Source).IsRequired(true).HasMaxLength(200);
        }
    }
}
