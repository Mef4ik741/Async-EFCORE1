using ConsoleApp1.asyncAwait;

namespace ConsoleApp1;
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


class Program
{
    private static string connectionString = "Server=localhost;Database=DZ;Trusted_Connection=True;TrustServerCertificate=True;";
    static void Main()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        
        using (var context = new ApplicationDbContext(optionsBuilder.Options))
        {
            var students = new StudentServiceNotAsyncAwait(context);
            var studentsAsync = new StudentServiceAsyncAwait(context);
            
            Console.Write("(1)Введите имя студента: ");
            string name = Console.ReadLine()!;
            
            students.AddStudentManually(name);
            
            Console.Write("(2)Введите имя студента: ");
            string name2 = Console.ReadLine()!;
            
            students.AddStudentManually(name2);
            
            students.ShowAllStudentsManually();
            studentsAsync.ShowAllStudentsAsync();
        }
    }
}