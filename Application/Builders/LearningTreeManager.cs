using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders;

public class LearningTreeManager
{
    readonly ILearningElement head;
    public ILearningElement? Current { get; set; }
    public LearningTreeManager(ILearningElement learningElement)
        => head = learningElement;

    
    /// <summary>
    /// Retrieves the head of a learning tree
    /// </summary>
    public ILearningElement Head => head;

    void GetMaximumStageRecursive(ref int stage, ILearningElement elem)
    {
        bool stageAdded = false;
        foreach (var nextElem in elem.Next)
        {
            if (!stageAdded) stage += 1;
            GetMaximumStageRecursive(ref stage, nextElem);
            stageAdded = true;
        }
    }

    /// <summary>
    /// Returns max number of hops that one can make exploring this learning tree from head to end;
    /// </summary>
    /// <returns></returns>
    public int GetMaxStage()
    {
        int maxStage = 0;
        GetMaximumStageRecursive(ref maxStage, head);
        return maxStage;
    }


    /// <summary>
    /// Appends a given element to a given previous element in a tree
    /// </summary>
    /// <param name="element">Element to append</param>
    /// <param name="previousElem">Element to be set as previous</param>
    public void AppendElement(ILearningElement element, ILearningElement previousElem)
    {
        previousElem.Next.Add(element);
        element.Prev = previousElem;
    }

    /// <summary>
    /// Function which appends an element to the element set as Current of the manager. If no Current has been specified, does nothing
    /// </summary>
    /// <param name="element">Element to append</param>
    public void AppendElement(ILearningElement element)
    {
        if (Current is null) return;
        Current.Next.Add(element);
        element.Prev = Current;
    }

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
        FindElementsFromStageRecursive(stageToGet, ref elements, currentLevel + 1);
    }

    /// <summary>
    /// Gets element from a given level of a learning tree. For example: 0 would provide head, 1 would provide head.Next
    /// </summary>
    /// <param name="stage">Stage of the elements to retrieve</param>
    /// <returns>List of elements of given stage</returns>
    public List<ILearningElement> GetElementsFromStage(int stage)
    {
        List<ILearningElement> elements = new() { head };
        FindElementsFromStageRecursive(stage, ref elements);
        return elements;
    }


    void RetrieveAllElementsRecursive(ILearningElement current, ref List<ILearningElement> allElements)
    {
        allElements.Add(current);
        if (current.Next.Count == 0) return;

        foreach (var learningElement in current.Next)
            RetrieveAllElementsRecursive(learningElement, ref allElements);
    }

    /// <summary>
    /// Gets all elements that are present in a learning tree
    /// </summary>
    /// <returns>The list of all learning elements</returns>
    public List<ILearningElement> GetAllLearningElements()
    {
        var elements = new List<ILearningElement>();
        RetrieveAllElementsRecursive(head, ref elements); 
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
