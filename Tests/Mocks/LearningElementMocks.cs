using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks.EmbeddedTasks;
using Domain.Entities.Curriculum.LearningElements;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Curriculum.LearningElements.Tasks.StaticTasks;

namespace Tests.Mocks;

public static class LearningElementMocks
{
    /// <summary>
    /// Sample Reading elem with research, readingComprehension and visualization skills and one tasks with logical primaryIntelligence and Kinesthetic Secondary intelligence
    /// </summary>
    /// <returns>Reading Learning element</returns>
    public static ILearningElement GetSampleReadingElem()
    {
        ReadingElement reading = new("Reading Element");
        reading.AddSkill(Skill.Research);
        reading.AddSkill(Skill.ReadingComprehension);
        reading.AddSkill(Skill.Visualization);
        ReadingTask readingTask = new()
        {
            PrimaryItelligence = IntelligenceType.Logical,
            SecondaryIntelligence = IntelligenceType.Kinesthetic
        };
        reading.AddTask(readingTask);
        return reading;
    }

    /// <summary>
    /// Sample movie elem with research and information synthesis skills and 2 tasks with visual and kinesthethic primary intelligences and liguistic and interpersonal secondary intelligences
    /// </summary>
    /// <returns>Movie Learning Element</returns>
    public static ILearningElement GetSampleMovieElem()
    {
        MovieElement movie = new("Movie about the history of Poland");
        movie.AddSkill(Skill.Research);
        movie.AddSkill(Skill.InformationSynthesis);
        MovieTask[] movieTasks =
        {
            new()
            {
            PrimaryItelligence = IntelligenceType.Visual,
            SecondaryIntelligence = IntelligenceType.Linguistic
            },
            new()
            {
            PrimaryItelligence = IntelligenceType.Kinesthetic,
            SecondaryIntelligence = IntelligenceType.Interpersonal
            }
        };
        movieTasks.ToList().ForEach(movie.AddTask);
        return movie;
    }


    /// <summary>
    /// Learning element tree constructed without builders using entities and their methods. For testing purposes.
    /// </summary>
    /// <returns>Learning element tree</returns>
    public static ILearningElement GetSampleLearningTree()
    {
        MovieElement movieElem = new("Introductory movie");
        movieElem.AddSkill(Skill.CriticalThinking);
        movieElem.AddSkill(Skill.InformationSynthesis);
        movieElem.AddTask(
            new MovieTask()
            { 
                PrimaryItelligence = IntelligenceType.Musical,
                SecondaryIntelligence = IntelligenceType.Interpersonal
            }
        );
        movieElem.AddTask(
            new MovieTask()
            {
                PrimaryItelligence = IntelligenceType.Logical,
                SecondaryIntelligence = IntelligenceType.Naturalistic
            }
        );
        TaskElement taskElem = new("Fun task");
        taskElem.AddSkill(Skill.Adaptability);
        taskElem.AddSkill(Skill.AnalitycalThinking);
        taskElem.AddTask(
            new ProjectBasedTask()
            {
                PrimaryItelligence = IntelligenceType.Naturalistic,
                SecondaryIntelligence = IntelligenceType.Logical
            }
        );
        FigureElement figureElem = new("Interesting plot");
        figureElem.AddSkill(Skill.InformationSynthesis);
        figureElem.AddSkill(Skill.Visualization);
        figureElem.AddSkill(Skill.GoalSetting);
        figureElem.AddTask(
            new FigureTask()
            {
                PrimaryItelligence = IntelligenceType.Kinesthetic,
                SecondaryIntelligence = IntelligenceType.Logical
            }
        );
        
        // add task elem
        taskElem.Prev = movieElem; 
        movieElem.Next.Add(taskElem);
        // add figure elem
        figureElem.Prev = movieElem; 
        movieElem.Next.Add(figureElem);
        //add two elems from mocks
        var e1 = GetSampleReadingElem();
        e1.Prev = figureElem; figureElem.Next.Add(e1);
        var e2 = GetSampleMovieElem();
        e2.Prev = figureElem; figureElem.Next.Add(e2);
        // return the head
        return movieElem;
    }
}
