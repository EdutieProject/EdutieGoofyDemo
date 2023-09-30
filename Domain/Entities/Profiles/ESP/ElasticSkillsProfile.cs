using Domain.Entities.Aggregates;
using Domain.Entities.Common;
using Domain.Entities.LearningElements;
using Domain.Entities.Profiles.Interfaces;
using Domain.Entities.TreeBasedCurriculum.Course;
using Domain.Entities.TreeBasedCurriculum.Lesson;

namespace Domain.Entities.Profiles.ESP;

// ESP: A profile which monitors specific skills of given user and their experience in it
public class ElasticSkillsProfile : ILearningProfile
{
    private HashSet<SkillBlock> skillBlocks = new();

    public DateTime LastUpadate { get; private set; }

    public void Adjust(LearningAction learningAction)
    {
        
        LastUpadate = DateTime.Now;
    }

}
