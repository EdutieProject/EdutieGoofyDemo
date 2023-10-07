using Domain.Entities.Curriculum;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Profiles.Interfaces;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Profiles.ELP;


/// <summary>
/// Learning Profile which tracks users history of learning activities
/// </summary>
public class ElasticLearningProfile : ILearningProfile
{
    private readonly List<LearningBlock> learningBlocks = new();
    public List<LearningBlock> LearningBlocks => learningBlocks;
    public DateTime LastUpadate { get; private set; } = DateTime.Now;


    public ElasticLearningProfile() { }

    public void Adjust(LearningResult result)
    {
        var block = new LearningBlock(result.LearningElement, result.TotalExperience, DateTime.Now);
        learningBlocks.Add(block);
    }

    public int GetTotalExperienceOf(ILearningElement learningElem)
    {
        int totalExperience = learningBlocks.Where(o => o.LearningElement == learningElem).Sum(o => o.TotalExperience);
        return totalExperience;
    }

}
