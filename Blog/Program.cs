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
                // var tag = new Tag { Name = ".NET", Slug = "dotnet" };
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

                // SELECT
                // var tags = context.Tags; // só é uma referência, não foi no banco ainda
                var tags = context.Tags.ToList(); // com o ToList() a query foi de fato executada. O ToList() deve ser colocado sempre no final da query
                foreach (var item in tags)
                {
                    Console.WriteLine(item.Name);
                }

            }
        }
    }
}