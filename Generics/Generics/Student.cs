namespace Generics;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class StudentStore
{
    private readonly List<Student> students = new();

    public void Add(Student student)
    {
        students.Add(student);
    }

    public Student? GetById(int id)
    {
        foreach (Student student in students)
        {
            if (student.Id == id)
                return student;
        }

        return null;
    }

    public IEnumerable<Student> GetAll()
    {
        foreach (Student student in students)
        {
            yield return student;
        }
    }

    public void Remove(int id)
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Id == id)
            {
                students.RemoveAt(i);
                return;
            }
        }
    }
}