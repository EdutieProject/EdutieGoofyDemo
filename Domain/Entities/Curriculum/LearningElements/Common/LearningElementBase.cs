﻿using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements.Common;


/// <summary>
/// Base learning element commonly used when constructing a concrete learning elem
/// </summary>
public abstract class LearningElementBase : ILearningElement
{
    public string Name { get; set; } = string.Empty;

    ILearningElement? prev;
    public ILearningElement? Prev
    {
        get => prev;
        set
        {
            if (value == null) return;
            prev = value;
        }
    }

    HashSet<ILearningElement> next = new();
    public HashSet<ILearningElement> Next
    {
        get => next;
        set => next = value;
    }

    protected HashSet<Skill> skills = new();
    public HashSet<Skill> Skills => skills;

    protected HashSet<ILearningTask> tasks = new();
    public HashSet<ILearningTask> Tasks => tasks;
    public void AddSkill(Skill skill)
    => skills.Add(skill);

    public void RemoveSkill(Skill skill)
        => skills.Remove(skill);

    public virtual void AddTask(ILearningTask task)
        => tasks.Add(task);

    public void RemoveTask(ILearningTask task)
        => tasks.Add(task);
}
