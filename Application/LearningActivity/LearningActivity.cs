using Domain.Entities.Curriculum;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Users;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.LearningActivity;

public class LearningActivity
{

    readonly StudentUser user;

    readonly ILearningElement learningElement;

    readonly Dictionary<Skill, int> skillExperience = new();


    public LearningActivity(StudentUser studentUser, ILearningElement learningElem)
    {
        user = studentUser;
        learningElement = learningElem;

        foreach (var skill in learningElem.Skills)
        {
            skillExperience.Add(skill, 0);
        }

    }

    public void Simulate(int maxExperience)
    {
        foreach (var skill in skillExperience)
        {
            skillExperience[skill.Key] = RandomNumberGenerator.GetInt32(
                (int)(maxExperience - .25 * maxExperience),
                (int)(maxExperience + .25 * maxExperience)
                );
        }
    }

    public LearningResult GetLearningResult()
        => new(
            learningElement,
            skillExperience
            );

    public void Finalize()
    {
        var result = GetLearningResult();
        user.Elp.Adjust(result);
        user.Esp.Adjust(result);
        user.Eip.Adjust(result);
    }

}