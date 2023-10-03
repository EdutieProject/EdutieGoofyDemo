using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements;

public class FigureElement : ILearningElement
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ILearningElement? Prev { get; set; }

    public ILearningElement? Next { get; set; }


    readonly HashSet<Skill> skills = new();
    public HashSet<Skill> Skills => skills;

    readonly HashSet<ILearningTask> tasks = new();
    public HashSet<ILearningTask> Tasks => tasks;

    public FigureElement(string name)
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
        => tasks.Remove(task);


    public void AssessUserPerformance(StudentUser user)
    {
        throw new NotImplementedException();
    }
}
