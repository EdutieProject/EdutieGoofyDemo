using Domain.Entities.Curriculum;
using Domain.Entities.Profiles.Interfaces;
using Domain.Enums;

namespace Domain.Entities.Profiles.EIP;

/// <summary>
/// Profile designed to track specific Intelligences of the user
/// </summary>
public class ElasticIntelligenceProfile : ILearningProfile
{
    readonly Dictionary<IntelligenceType, int> intelligencePoints = new();
    public Dictionary<IntelligenceType, int> IntelligencePoints => intelligencePoints;

    public DateTime LastUpadate { get; private set; } = DateTime.Now;

    public ElasticIntelligenceProfile()
    {
        foreach (IntelligenceType InType in Enum.GetValues(typeof(IntelligenceType)))
        {
            intelligencePoints.Add(InType, 0);
        }
        LastUpadate = DateTime.Now;
    }

    // We need a better formula for adjusting Eip
    int CalculateIntelligencePoints(int gainedExperience)
    {
        var timeFromLastUpdate = DateTime.Now - LastUpadate;
        int formula(int x) => (int)Math.Cbrt((x - 70) * timeFromLastUpdate.TotalMilliseconds / DateTime.Now.Ticks * 100000000000000);
        var calculated = formula(gainedExperience);

        return calculated != 0 ? calculated : gainedExperience / 10 - 6;
    }



    public void Adjust(LearningResult result)
    {
        int modifyValue = CalculateIntelligencePoints(result.TotalExperience);

        foreach (var learningTask in result.LearningElement.Tasks)
        {
            IntelligencePoints[learningTask.PrimaryItelligence] += modifyValue;
            IntelligencePoints[learningTask.SecondaryIntelligence] += modifyValue;
        }
    }

    /// <summary>
    /// Function only for testing purposes
    /// </summary>
    /// <param name="time">time to be set</param>
    public void SetLastUpdate(DateTime time)
        => LastUpadate = time;
}
