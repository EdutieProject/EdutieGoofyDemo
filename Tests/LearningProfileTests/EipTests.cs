using Domain.Entities.Curriculum;
using Domain.Entities.Curriculum.LearningElements;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks.EmbeddedTasks;
using Domain.Entities.Profiles.EIP;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using Domain.Enums;

namespace Tests.LearningProfileTests;

public class EipTests
{

    static ILearningElement GetSampleReadingElem()
    {
        ReadingElement reading = new("Reading Element");
        reading.AddSkill(Skill.Research);
        reading.AddSkill(Skill.ReadingComprehension);
        ReadingTask readingTask = new()
        {
            PrimaryItelligence = IntelligenceType.Logical,
            SecondaryIntelligence = IntelligenceType.Kinesthetic
        };
        reading.AddTask(readingTask);
        return reading;
    }

    [SetUp]
    public void Setup()
    { }

    [Test]
    public void EipConstructionTest()
    {
        StudentUser student = new("Student1");

        Assert.That(
            student.Eip.IntelligencePoints.Keys.ToArray(),
            Is.EqualTo(Enum.GetValues(typeof(IntelligenceType)))
            );
    }


    [Test]
    public void OneStudentEipTest()
    {
        var reading = GetSampleReadingElem();
        var learningResult = new LearningResult(120, reading);

        StudentUser student = new("Student1");
        student.Eip.Adjust(learningResult);

        Assert.That(
            student.Eip.IntelligencePoints[IntelligenceType.Kinesthetic], Is.GreaterThan(0)
            );
    }


    [Test]
    public void TwoStudentsComparisonTest()
    {
        var reading = GetSampleReadingElem();

        StudentUser student1 = new("Student1");
        StudentUser student2 = new("Student2");

        var learningResult1 = new LearningResult(125, reading);
        var learningResult2 = new LearningResult(60, reading);

        student1.Eip.Adjust(learningResult1);
        student2.Eip.Adjust(learningResult2);

        Assert.That(
            student1.Eip.IntelligencePoints[IntelligenceType.Logical], Is.GreaterThan(student2.Eip.IntelligencePoints[IntelligenceType.Logical]
        ));
    }


    [Test]
    public void TwoStudentsTimeDifferenceTest()
    {
        var reading = GetSampleReadingElem();

        var learningResult = new LearningResult(100, reading);

        StudentUser student1 = new("Student1");
        StudentUser student2 = new("Student2");
        student1.Eip.SetLastUpdate(DateTime.Now - TimeSpan.FromHours(1));
        student2.Eip.SetLastUpdate(DateTime.Now - TimeSpan.FromHours(10));

        student1.Eip.Adjust(learningResult);
        student2.Eip.Adjust(learningResult);

        Assert.That(
            student2.Eip.IntelligencePoints[IntelligenceType.Logical],
            Is.GreaterThan(student1.Eip.IntelligencePoints[IntelligenceType.Logical])
        );
    }
}