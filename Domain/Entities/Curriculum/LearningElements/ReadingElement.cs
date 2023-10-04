using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Entities.Curriculum.LearningElements.Tasks.EmbeddedTasks;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements;

public class ReadingElement : ILearningElement
{

    public string Name { get; set; } = string.Empty;

    public ILearningElement? Prev { get; set; }

    public ILearningElement? Next { get; set; }


    readonly HashSet<Skill> skills = new();
    public HashSet<Skill> Skills => skills;


    readonly HashSet<ILearningTask> tasks = new();
    public HashSet<ILearningTask> Tasks => tasks;


    public ReadingElement(string name)
    {
        Name = name;
    }


    public void AddSkill(Skill skill)
        => skills.Add(skill);

    public void RemoveSkill(Skill skill)
        => skills.Remove(skill);

    public void AddTask(ILearningTask task)
    {
        if (tasks.Count >= 1) return;
        tasks.Add(task);
    }

    public void RemoveTask(ILearningTask task)
        => tasks.Add(task);

    public void AssessUserPerformance(StudentUser user)
    {
        throw new NotImplementedException();
    }
}
