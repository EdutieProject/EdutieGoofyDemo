using Domain.Entities.Common;
using Domain.Entities.Users;
using System.Security.Cryptography;

namespace Domain.Entities.Aggregates;

public class LearningAction
{
    private StudentUser user;
    public StudentUser User { get => user; }

    private readonly LearningElement learningElement;

    private int experience = 0;
    public int Experience { get => experience; }


    public LearningAction(StudentUser user, LearningElement learningElement)
    {
        this.user = user;
        this.learningElement = learningElement;
    }

    public LearningElement LearningElement { get => learningElement; }

    public void Simulate()
    {
        experience = RandomNumberGenerator.GetInt32(200);
    }

    public void Finalize()
    {
        User.Esp.Adjust(this);
        User.Elp.Adjust(this);
    }
}
