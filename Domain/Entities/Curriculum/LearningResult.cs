using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum;

public record LearningResult(
    ILearningElement LearningElement,
    Dictionary<Skill, int> SkillExperience
    )
{
    public int TotalExperience => SkillExperience.Sum(o => o.Value);
}

