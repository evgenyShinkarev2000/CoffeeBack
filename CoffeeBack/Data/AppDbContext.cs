using CoffeeBack.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CoffeeBack.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TextLecture> TextLectures { get; set; }
        public DbSet<VideoLecture> VideoLectures { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentKind> DocumentKinds { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
