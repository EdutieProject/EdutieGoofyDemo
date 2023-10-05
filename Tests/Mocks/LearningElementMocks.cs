using Domain.Entities.Curriculum.LearningElements.Interfaces;
using Domain.Entities.Curriculum.LearningElements.Tasks.EmbeddedTasks;
using Domain.Entities.Curriculum.LearningElements;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks;

public static class LearningElementMocks
{
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
}
