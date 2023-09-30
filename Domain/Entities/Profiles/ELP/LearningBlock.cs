using Domain.Entities.Common;

namespace Domain.Entities.Profiles.ELP;

public record LearningBlock(LearningElement LearningElement, int TotalExperience, DateTime CreatedOn);
