using Domain.Entities.Curriculum;
using Domain.Entities.Profiles.ELP;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mocks;

namespace Tests.LearningProfileTests;

public class EspTests
{
    [SetUp]
    public void Setup()
    { }

    [Test]
    public void EspConstructionTest()
    {
        StudentUser student = new("Student1");

        Assert.That(
            student.Esp.SkillBlocks,
            Is.EqualTo(new HashSet<SkillBlock>())
            );
    }

    [Test]
    public void EspBaseTest()
    {
        StudentUser student = new("Student1");
        var result = new LearningResult(100, LearningElementMocks.GetSampleMovieElem());
        student.Esp.Adjust(result);

        Assert.That(
            student.Esp.GetTotalExperienceOf(Domain.Enums.Skill.InformationSynthesis),
            Is.AtLeast(75)
            );
    }
}
