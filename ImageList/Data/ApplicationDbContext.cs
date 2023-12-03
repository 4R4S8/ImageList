using Microsoft.EntityFrameworkCore;
using ImageList.Models;
namespace ImageList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ImageView> IamgeView { get; set; }
    }
}

