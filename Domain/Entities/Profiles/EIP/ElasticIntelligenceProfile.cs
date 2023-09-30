using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Aggregates;
using Domain.Entities.Profiles.Interfaces;

namespace Domain.Entities.Profiles.EIP;

// EIP: A profile designed to track user's intelligence parameters
public class ElasticIntelligenceProfile : ILearningProfile
{
    public DateTime LastUpadate { get; private set; }

    public void Adjust(LearningAction action)
    {
        throw new NotImplementedException();
    }
}
