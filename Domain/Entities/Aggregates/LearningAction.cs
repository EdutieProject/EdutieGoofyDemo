using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users;
using System.Security.Cryptography;

namespace Domain.Entities.Aggregates;

public class LearningAction
{

    readonly StudentUser user;

    readonly ILearningElement learningElement;
    public ILearningElement LearningElement => learningElement;

    readonly Dictionary<Skill, int> skillExperience = new();
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

    public void Simulate(int maxExperience)
    {
        foreach (var skill in  skillExperience)
        {
            skillExperience[skill.Key] = RandomNumberGenerator.GetInt32(
                (int)(maxExperience - .25 * maxExperience), 
                (int)(maxExperience+ .25*maxExperience)
                );
        }
    }

    public void Finalize()
    {
        user.Elp.Adjust(this);
        user.Esp.Adjust(this);
        user.Eip.Adjust(this);
    }

}
