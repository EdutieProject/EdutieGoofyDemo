using Application.Builders;
using Application.LearningActivity;
using Application.NavigationEngine;
using Domain.Entities.Curriculum.SyllabusElements;
using Domain.Entities.Users;
using Domain.Enums;
using System.Net.WebSockets;

namespace Example;

internal class Program
{
    /// <summary>
    /// Builds an example course for showcase purposes using builders
    /// </summary>
    /// <returns>Built course</returns>
    static Course BuildCourseExample()
    {
        LearningElementBuilder learningElemBuilder = new();
        var elem1 = learningElemBuilder
            .CreateMovieElement("Introduction to organic chemistry")
            .AddSkills(new Skill[] { Skill.AnalitycalThinking, Skill.Adaptability })
            .AddTask(IntelligenceType.Visual, IntelligenceType.Logical)
            .Build();
        var elem2 = learningElemBuilder.
            CreateReadingElement("Organic compounds")
            .AddSkills(new Skill[] { Skill.ReadingComprehension, Skill.CriticalThinking })
            .AddTask(IntelligenceType.Intrapersonal, IntelligenceType.Kinesthetic)
            .Build();
        var elem3 = learningElemBuilder.
            CreateTaskElement("Solve a problem")
            .AddSkills(new Skill[] { Skill.Visualization, Skill.Adaptability, Skill.Creativity })
            .AddTask(IntelligenceType.Linguistic, IntelligenceType.Kinesthetic)
            .Build();
        var elem4 = learningElemBuilder.
            CreateMovieElement("Details about alcohols")
            .AddSkills(new Skill[] { Skill.Research, Skill.GoalSetting })
            .AddTask(IntelligenceType.Naturalistic, IntelligenceType.Visual)
            .Build();
        var elem5 = learningElemBuilder.
            CreateTaskElement("Describe alcohols' properties in practice")
            .AddSkills(new Skill[] { Skill.GoalSetting, Skill.InformationSynthesis, Skill.Research})
            .AddTask(IntelligenceType.Kinesthetic, IntelligenceType.Naturalistic)
            .Build();
        var elem6 = learningElemBuilder.
            CreateReadingElement("How to harness Hydrocarbon power")
            .AddSkills(new Skill[] { Skill.InformationSynthesis, Skill.CriticalThinking, Skill.Visualization})
            .AddTask(IntelligenceType.Kinesthetic, IntelligenceType.Naturalistic)
            .Build();
        var elem7 = learningElemBuilder.
            CreateFigureElement("Read a chart of alcohols' reactivity")
            .AddSkills(new Skill[] { Skill.InformationSynthesis, Skill.CriticalThinking, Skill.Metacognition })
            .AddTask(IntelligenceType.Visual, IntelligenceType.Logical)
            .Build();
        var elem8 = learningElemBuilder.
            CreateTaskElement("Proove that alcohol is bad for your body's internals")
            .AddSkills(new Skill[] {Skill.AnalitycalThinking, Skill.Creativity, Skill.InformationSynthesis })
            .AddTask(IntelligenceType.Logical, IntelligenceType.Naturalistic)
            .Build();

        LearningTreeManager treeMgr = new(elem1);

        treeMgr.Current = elem1;
        treeMgr.AppendElement(elem2);
        treeMgr.AppendElement(elem3);

        treeMgr.Current = elem3;
        treeMgr.AppendElement(elem4);
        treeMgr.AppendElement(elem5);

        treeMgr.Current = elem4;
        treeMgr.AppendElement(elem6);
        treeMgr.AppendElement(elem7);
        // append 8 to 7
        treeMgr.AppendElement(elem8, elem7);

        var head = treeMgr.Head;

        LessonBuilder lessonBuilder = new("Organic chemistry");
        lessonBuilder.SetStartingElement(head);
        var lesson = lessonBuilder.Build();

        // Here would go next lessons being built. Example will use a 1-lesson course.

        CourseBuilder courseBuilder = new();
        courseBuilder.SetName("Chemistry course for high school grade 1");
        courseBuilder.AddStartingLesson(lesson);

        return courseBuilder.Build();
    }



    static void Main(string[] args)
    {
        Course course = BuildCourseExample();

        // Get one and only lesson in the course
        Lesson lesson = course.StartingLessons.First();

        StudentUser user = new("Sukerberk Pierwszy");

        LessonNavigationEngine lne = new(user);
        var learningElem1 = lne.GetBestLearningElem(lesson);

        // Student performs learning activity
        LearningActivity activity1 = new(user, learningElem1);
        /* 100 - example performance measure for dummy simulate function*/
        activity1.Simulate(100);
        activity1.Finalize();

        Console.WriteLine("First display");
        user.DisplayLearningProfiles();

        var learningElem2 = lne.GetBestLearningElem(lesson);
        LearningActivity activity2 = new(user, learningElem2);
        activity2.Simulate(100);
        activity2.Finalize();

        Console.WriteLine("Second display");
        user.DisplayLearningProfiles();

        Console.ReadLine();
    }
}