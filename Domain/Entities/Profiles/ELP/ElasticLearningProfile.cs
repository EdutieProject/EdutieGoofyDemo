using Domain.Entities.Aggregates;
using Domain.Entities.Profiles.Interfaces;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Profiles.ELP
{
    // ELP: a history of learning activities performed by users - it serves as a monitoring tool for user's performance
    public class ElasticLearningProfile : ILearningProfile
    {
        private readonly List<LearningBlock> learningBlocks = new();
        public List<LearningBlock> LearningBlocks => learningBlocks;
        public DateTime LastUpadate { get; private set; } = DateTime.Now;


        public ElasticLearningProfile() { }

        public void Adjust(LearningAction action)
        {
            var block = new LearningBlock(action.LearningElement, action.TotalExperience, DateTime.Now);
            learningBlocks.Add(block);
        }

    }
}
