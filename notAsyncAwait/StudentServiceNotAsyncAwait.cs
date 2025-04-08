namespace ConsoleApp1;

public class StudentServiceNotAsyncAwait
{
    private ApplicationDbContext _context;

    public StudentServiceNotAsyncAwait(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddStudentManually(string name)
    {
        var task = Task.Run(() =>
        {
            _context.Students.Add(new Student { Name = name });
            _context.SaveChanges();

            Console.WriteLine($"[Добавленное] Поток ID: {Thread.CurrentThread.ManagedThreadId}");
        });

        task.GetAwaiter().GetResult(); 
    }

    public void ShowAllStudentsManually()
    {
        var task = Task.Run(() =>
        {
            var students = _context.Students.ToList();
            Console.WriteLine($"[Список] Поток ID: {Thread.CurrentThread.ManagedThreadId}");

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
            }
        });

        task.GetAwaiter().GetResult();
    }
}