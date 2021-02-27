using Microsoft.EntityFrameworkCore;

namespace ratingcore.Models
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars{get;set;}
    }
}