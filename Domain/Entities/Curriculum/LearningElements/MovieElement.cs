using Domain.Entities.Curriculum.LearningElements.Common;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Entities.Curriculum.LearningElements.Tasks.EmbeddedTasks;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements;

public class MovieElement : LearningElementBase
{
    public Video Video { get; set; } = new();

    public MovieElement(string name)
    {
        Name = name;
    }

}
