using System.Data;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            var users = GetUsers(context, 0, 5);
            var users2 = GetUsers(context, 5, 10);

            foreach (var user in users)
            {
                Console.WriteLine(user.Id);
            }

            foreach (var user in users2)
            {
                Console.WriteLine(user.Id);
            }
        }

        public static List<User> GetUsers(BlogDataContext context, int skip = 0, int take = 5)
        {
            return context
                .Users
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}