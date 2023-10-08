using Application.Builders;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Tests.Mocks;

namespace Tests.BuilderTests;

public class LearningTreeBuilderTests
{
    [Test]
    public void GetLastElementsTest()
    {
        var head = LearningElementMocks.GetSampleLearningTree();
        var builder = new LearningTreeBuilder(head);
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
}
