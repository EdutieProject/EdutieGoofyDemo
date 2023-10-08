using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders;

public class LearningTreeBuilder
{
    readonly ILearningElement head;
    public LearningTreeBuilder(ILearningElement learningElement)
        => head = learningElement;


    
    void FindLastElementsRecursive(ILearningElement elem, ref List<ILearningElement> lastElements)
    {
        if (elem.Next.Count == 0) lastElements.Add(elem);
        foreach (var learningElement in elem.Next)
        {
            FindLastElementsRecursive(learningElement, ref lastElements);
        }
    }

    /// <summary>
    /// Retrieves elements of learning tree with no element after them. Those are great places for extensions.
    /// </summary>
    /// <returns>List of last elements of a tree</returns>
    public List<ILearningElement> GetLastElements()
    {
        List<ILearningElement> lastElements = new();
        FindLastElementsRecursive(head, ref lastElements);
        return lastElements;
    }


    void FindElementsFromStageRecursive(int stageToGet, ref List<ILearningElement> elements, int currentLevel= 0)
    {
        if (currentLevel == stageToGet)
        {
            return;
        }
        List<ILearningElement> newElements = new();
        foreach(var learningElement in elements) 
        {
            learningElement.Next.ToList().ForEach(newElements.Add);
        }
        elements = newElements;
        foreach (var learningElement in newElements)
        {
            FindElementsFromStageRecursive(stageToGet, ref elements, currentLevel + 1);
        }
    }

    /// <summary>
    /// Gets element from a given level of a learning tree. For example: 0 would provide head, 1 would provide head.Next
    /// </summary>
    /// <param name="stage">Stage of the elements to retrieve</param>
    /// <returns>List of elements of given stage</returns>
    public List<ILearningElement> GetElementsFromStage(int stage)
    {
        List<ILearningElement> elements = new();
        FindElementsFromStageRecursive(stage, ref elements);
        return elements;
    }
}


public static class LearningTreeBuilderExtensions
{
    /// <summary>
    /// Gets all elements of sequence that require given skill
    /// </summary>
    /// <param name="learningElements">sequence to be filtered</param>
    /// <param name="skill">Searched skill</param>
    /// <returns>IlearningElement</returns>
    public static IEnumerable<ILearningElement> GetElementsOfSkill(this IEnumerable<ILearningElement> learningElements, Skill skill)
        => learningElements.Where(o => o.Skills.Contains(skill));

    /// <summary>
    /// Gets first element that has a specified skill
    /// </summary>
    /// <param name="learningElements">sequence to filter</param>
    /// <param name="skill">Searched skill</param>
    /// <returns>IlearningElement</returns>
    public static ILearningElement GetElementOfSkill(this IEnumerable<ILearningElement> learningElements, Skill skill)
        => learningElements.First(o => o.Skills.Contains(skill));

    /// <summary>
    /// Gets all of elements of given enumerable that have primary intelligence equal to the provided one
    /// </summary>
    /// <param name="learningElements">sequence to be filtered</param>
    /// <param name="intelligenceType">Searched intelligence</param>
    /// <returns>IlearningElement</returns>
    public static IEnumerable<ILearningElement> GetElementsOfPrimaryIntelligence(this IEnumerable<ILearningElement> learningElements, IntelligenceType intelligenceType)
        => learningElements.Where(o => o.Tasks.ToList().ConvertAll(o => o.PrimaryItelligence).Contains(intelligenceType));

    /// <summary>
    /// Returns a first present element of a given primary intelligence
    /// </summary>
    /// <param name="learningElements">sequence to be filtered</param>
    /// <param name="intelligenceType">intelligence</param>
    /// <returns>IlearningElement</returns>
    public static ILearningElement GetElementOfPrimaryIntelligence(this IEnumerable<ILearningElement> learningElements, IntelligenceType intelligenceType)
        => learningElements.Where(o => o.Tasks.ToList().ConvertAll(o => o.PrimaryItelligence).Contains(intelligenceType)).FirstOrDefault();

}
