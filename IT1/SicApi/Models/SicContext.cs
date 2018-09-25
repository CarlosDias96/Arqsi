using Microsoft.EntityFrameworkCore;

namespace SicApi.Models
{
    public class SicContext : DbContext
    {
        public SicContext(DbContextOptions<SicContext> options)
            : base(options)
        {
        }

        public DbSet<SicItem> SicItems { get; set; }
    }
}