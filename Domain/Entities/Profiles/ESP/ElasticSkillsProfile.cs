using Domain.Entities.Curriculum;
using Domain.Entities.Profiles.Interfaces;
using Domain.Enums;

namespace Domain.Entities.Profiles.ESP;

// ESP: A profile which monitors specific skills of given user and their experience in it
public class ElasticSkillsProfile : ILearningProfile
{
    private readonly HashSet<SkillBlock> skillBlocks = new();
    public HashSet<SkillBlock> SkillBlocks => skillBlocks;

    public DateTime LastUpadate { get; private set; } = DateTime.Now;

    public void Adjust(LearningResult result)
    {
        foreach (var skillExpPair in result.SkillExperience)
        {
            var sBlock = new SkillBlock(skillExpPair.Key, skillExpPair.Value, DateTime.Now);
            skillBlocks.Add(sBlock);
        }
        LastUpadate = DateTime.Now;
    }

    public int GetTotalExperienceOf(Skill skill)
    {
        var totalExperience = skillBlocks.Where(o=>o.Skill==skill).Sum(o=>o.TotalExperience);
        return totalExperience;
    }

}
