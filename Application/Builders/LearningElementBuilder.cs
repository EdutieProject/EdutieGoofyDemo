﻿using Domain.Entities.Curriculum.LearningElements;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks.StaticTasks;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders;

/// <summary>
/// A builder meant to create learning elements.
/// </summary>
public class LearningElementBuilder
{
    ILearningElement? learningElement;
    public LearningElementBuilder()
    { }

    /// <summary>
    /// Constructor which is meant to modify existing element
    /// </summary>
    /// <param name="element">element to modify</param>
    public LearningElementBuilder(ILearningElement element)
        => learningElement = element;


    /// <summary>
    /// Sets the created element to be a new Reading Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateReadingElement(string name)
    {
        learningElement = new ReadingElement(name);
        return this;
    }

    /// <summary>
    /// Sets the created element to be a new Figure Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateFigureElement(string name)
    {
        learningElement = new FigureElement(name);
        return this;
    }

    /// <summary>
    /// Sets the created element to be a new Task Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateTaskElement(string name)
    {
        learningElement = new TaskElement(name);
        return this;
    }

    /// <summary>
    /// Sets the created element to be a new Movie Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateMovieElement(string name)
    {
        learningElement = new MovieElement(name); 
        return this;
    }
    /// <summary>
    /// Sets the previous element of the built one to the provided one.
    /// </summary>
    /// <param name="previous">Element to be set as previous</param>
    /// <returns></returns>
    public LearningElementBuilder AppendTo(ILearningElement previous)
    {
        if (learningElement != null)
        {
            learningElement.Prev = previous;
            previous.Next.Add(learningElement);
        }
        return this;
    }
    /// <summary>
    /// Sets next element to the provided element
    /// </summary>
    /// <param name="nextElem">Element to be set as next</param>
    /// <returns>This builder</returns>
    public LearningElementBuilder AppendElement(ILearningElement nextElem)
    {
        learningElement?.Next.Add(nextElem);
        nextElem.Prev = learningElement;
        return this;
    }

    /// <summary>
    /// Adds task of given intelligences
    /// </summary>
    /// <param name="intelligences">intelligences of a task</param>
    /// <returns>This builder</returns>
    public LearningElementBuilder AddTask(IntelligenceType primary, IntelligenceType secondary)
    {
        learningElement?.AddTask(new ProjectBasedTask()
        {
            PrimaryItelligence = primary,
            SecondaryIntelligence = secondary,
        });
        return this;
    }

    /// <summary>
    /// Adds specific skills to a learning Element
    /// </summary>
    /// <param name="skills">skills to be added</param>
    /// <returns>This builder</returns>
    public LearningElementBuilder AddSkills(Skill[] skills)
    {
        foreach (var skill in skills)
        {
            learningElement?.AddSkill(skill);
        }
        return this;
    }

    /// <summary>
    /// Builds previously specified element. If element is not specified, throws an exception.
    /// </summary>
    /// <returns>This builder</returns>
    /// <exception cref="NullReferenceException">Exception thrown when CreateConcreteElement has not been called</exception>
    public ILearningElement Build()
        => learningElement ?? throw new NullReferenceException("Builder misuse");

}
