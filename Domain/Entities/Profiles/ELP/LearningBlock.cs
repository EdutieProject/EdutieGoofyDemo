using Domain.Entities.Curriculum.LearningElements.Interfaces;

namespace Domain.Entities.Profiles.ELP;

public record LearningBlock(ILearningElement LearningElement, int TotalExperience, DateTime CreatedOn);
