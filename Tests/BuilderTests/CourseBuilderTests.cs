using Application.Builders;
using Domain.Entities.Curriculum.SyllabusElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BuilderTests;

internal class CourseBuilderTests
{
    [Test]
    public void CourseBuilderTest1()
    {
        CourseBuilder builder = new();
        string courseName = "Dupa";
        builder.SetName(courseName);
        var course = builder.Build();

        Assert.That(course.Name, Is.EqualTo(courseName));
    }

    [Test]
    public void CourseBuilderTest2()
    {
        Lesson lesson = new("Lesson");
        CourseBuilder builder = new();
        builder.AddStartingLesson(lesson);

        var course = builder.Build();

        Assert.That(course.StartingLessons, Has.Member(lesson));
    }
}
