using Application.Builders;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.SyllabusElements;
using Domain.Entities.Users;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Application.NavigationEngine;

public class LessonNavigationEngine
{
    readonly StudentUser user;
    public LessonNavigationEngine(StudentUser user)
        => this.user = user;

    // NOT TESTED!!!!
    public List<ILearningElement> GetPossibleLearningElements(Lesson lesson)
    {
        LearningTreeManager lessonMgr = new(lesson.StartingElement);
        var allLessonElems = lessonMgr.GetAllLearningElements();
        var touchedLessonElems = user.Elp.LearningBlocks.ConvertAll(o => o.LearningElement).Where(allLessonElems.Contains);

        List<ILearningElement> possibleLearningElems = new();
        foreach (var element in touchedLessonElems)
        {
            possibleLearningElems.AddRange(element.Next);
        }
        return possibleLearningElems.Count > 0 ? possibleLearningElems : new List<ILearningElement>() { lesson.StartingElement };
    }

    // NOT TESTED!!!!
    public double GetDifficultyFactorForElem(ILearningElement element)
    {
        var primaryIntelligences = element.Tasks.ToList().ConvertAll(o => o.PrimaryItelligence);
        var secondaryIntelligences = element.Tasks.ToList().ConvertAll(o => o.SecondaryIntelligence);

        Dictionary<Skill, int> skillExperiences = new();
        foreach (var skill in element.Skills)
            skillExperiences[skill] = user.Esp.GetTotalExperienceOf(skill);

        int totalSkillExp = skillExperiences.Sum(o=>o.Value);
        int totalPrimaryIntelligencePoints = user.Eip.IntelligencePoints.Where(o => primaryIntelligences.Contains(o.Key)).Sum(o => o.Value);
        int totalSecndaryIntelligencePoints = (int)(user.Eip.IntelligencePoints.Where(o => secondaryIntelligences.Contains(o.Key)).Sum(o => o.Value)*0.5);
        

        double difficulty =
            (totalSkillExp + totalPrimaryIntelligencePoints + totalSecndaryIntelligencePoints)
            / (totalSkillExp * totalPrimaryIntelligencePoints * totalSecndaryIntelligencePoints + 1)
            * 10000;

        return difficulty;
    }

    public ILearningElement GetBestLearningElem(Lesson lesson)
    {
        var possibleElems = GetPossibleLearningElements(lesson);

        return possibleElems.OrderByDescending(GetDifficultyFactorForElem).First();
    }

}
