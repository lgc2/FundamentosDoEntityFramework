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

            var user = new User
            {
                Bio = "9x MS MVP",
                Email = "andre2@balta.io",
                GitHub = "lgc2",
                Image = "https://balta.io",
                Name = "Balta",
                PasswordHash = "981asniasdh02",
                Slug = "andr-balta"
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}