using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                // CREATE
                // var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
                // context.Tags.Add(tag);

                // UPDATE
                // var tag = context.Tags.FirstOrDefault(x => x.Name == "ASP.NET");
                // tag.Name = ".NET";
                // tag.Slug = "dotnet";
                // context.Update(tag);

                // DELETE
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 7);
                // context.Remove(tag);

                // context.SaveChanges();

            }
        }
    }
}