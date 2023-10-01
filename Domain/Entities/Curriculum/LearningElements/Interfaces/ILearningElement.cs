using Domain.Entities.Curriculum.LearningElements.Tasks;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements.Interfaces;

public interface ILearningElement
{
    public string Name { get; }
    public ILearningElement? Prev { get; }
    public ILearningElement? Next { get; }

    public HashSet<Skill> Skills { get; }

    public HashSet<ILearningTask> Tasks { get; }

    public void AssessUserPerformance(StudentUser user);

    public void AddSkill(Skill skill);
    public void RemoveSkill(Skill skill);

    public void AddTask(ILearningTask task);
    public void RemoveTask(ILearningTask task);

}
