using Domain.Entities.Aggregates;
using Domain.Entities.Profiles.Interfaces;

namespace Domain.Entities.Profiles.ESP;

// ESP: A profile which monitors specific skills of given user and their experience in it
public class ElasticSkillsProfile : ILearningProfile
{
    private readonly HashSet<SkillBlock> skillBlocks = new();
    public HashSet<SkillBlock> SkillBlocks => skillBlocks;

    public DateTime LastUpadate { get; private set; }

    public void Adjust(LearningAction learningAction)
    {
        foreach (var skillExpPair in learningAction.SkillExperience)
        {
            var sBlock = new SkillBlock(skillExpPair.Key, skillExpPair.Value, DateTime.Now);
            skillBlocks.Add(sBlock);
        }
        LastUpadate = DateTime.Now;
    }

}
