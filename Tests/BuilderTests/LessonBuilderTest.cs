using Application.Builders;
using Tests.Mocks;

namespace Tests.BuilderTests;

public class LessonBuilderTest
{
    [Test]
    public void LessonBuilderConstructionTest()
    {
        var lesson = new LessonBuilder("Lesson").Build();
        Assert.Multiple(() =>
        {
            Assert.That(lesson.Name, Is.EqualTo("Lesson"));
            Assert.That(lesson.StartingElement, Is.Null);
        });
    }

    [Test]
    public void LessonBuilderNavigationPropsTest()
    {
        var builder = new LessonBuilder(string.Empty);
        var lesson1 = builder.SetLessonName("Lesson1").Build();
        var lesson2 = builder.SetLessonName("Lesson2").Build();
        var Lesson = builder
            .AddPreviousLesson(lesson1)
            .AddNextLesson(lesson2)
            .Build();
        Assert.Multiple(() =>
        {
            Assert.That(Lesson.Next, Has.Member(lesson2));
            Assert.That(Lesson.Prev, Is.EqualTo(lesson1));
        });
    }

    [Test]
    public void LessonBuilderTreeTest()
    {
        var builder = new LessonBuilder("Example lesson");
        var head = LearningElementMocks.GetSampleLearningTree();
        builder.SetStartingElement(head);
        var lesson = builder.Build();
        Assert.Multiple(()=>{
            Assert.That(lesson.StartingElement.Next, Has.Count.EqualTo(2));
            Assert.That(lesson.StartingElement.Next.Where(o => o.Next.Count > 1).First().Next, Has.Count.EqualTo(2));
        });
    }
}
