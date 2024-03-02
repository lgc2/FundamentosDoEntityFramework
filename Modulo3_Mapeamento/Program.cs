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

            // context.Users.Add(new User
            // {
            //     Bio = "9x MS MVP",
            //     Email = "andre2@balta.io",
            //     Image = "https://balta.io",
            //     Name = "Balta",
            //     PasswordHash = "981asniasdh02",
            //     Slug = "andr-balta"
            // });
            // context.SaveChanges();

            // var user = context.Users.OrderByDescending(x => x.Id).FirstOrDefault();
            // var post = new Post
            // {
            //     Author = user,
            //     Body = "Meu artigo!!!",
            //     Category = new Category
            //     {
            //         Name = "Mobile",
            //         Slug = "mobile"
            //     },
            //     CreateDate = DateTime.UtcNow.AddHours(-3),
            //     // LastUpdateDate =
            //     Slug = "meu-artigo",
            //     Summary = "Neste artigo vamos conferir...",
            //     // Tags = null,
            //     Title = "Meu Artigo"
            // };

            // context.Posts.Add(post);
            // context.SaveChanges();

            var usersWithRoles = context
                .Users
                .AsNoTracking()
                .Include(x => x.Roles)
                .OrderBy(x => x.Id)
                // .ThenByDescending(x => x.Roles.OrderByDescending(r => r.Id).FirstOrDefault().Id)
                .ToList();

            foreach (var user in usersWithRoles)
            {
                Console.WriteLine();
                Console.Write($"[{user.Id}]{user.Name}");
                foreach (var role in user.Roles)
                {
                    Console.Write($" - Role: [{role.Id}]{role.Name}");
                }
            }
        }
    }
}