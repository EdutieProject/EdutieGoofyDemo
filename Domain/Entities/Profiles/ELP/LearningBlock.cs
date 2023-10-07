using Domain.Entities.Curriculum.LearningElements.Interfaces;

namespace Domain.Entities.Profiles.ELP;

/// <summary>
/// Block which is a single element of Elastic learning Profile
/// </summary>
/// <param name="LearningElement">Learning element which user choose</param>
/// <param name="TotalExperience">Experience gained in learning activity</param>
/// <param name="CreatedOn">Date of block creation - to perserve history</param>
public record LearningBlock(ILearningElement LearningElement, int TotalExperience, DateTime CreatedOn);
