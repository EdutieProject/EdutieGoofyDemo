using Domain.Entities.Curriculum.LearningElements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.SyllabusElements
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Lesson? Prev { get; set; }
        public HashSet<Lesson>? Next { get; set; }


        public ILearningElement StartingElement { get; set; }

        public Lesson(string name, string desc, ILearningElement start) 
        {
            Name = name;
            Description = desc;
            StartingElement = start;
        }
    }
}
