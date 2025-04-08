using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.asyncAwait;

public class StudentServiceAsyncAwait
{
    private ApplicationDbContext _context;

    public StudentServiceAsyncAwait(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddStudentAsync(string name)
    {
        _context.Students.Add(new Student { Name = name });
        await _context.SaveChangesAsync();
        Console.WriteLine($"[Добавленное Async] Поток ID: {Thread.CurrentThread.ManagedThreadId}");
    }

    public async Task ShowAllStudentsAsync()
    {
        var students = _context.Students.ToList();
        Console.WriteLine($"[Список Async] Поток ID: {Thread.CurrentThread.ManagedThreadId}");

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
        }
    }
}