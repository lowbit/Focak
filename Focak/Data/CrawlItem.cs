using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Focak.Data
{
    public class CrawlItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Currency { get; set; }
        public string? BrandName { get; set; }
        public string? ModelName { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public string? Warranty { get; set; }
        public string? Url { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public int CrawlQueueId { get; set; }
        public virtual CrawlQueue CrawlQueue { get; set; }
        public CrawlItem()
        {
            CrawlQueue = new();
            Created = DateTime.Now;
        }
    }
    public class CrawlItemConfiguration : IEntityTypeConfiguration<CrawlItem>
    {
        public void Configure(EntityTypeBuilder<CrawlItem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Created).IsRequired(true);
            builder.HasOne(ci => ci.CrawlQueue).WithMany(cq => cq.CrawlItems).HasForeignKey(ci => ci.CrawlQueueId);
        }
    }
}
