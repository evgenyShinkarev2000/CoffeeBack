using CoffeeBack.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBack.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TextLecture> TextLectures { get; set; }
        public DbSet<VideoLecture> VideoLectures { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
