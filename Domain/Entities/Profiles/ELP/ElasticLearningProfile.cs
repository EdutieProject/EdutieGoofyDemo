using Domain.Entities.Aggregates;
using Domain.Entities.Common;
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
        private List<LearningBlock> learningBlocks = new();

        public DateTime LastUpadate { get; private set; }

        public void Adjust(LearningAction action)
        {
            LearningBlock block = new(action.LearningElement, action.Experience, DateTime.Now);
            learningBlocks.Add(block);
            LastUpadate = DateTime.Now;
        }

        public int GetTotalExperienceOf(LearningElement learningElement) 
        {
            int totalExperience = learningBlocks
                .Where(o => o.LearningElement == learningElement)
                .Sum(o => o.TotalExperience);
            return totalExperience;
        }



        // ============ Display functions =============

        public void DisplayTotalExperienceOf(LearningElement element)
        {
            Console.WriteLine($"Total experience gained in {element.Title}: {GetTotalExperienceOf(element)}");
        }

        public void DisplayAllBlocks()
        {
            foreach (var block in learningBlocks)
            {
                Console.WriteLine($"{block.LearningElement.Title} - experience: {block.TotalExperience}");
            }
        }

        public void DisplayBulk()
        {
            foreach (var learningElem in learningBlocks.ConvertAll(o => o.LearningElement).Distinct())
            {
                Console.WriteLine($"Total experience in {learningElem.Title} : {GetTotalExperienceOf(learningElem)}");
            }
        }
    }
}
