using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.SyllabusElements;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Science Science { get; set; }

    private HashSet<Lesson> startingLessons = new();

    public void AddStartingLesson(Lesson lesson)
    {
        startingLessons.Add(lesson);
    }
    public void RemoveStartingLesson(Lesson lesson)
    {
        startingLessons.Remove(lesson);
    }
}
