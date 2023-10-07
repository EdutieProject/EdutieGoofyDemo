using Domain.Entities.Curriculum.LearningElements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.SyllabusElements;

/// <summary>
/// A tree of learning elements
/// </summary>
public class Lesson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Lesson? Prev { get; set; }
    public HashSet<Lesson> Next { get; set; } = new();


    public ILearningElement StartingElement { get; set; }

    public Lesson(string name)
    {
        Name = name;
    }
}
