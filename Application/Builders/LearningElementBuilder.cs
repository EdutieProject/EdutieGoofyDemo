using Domain.Entities.Curriculum.LearningElements;
using Domain.Entities.Curriculum.LearningElements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders;

/// <summary>
/// A builder meant to create learning elements.
/// </summary>
public class LearningElementBuilder
{
    ILearningElement? learningElement;
    public LearningElementBuilder()
    { }


    /// <summary>
    /// Sets the created element to be a new Reading Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateReadingElement(string name)
    {
        learningElement = new ReadingElement(name);
        return this;
    }

    /// <summary>
    /// Sets the created element to be a new Figure Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateFigureElement(string name)
    {
        learningElement = new FigureElement(name);
        return this;
    }

    /// <summary>
    /// Sets the created element to be a new Task Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateTaskElement(string name)
    {
        learningElement = new TaskElement(name);
        return this;
    }

    /// <summary>
    /// Sets the created element to be a new Movie Element
    /// </summary>
    /// <param name="name">Name of given element</param>
    /// <returns></returns>
    public LearningElementBuilder CreateMovieElement(string name)
    {
        learningElement = new MovieElement(name); 
        return this;
    }
    /// <summary>
    /// Sets the previous element of the built one to the provided one.
    /// </summary>
    /// <param name="previous">Element to be set as previous</param>
    /// <returns></returns>
    public LearningElementBuilder AppendTo(ILearningElement previous)
    {
        if (learningElement != null)
        {
            learningElement.Prev = previous;
        }
        return this;
    }
    /// <summary>
    /// Sets next element to the provided element
    /// </summary>
    /// <param name="nextElem">Element to be set as next</param>
    /// <returns></returns>
    public LearningElementBuilder AppendElement(ILearningElement nextElem)
    {
        learningElement?.Next.Add(nextElem);
        nextElem.Prev = learningElement;
        return this;
    }

    public ILearningElement? Build()
        => learningElement;

}
