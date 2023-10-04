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

public class MovieElement : ILearningElement
{
    public string Name { get; set; } = string.Empty;
    public Video Video { get; set; } = new();

    public ILearningElement? Prev { get; set; }

    public ILearningElement? Next { get; set; }

    readonly HashSet<Skill> skills = new();
    public HashSet<Skill> Skills => skills;

    readonly HashSet<ILearningTask> tasks = new();
    public HashSet<ILearningTask> Tasks => tasks;

    public MovieElement(string name)
    {
        Name = name;
    }


    public void AddSkill(Skill skill)
        => skills.Add(skill);

    public void RemoveSkill(Skill skill)
        => skills.Remove(skill);

    public void AddTask(ILearningTask task)
        => tasks.Add(task);

    public void RemoveTask(ILearningTask task)
        => tasks.Add(task);


    public void AssessUserPerformance(StudentUser user)
    {
        throw new NotImplementedException();
    }
}
