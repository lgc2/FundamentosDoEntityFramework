using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=127.0.0.1,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");
    }
}