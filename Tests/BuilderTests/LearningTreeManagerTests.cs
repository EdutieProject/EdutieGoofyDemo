using Application.Builders;
using Domain.Entities.Curriculum.LearningElements;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Tests.Mocks;

namespace Tests.BuilderTests;

public class LearningTreeManagerTests
{
    [Test]
    public void GetLastElementsTest()
    {
        var head = LearningElementMocks.GetSampleLearningTree();
        var builder = new LearningTreeManager(head);
        List<ILearningElement> elements = builder.GetLastElements();
        List<ILearningElement> properElements = new List<ILearningElement>()
        {
            LearningElementMocks.GetSampleTaskElem(),
            LearningElementMocks.GetSampleReadingElem(),
            LearningElementMocks.GetSampleMovieElem(),
        };

        Assert.That(properElements, Has.Count.EqualTo(elements.Count));
        CollectionAssert.AreEquivalent(
            elements.ConvertAll(o=>o.Name), 
            properElements.ConvertAll(o=>o.Name)
            );
    }

    [Test]
    public void GetElementsFromStageTest1()
    {
        var head = LearningElementMocks.GetSampleLearningTree();
        List<ILearningElement> actual = new LearningTreeManager(head).GetElementsFromStage(0);
        var expected = new List<ILearningElement>() { head };

        CollectionAssert.AreEqual(expected, actual);

    }

    [Test]
    public void GetElementsFromStageTest2()
    {
        var head = LearningElementMocks.GetSampleLearningTree();

        var expected = new List<ILearningElement>()
        {
            LearningElementMocks.GetSampleReadingElem(),
            LearningElementMocks.GetSampleMovieElem(),
        }
        .ConvertAll(o=>o.Name);
        var actual = new LearningTreeManager(head)
            .GetElementsFromStage(2)
            .ConvertAll(o=>o.Name);

        CollectionAssert.AreEquivalent(expected, actual);
    }

    [Test]
    public void MaximumStageTest()
    {
        var head = LearningElementMocks.GetSampleLearningTree();
        int length = new LearningTreeManager(head).GetMaxStage();

        Console.WriteLine($"Max stage: {length}");

        Assert.That(length, Is.EqualTo(2));
    }

    [Test]
    public void GetAllElemsTest()
    {
        var elem1 = new ReadingElement("reading1");
        var elem2 = new FigureElement("figure1");
        var elem3 = new ReadingElement("reading2");
        elem1.Next.Add(elem2);
        elem2.Next.Add(elem3);

        var actual = new LearningTreeManager(elem1).GetAllLearningElements();
        var expected = new List<ILearningElement>() { elem1, elem2, elem3 };

        Assert.That(actual, Is.EquivalentTo(expected));
    }


    [Test]
    public void SkillExtensionTest1()
    {
        var actual = new List<ILearningElement>()
        {
            LearningElementMocks.GetSampleReadingElem(),
            LearningElementMocks.GetSampleMovieElem(),
            LearningElementMocks.GetSampleTaskElem(),
        }
        .GetElementOfSkill(Domain.Enums.Skill.ReadingComprehension);

        var expected = LearningElementMocks.GetSampleReadingElem();

        Assert.That(actual.Name, Is.EqualTo(expected.Name));
    }

    [Test]
    public void SkillExtensionTest2()
    {
        var head = LearningElementMocks.GetSampleLearningTree();
        var elementsStage2 = new LearningTreeManager(head).GetElementsFromStage(2);
        var elementsOfSkill = elementsStage2.GetElementsOfSkill(Domain.Enums.Skill.Research);

        Assert.That(elementsOfSkill, Is.EquivalentTo(elementsStage2));
    }

    [Test]
    public void IntelligenceExtensionTest1()
    {
        List<ILearningElement> list = new()
        {
            LearningElementMocks.GetSampleReadingElem(),
            LearningElementMocks.GetSampleMovieElem(),
            LearningElementMocks.GetSampleTaskElem(),
        };
        var actual = list.GetElementOfPrimaryIntelligence(Domain.Enums.IntelligenceType.Naturalistic);
        var expected = LearningElementMocks.GetSampleTaskElem();

        Assert.That(
            actual.Name, 
            Is.EqualTo(expected.Name)
            );
    }

    [Test]
    public void IntelligenceExtensionTest2()
    {
        List<ILearningElement> list = new()
        {
            LearningElementMocks.GetSampleReadingElem(),
            LearningElementMocks.GetSampleMovieElem(),
            LearningElementMocks.GetSampleTaskElem(),
        };
        var actual = list.GetElementsOfPrimaryIntelligence(Domain.Enums.IntelligenceType.Naturalistic).ToList().ConvertAll(o=>o.Name);
        var expected = new List<string>()
            {
            LearningElementMocks.GetSampleTaskElem().Name
            };

        Assert.That(
            actual,
            Is.EqualTo(expected)
            );
    }

}
