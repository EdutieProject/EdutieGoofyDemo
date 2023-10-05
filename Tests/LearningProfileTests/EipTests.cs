using Domain.Entities.Curriculum;
using Domain.Entities.Users;
using Domain.Enums;
using Tests.Mocks;

namespace Tests.LearningProfileTests;

public class EipTests
{


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
        var reading = LearningElementMocks.GetSampleReadingElem();
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
        var reading = LearningElementMocks.GetSampleReadingElem();

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
        var reading = LearningElementMocks.GetSampleReadingElem();

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