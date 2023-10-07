using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.SyllabusElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders;

/// <summary>
/// Builder meant to create and manage 
/// </summary>
public class LessonBuilder
{
    readonly Lesson lesson;

    /// <summary>
    /// Creates a lessonBuilder with a lesson of given name
    /// </summary>
    /// <param name="lessonName">Name of the lesson</param>
    public LessonBuilder(string lessonName)
        => lesson = new(lessonName);

    /// <summary>
    /// Constructor used to modify existing lesson
    /// </summary>
    /// <param name="lesson"></param>
    public LessonBuilder(Lesson lesson)
        => this.lesson = lesson;

    /// <summary>
    /// Sets the built lesson's name to the provided string. Can override the name provided in builder costructor.
    /// </summary>
    /// <param name="name">Name to be set</param>
    /// <returns>This builder</returns>
    public LessonBuilder SetLessonName(string name)
    {
        lesson.Name = name;
        return this;
    }

    /// <summary>
    /// Sets previous lesson of the built lesson
    /// </summary>
    /// <param name="prevLesson">Lesson to be set as previous</param>
    /// <returns>This builder</returns>
    public LessonBuilder AddPreviousLesson(Lesson prevLesson)
    {
        lesson.Prev = prevLesson;
        return this;
    }

    /// <summary>
    /// Adds a lesson as next after the built one
    /// </summary>
    /// <param name="nextLesson">Lesson to be set as next</param>
    /// <returns>This builder</returns>
    public LessonBuilder AddNextLesson(Lesson nextLesson)
    {
        lesson.Next.Add(nextLesson);
        return this;
    }

    /// <summary>
    /// Sets starting element to the provided element. Element should be a head of learningElement tree.
    /// </summary>
    /// <param name="startingElement">Head of lesson elements tree</param>
    /// <returns>This builder</returns>
    public LessonBuilder SetStartingElement(ILearningElement startingElement)
    {
        lesson.StartingElement = startingElement;
        return this;
    }


    /// <summary>
    /// Builds the lesson
    /// </summary>
    /// <returns>The lesson being built</returns>
    public Lesson Build()
        => lesson;
}
