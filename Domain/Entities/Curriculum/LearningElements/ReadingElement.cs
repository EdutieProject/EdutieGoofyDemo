﻿using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Entities.Curriculum.LearningElements.Tasks.EmbeddedTasks;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements;

public class ReadingElement : ILearningElement
{

    public string Name => throw new NotImplementedException();

    public ILearningElement? Prev => throw new NotImplementedException();

    public ILearningElement? Next => throw new NotImplementedException();


    readonly HashSet<Skill> skills = new();
    public HashSet<Skill> Skills => skills;


    readonly HashSet<ILearningTask> tasks = new();
    public HashSet<ILearningTask> Tasks => tasks;




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
