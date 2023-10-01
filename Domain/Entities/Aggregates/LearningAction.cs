using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using System.Security.Cryptography;

namespace Domain.Entities.Aggregates;

public class LearningAction
{

    StudentUser user;

    ILearningElement learningElement;
    public ILearningElement LearningElement => learningElement;

    Dictionary<Skill, int> skillExperience = new();
    public Dictionary<Skill, int> SkillExperience => skillExperience;
    public int TotalExperience => skillExperience.Sum(o => o.Value);

    public LearningAction(StudentUser studentUser, ILearningElement learningElem)
    {
        user = studentUser;
        learningElement = learningElem;

        foreach (var skill in learningElem.Skills) 
        {
            SkillExperience.Add(skill, 0);
        }

    }

    public void Simulate()
    {

    }

    public void Finalize()
    {
        user.Elp.Adjust(this);
        user.Esp.Adjust(this);
        user.Eip.Adjust(this);
    }

}
