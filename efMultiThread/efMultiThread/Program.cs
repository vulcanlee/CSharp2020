using efMultiThread.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace efMultiThread
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SchoolContext context = new SchoolContext();

            var task1 = Task.Run(async () =>
            {
                for (int i = 0; i < 100; i++)
                {
                   var people= await context.Person
                    .AsNoTracking()
                    .OrderBy(x => x.LastName).ToListAsync();
                    foreach (var item in people)
                    {
                        Console.Write($"{item.LastName} ");
                    }
                }
            });
            var task2 = Task.Run(async () =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var courses = await context.Course
                     .AsNoTracking()
                     .OrderBy(x => x.Title).ToListAsync();
                    foreach (var item in courses)
                    {
                        Console.Write($"{item.Title} ");
                    }
                }
            });
            await Task.WhenAll(task1, task2);
        }
    }
}
