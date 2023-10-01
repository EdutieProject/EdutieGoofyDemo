using Domain.Entities.Profiles.EIP;
using Domain.Enums;


namespace Domain.Entities.Curriculum.LearningElements.Tasks;

public interface ILearningTask
{
    public IntelligenceType PrimaryItelligence { get; set; }
    public IntelligenceType SecondaryIntelligence { get; set; }

}
