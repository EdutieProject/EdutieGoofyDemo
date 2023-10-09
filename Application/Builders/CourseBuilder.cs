using Domain.Entities.Curriculum.SyllabusElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders;

/// <summary>
/// Object which purpose is to create courses
/// </summary>
public class CourseBuilder
{
    readonly Course course = new();

    public CourseBuilder() { }

    /// <summary>
    /// Sets name to the built course
    /// </summary>
    /// <param name="name">Name to be set</param>
    /// <returns>This CourseBuilder</returns>
    public CourseBuilder SetName(string name)
    {
        course.Name = name;
        return this;
    }

    /// <summary>
    /// Currently unsupported: Assigns this course to the concrete science
    /// </summary>
    /// <param name="science">Science to be assigned</param>
    /// <returns>This CourseBuilder</returns>
    public CourseBuilder SetScience(Science science)
    {
        course.Science = science;
        return this;
    }
    /// <summary>
    /// Adds a lesson to starting lessons hashset
    /// </summary>
    /// <param name="lesson">lesson to be added</param>
    /// <returns>This CourseBuilder</returns>
    public CourseBuilder AddStartingLesson(Lesson lesson)
    {
        course.StartingLessons.Add(lesson);
        return this;
    }
    /// <summary>
    /// Retrive the built course
    /// </summary>
    /// <returns>Course</returns>
    public Course Build()
        => course;
}
