﻿using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Enums;
using System.Security.Cryptography;

namespace Domain.Entities.Curriculum;

/// <summary>
/// Record which purpose is to represent what has been achieved in learning activity.
/// </summary>
/// <param name="LearningElement">learning element in the activity</param>
/// <param name="SkillExperience">skill experience pairs gained in this activity</param>
public record LearningResult(
    ILearningElement LearningElement,
    Dictionary<Skill, int> SkillExperience
    )
{
    public int TotalExperience => SkillExperience.Sum(o => o.Value);

    //Constructor meant for testing - it randomizes performance through assigning random experience based on base performance.
    public LearningResult(int performance, ILearningElement learningElem) : this(learningElem, new())
    {
        foreach (var skill in learningElem.Skills)
        {
            SkillExperience[skill] = RandomNumberGenerator.GetInt32((int)(performance*.75), (int)(performance*1.25));
        }
    }
}

