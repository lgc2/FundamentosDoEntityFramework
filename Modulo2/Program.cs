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

            // var user = new User
            // {
            //     Name = "André Baltieri",
            //     Slug = "andrebaltieri",
            //     Email = "andre@balta.io",
            //     Bio = "11x Microsoft MVP",
            //     Image = "https://balta.io",
            //     PasswordHash = "09238423aosjdaso"
            // };

            // var category = new Category
            // {
            //     Name = "Banco de dados",
            //     Slug = "banco-de-dados"
            // };

            // var post = new Post
            // {
            //     Author = user,
            //     Category = category,
            //     Body = "<p>Hello World!!!</p>",
            //     Slug = "comecando-com-ef-core",
            //     Summary = "Neste artigo vamos aprender EF Core",
            //     Title = "Começando com EF Core",
            //     CreateDate = DateTime.UtcNow.AddHours(-3),
            //     LastUpdateDate = DateTime.UtcNow.AddHours(-3)
            // };

            // context.Posts.Add(post);
            // context.SaveChanges();

            var posts = context
                .Posts
                .AsNoTracking()
                .Include(x => x.Author) // incluir o subconjunto Author é como se fizesse um join na tabela User
                .Where(x => x.AuthorId == 12)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToList();

            foreach (var post in posts)
                Console.WriteLine($"{post.Title}, escrito por {post.Author?.Name}");
        }
    }
}