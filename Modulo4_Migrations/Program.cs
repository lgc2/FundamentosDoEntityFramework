using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new BlogDataContext();

            var posts = await GetPosts(context);
            var users = await GetUsers(context);

            foreach (var post in posts)
            {
                Console.WriteLine(post.Title);
            }

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        public static async Task<IEnumerable<Post>> GetPosts(BlogDataContext context)
        {
            return await context.Posts.ToListAsync();
        }

        public static async Task<IEnumerable<User>> GetUsers(BlogDataContext context)
        {
            return await context.Users.ToListAsync();
        }
    }
}