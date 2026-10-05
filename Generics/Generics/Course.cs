public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Course(int id, string title, decimal price)
    {
        Id = id;
        Title = title;
        Price = price;
    }
}

public class CourseStore
{
    private readonly List<Course> courses = new();

    public void Add(Course course)
    {
        courses.Add(course);
    }

    public Course? GetById(int id)
    {
        foreach (Course course in courses)
        {
            if (course.Id == id)
                return course;
        }

        return null;
    }

    public IEnumerable<Course> GetAll()
    {
        foreach (Course course in courses)
        {
            yield return course;
        }
    }

    public void Remove(int id)
    {
        for (int i = 0; i < courses.Count; i++)
        {
            if (courses[i].Id == id)
            {
                courses.RemoveAt(i);
                return;
            }
        }
    }
}