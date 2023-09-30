using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Profiles.ESP;

namespace Domain.Entities.LearningElements;

// Skill identifiers inside a Learning Element
public record SkillTag(Skill Skill, string AssociatedQuestion, string ExpectedAnswer);
