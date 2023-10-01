using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Aggregates;
using Domain.Entities.Profiles.Interfaces;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities.Profiles.EIP;

// EIP: A profile designed to track user's intelligence parameters
public class ElasticIntelligenceProfile : ILearningProfile
{
    readonly Dictionary<IntelligenceType, int> intelligencePoints = new();
    public Dictionary<IntelligenceType, int> IntelligencePoints => intelligencePoints;

    public DateTime LastUpadate { get; private set; }

    public ElasticIntelligenceProfile()
    {
        foreach (IntelligenceType Itype in Enum.GetValues(typeof(IntelligenceType)))
        {
            intelligencePoints.Add(Itype, 0);
        }
        LastUpadate = DateTime.Now;
    }

    public void Adjust(LearningAction action)
    {
        var exp = action.TotalExperience;
        var timeFromLastUpdate = DateTime.Now - LastUpadate;

        // We need a better formula for adjusting Eip
        double modifyValue = Math.Cbrt((exp - 70) * timeFromLastUpdate.TotalMilliseconds / DateTime.Now.Ticks * 100000000000000);

        foreach (var learningTask in action.LearningElement.Tasks)
        {
            IntelligencePoints[learningTask.PrimaryItelligence] += (int)modifyValue;
            IntelligencePoints[learningTask.SecondaryIntelligence] += (int)modifyValue;
        }
    }
}
