using Domain.Entities.Curriculum;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Profiles.ELP;
using Domain.Entities.Users;
using Tests.Mocks;

namespace Tests.LearningProfileTests;

public class ElpTests
{

    [SetUp]
    public void Setup()
    { }

    [Test]
    public void ElpConstructionTest()
    {
        StudentUser student = new("Student1");

        Assert.That(
            student.Elp.LearningBlocks,
            Is.EqualTo(new List<LearningBlock>())
            );
    }

    [Test]
    public void ElpBaseTest()
    {
        StudentUser student = new("Student1");
        ILearningElement learningElement = LearningElementMocks.GetSampleMovieElem();
        
        var result = new LearningResult(100, learningElement);
        student.Elp.Adjust(result);

        Assert.That(student.Elp.LearningBlocks, Has.Count.EqualTo(1));
    }

    [Test]
    public void ElpMultipleBlocksTest()
    {
        StudentUser student = new("Student1");
        ILearningElement learningElement = LearningElementMocks.GetSampleMovieElem();

        for(int i = 60; i<=180; i+=60) 
        {
            var result = new LearningResult(i, learningElement);
            student.Elp.Adjust(result);
        }

        ILearningElement learningElement2 = LearningElementMocks.GetSampleReadingElem();
        var result2 = new LearningResult(123, learningElement2);
        student.Elp.Adjust(result2);

        Assert.That(student.Elp.LearningBlocks, Has.Count.EqualTo(4));
    }

    [Test]
    public void ElpElementExperienceTest()
    {
        StudentUser student = new("Student1");
        ILearningElement learningElement = LearningElementMocks.GetSampleMovieElem();

        for (int i = 0; i < 3; i++)
        {
            var result = new LearningResult(learningElement, new());
            result.SkillExperience.Add(learningElement.Skills.FirstOrDefault(), 60);
            student.Elp.Adjust(result);
        }

        var totalExperience = student.Elp.GetTotalExperienceOf(learningElement);

        Assert.That(totalExperience, Is.EqualTo(180));
    }


}