using Domain.Entities.Curriculum;

namespace Domain.Entities.Profiles.Interfaces;

public interface ILearningProfile
{
    public DateTime LastUpadate { get; }
    public abstract void Adjust(LearningResult result);
}
