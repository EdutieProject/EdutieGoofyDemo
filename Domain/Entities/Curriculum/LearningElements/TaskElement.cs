using Domain.Entities.Curriculum.LearningElements.Common;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements;

public class TaskElement : LearningElementBase
{
    public TaskElement(string name)
    {
        Name = name;
    }

    public override void AddTask(ILearningTask task)
    {
        if (tasks.Count >= 1) return;
        tasks.Add(task);
    }
}
