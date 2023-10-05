using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities.Curriculum.LearningElements.Interfaces;

public interface ILearningElement
{
    public string Name { get; }
    public ILearningElement? Prev { get; set; }
    public ILearningElement? Next { get; set; }

    public HashSet<Skill> Skills { get; }

    public HashSet<ILearningTask> Tasks { get; }

    public void AddSkill(Skill skill);
    public void RemoveSkill(Skill skill);

    public void AddTask(ILearningTask task);
    public void RemoveTask(ILearningTask task);

}
