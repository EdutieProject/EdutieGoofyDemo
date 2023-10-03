using Domain.Entities.Aggregates;
using Domain.Entities.Curriculum.LearningElements;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks.EmbeddedTasks;
using Domain.Entities.Profiles.EIP;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using Domain.Enums;

namespace Tests;

public class EipTests
{

    static ILearningElement GetSampleReadingElem()
    {
        ReadingElement reading = new("Reading Element");
        reading.AddSkill(new Skill(1, "Skill1"));
        reading.AddSkill(new Skill(2, "Skill2"));
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
        StudentUser student = new("Student1");

        var learningAction = new LearningAction(student, reading);
        learningAction.Simulate(150);
        learningAction.Finalize();

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

        LearningAction learningAction1 = new(student1, reading);
        LearningAction learningAction2 = new(student2, reading);

        learningAction1.Simulate(120); learningAction1.Finalize();
        learningAction2.Simulate(90); learningAction2.Finalize();

        Console.WriteLine(learningAction1.TotalExperience);
        Console.WriteLine(learningAction2.TotalExperience);

        Assert.That(
            student1.Eip.IntelligencePoints[IntelligenceType.Logical], Is.GreaterThan(student2.Eip.IntelligencePoints[IntelligenceType.Logical]
        ));
    }


    [Test]
    public void TwoStudentsTimeDifferenceTest()
    {
        var reading = GetSampleReadingElem();

        StudentUser student1 = new("Student1");
        StudentUser student2 = new("Student2");
        student1.Eip.SetLastUpdate(DateTime.Now - TimeSpan.FromHours(1));
        student2.Eip.SetLastUpdate(DateTime.Now - TimeSpan.FromHours(10));

        LearningAction learningAction1 = new(student1, reading);
        LearningAction learningAction2 = new(student2, reading);

        
        learningAction1.Simulate(120); learningAction1.Finalize();
        learningAction2.Simulate(120); learningAction2.Finalize();

        Console.WriteLine(learningAction1.TotalExperience);
        Console.WriteLine(learningAction2.TotalExperience);

        Assert.That(
            student2.Eip.IntelligencePoints[IntelligenceType.Logical], 
            Is.GreaterThan(student1.Eip.IntelligencePoints[IntelligenceType.Logical])
        );
    }
}