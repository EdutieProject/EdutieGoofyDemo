


using Domain.Entities.Aggregates;
using Domain.Entities.Common;
using Domain.Entities.LearningElements;
using Domain.Entities.LearningElements.CourseElements;
using Domain.Entities.TreeBasedCurriculum.Course;
using Domain.Entities.Users;

namespace Example;

internal class Program
{

    public static Course CreateExampleCourse()
    {
        CourseVideo video1 = new("An initial course video");
        CourseVideo video2 = new("Second course lesson");
        CourseFigure figure1 = new("An interesting course figure", new Domain.ValueObjects.Image());
        CourseTask task1 = new("First task", "What is 2+2", "4", Domain.Enums.IntelligenceType.Logical, Domain.Enums.IntelligenceType.Linguistic);
        CourseTask task2 = new("Second Task", "Say my name", "Heisenberg", Domain.Enums.IntelligenceType.Visual, Domain.Enums.IntelligenceType.Interpersonal);
        CourseTask task3 = new("Task about russia", "What is the largest country in the world", "Russia", Domain.Enums.IntelligenceType.Visual, Domain.Enums.IntelligenceType.Naturalistic);
        CourseReading reading1 = new("An amazing course reading", "A recipe for banana pancakes: egg, milk, flour");

        Course course = new();
        // Start stage
        course.StartWith(video1);
        // stage 1
        course.AppendTo(video1, figure1);
        course.AppendTo(video1, task1);
        // stage 2
        course.AppendTo(figure1, task3);
        course.AppendTo(task1, video2);
        // stage 3
        course.AppendTo(video2, task2);
        course.AppendTo(video2, reading1);

        return course;
    }

    static void Main(string[] args)
    {
        Course course = CreateExampleCourse();
        course.DisplayCourse();

        Console.WriteLine("\n------------\nLearning simulation\n------------");

        StudentUser user = new("Alex Kutasjenko");
        for (int i = 0; i <= 10; i++)
        {
            LearningElement learningElement = course.GetLessonFor(user);
            Console.WriteLine("Picked lesson:" + learningElement.Title);

            LearningAction learningAction = new(user, learningElement);
            learningAction.Simulate();
            learningAction.Finalize();

            Console.WriteLine("Studend has ended action: " + learningElement.Title);
        }
        Console.WriteLine("\n------------\nESP display:\n-----------------\n");

        user.Elp.DisplayBulk();
    }
}