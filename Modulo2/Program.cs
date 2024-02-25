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

            // INSERT (encadeado)
            // --------------------------------------------------------------------------------------
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
            // --------------------------------------------------------------------------------------

            // SELECT
            // --------------------------------------------------------------------------------------
            // var posts = context
            //     .Posts
            //     .AsNoTracking()
            //     .Include(x => x.Author) // incluir o subconjunto Author é como se fizesse um join na tabela User
            //     .Include(x => x.Category) // incluir o subconjunto Author é como se fizesse um join na tabela User
            //                               // .ThenInclude(x => x.) // maneira de realcionar um filho fazendo um subselect
            //     .Where(x => x.AuthorId == 12)
            //     .OrderByDescending(x => x.LastUpdateDate)
            //     .ToList();

            // foreach (var post in posts)
            //     Console.WriteLine($"{post.Title}, escrito por {post.Author?.Name} em {post.Category?.Name}");
            // --------------------------------------------------------------------------------------

            // UPDATE
            // --------------------------------------------------------------------------------------
            var post = context
                .Posts
                // .AsNoTracking() --> precisa do tracking no UPDATE
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault();

            post.Author.Name = "Update test";

            context.Posts.Update(post);
            context.SaveChanges();
            // --------------------------------------------------------------------------------------
        }
    }
}