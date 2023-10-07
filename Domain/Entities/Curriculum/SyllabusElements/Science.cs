using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.SyllabusElements;

/// <summary>
/// A collection of courses related with particular science.
/// </summary>
public class Science
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    private readonly List<Course> courses = new();

    public Science(string name)
    { 
        Name = name;
    }

    public void AddNewCourse(Course course)
    {
        courses.Add(course);
    }

    public void RemoveCourse(Course course) 
    { 
        courses.Remove(course);
    }
}
