using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Profiles.EIP;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.LearningElements.Tasks.StaticTasks
{
    internal class ProjectBasedTask : ILearningTask
    {
        public IntelligenceType PrimaryItelligence { get; set; }
        public IntelligenceType SecondaryIntelligence { get; set; }
    }
}
