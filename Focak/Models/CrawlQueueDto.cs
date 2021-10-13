using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Focak.Models
{
    public class CrawlQueueDto
    {

        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string? Source { get; set; }
        public double Running { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
