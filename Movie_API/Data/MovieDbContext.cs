using Microsoft.EntityFrameworkCore;
using Movie_API.Models;

namespace Movie_API.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<MovieDetail> MovieDetails { get; set; }
    }
}
