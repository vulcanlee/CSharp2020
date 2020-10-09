using efDbContextOptionsBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace efDbContextOptionsBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=School";
            DbContextOptions<SchoolContext> options = new DbContextOptionsBuilder<SchoolContext>()
                .UseSqlServer(connectionString)
                .Options;
            using (var context = new SchoolContext(options))
            {
                Console.WriteLine($"取得 StudentGrade 第一筆紀錄");
                var aStudentGrade = context.StudentGrade.FirstOrDefault();
                Console.WriteLine($"{aStudentGrade.StudentId} 學生的 {aStudentGrade.CourseId} 課程的成績為 {aStudentGrade.Grade}");
            }
        }
    }
}
