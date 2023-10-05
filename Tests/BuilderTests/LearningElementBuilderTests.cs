using Application.Builders;
using Domain.Entities.Curriculum.LearningElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BuilderTests;

public class LearningElementBuilderTests
{
    [Test]
    public void CreateReadingTest()
    {
        LearningElementBuilder builder = new();
        var le = builder
            .CreateReadingElement("element")
            .Build();
        Assert.That(le, Is.TypeOf(typeof(ReadingElement)));
    }

    [Test]
    public void CreateMovieTest()
    {
        LearningElementBuilder builder = new();
        var le = builder
            .CreateMovieElement("element")
            .Build();
        Assert.That(le, Is.TypeOf(typeof(MovieElement)));
    }

    [Test]
    public void CreateFigureTest()
    {
        LearningElementBuilder builder = new();
        var le = builder
            .CreateFigureElement("element")
            .Build();
        Assert.That(le, Is.TypeOf(typeof(FigureElement)));
    }

    [Test]
    public void CreateTaskTest()
    {
        LearningElementBuilder builder = new();
        var le = builder
            .CreateTaskElement("element")
            .Build();
        Assert.That(le, Is.TypeOf(typeof(TaskElement)));
    }

    [Test]
    public void AddNextElementTest()
    {
        LearningElementBuilder builder = new();
        LearningElementBuilder builder2 = new();
        var firstElemBuilder = builder
            .CreateMovieElement("movie");
        var le2 = builder2.CreateFigureElement("figure").Build();
        var le1 = firstElemBuilder
            .AppendElement(le2)
            .Build();
        Assert.Multiple(() =>
        {
            Assert.That(le1.Next, Has.Member(le2));
            Assert.That(le2.Prev, Is.EqualTo(le1));
        });
    }

    [Test]
    public void AddPreviousElementTest()
    {
        LearningElementBuilder builder = new();
        LearningElementBuilder builder2 = new();
        var firstElemBuilder = builder
            .CreateMovieElement("movie");
        var le2 = builder2.CreateFigureElement("figure").Build();
        var le1 = firstElemBuilder
            .AppendTo(le2)
            .Build();
        Assert.Multiple(() =>
        {
            Assert.That(le1.Prev, Is.EqualTo(le2));
            Assert.That(le2.Next, Has.Member(le1));
        });
    }
}
