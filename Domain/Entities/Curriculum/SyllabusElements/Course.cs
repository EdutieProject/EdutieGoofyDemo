using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.SyllabusElements;

/// <summary>
/// A tree of lessons
/// </summary>
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Science? Science { get; set; }
    
    /// <summary>
    /// Courses may have multiple starting points (lessons) - this is a hashset of those.
    /// </summary>
    private readonly HashSet<Lesson> startingLessons = new();
    public HashSet<Lesson> StartingLessons => startingLessons;

    public void AddStartingLesson(Lesson lesson)
    {
        startingLessons.Add(lesson);
    }
    public void RemoveStartingLesson(Lesson lesson)
    {
        startingLessons.Remove(lesson);
    }
}
