using Generics;

namespace Generics;

public class Program
{
    public static void Main()
    {
        Store<Student> studentStore = new();

        studentStore.Add(new Student(1, "Ahmed"));
        studentStore.Add(new Student(2, "Mohamed"));
        studentStore.Add(new Student(3, "Omar"));
        studentStore.Add(new Student(4, "Ali"));
        studentStore.Add(new Student(5, "Youssef"));

        Store<Course> courseStore = new();

        courseStore.Add(new Course(1, "C#", 1000));
        courseStore.Add(new Course(2, ".NET", 1500));
        courseStore.Add(new Course(3, "SQL", 800));

        Student? student = studentStore.GetById(1);
        Course? course = courseStore.GetById(2);

        Console.WriteLine($"Student: {student?.Name}");
        Console.WriteLine($"Course: {course?.Title}");

        try
        {
            studentStore.Add(new Student(1, "Duplicate Student"));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nPage 2:");

        foreach (Student item in studentStore.GetAll().Page(2, 2))
        {
            Console.WriteLine($"{item.Id} - {item.Name}");
        }

        List<Course> courses = new()
        {
            new Course(1, "C#", 1000),
            new Course(2, ".NET", 1500),
            new Course(3, "SQL", 800)
        };

        Course? foundCourse = courses.FindById(2);

        Console.WriteLine($"\nFound Course: {foundCourse?.Title}");

        // Store<string> stringStore = new(); // must NOT compile
    }
}