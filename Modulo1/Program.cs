using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

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

                // UPDATE --> não utilizar AsNoTracking
                // var tag = context.Tags.FirstOrDefault(x => x.Name == "ASP.NET");
                // tag.Name = ".NET";
                // tag.Slug = "dotnet";
                // context.Update(tag);

                // DELETE --> não utilizar AsNoTracking
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 7);
                // context.Remove(tag);

                // context.SaveChanges();

                // SELECT
                // var tags = context.Tags; // só é uma referência, não foi no banco ainda
                // var tags = context
                // .Tags
                // .AsNoTracking() // desabilita o tracking para a consulta, ou seja, não traz metadados (ganho de performance)
                // .ToList(); // com o ToList() a query foi de fato executada. O ToList() deve ser colocado sempre no final da query
                // foreach (var item in tags)
                // {
                //     Console.WriteLine(item.Name);
                // }

                var tag = context
                    .Tags
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == 8);

                Console.WriteLine(tag?.Name);
            }
        }
    }
}