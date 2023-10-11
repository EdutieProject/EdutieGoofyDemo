using Domain.Entities.Profiles.EIP;
using Domain.Entities.Profiles.ELP;
using Domain.Entities.Profiles.ESP;
using Domain.Entities.Users.Common;
using Domain.Enums;

namespace Domain.Entities.Users
{
    // an end-user of the platform (a.k.a. client)
    public class StudentUser : User
    {
        public ElasticLearningProfile Elp { get; set; } = new();
        public ElasticSkillsProfile Esp { get; set; } = new();
        public ElasticIntelligenceProfile Eip { get; set; } = new();
        public StudentUser(string username) : base(username) { }


        public void DisplayLearningProfiles()
        {
            Console.WriteLine("==== Displaying Elp ====");
            foreach (var item in Elp.LearningBlocks)    
            {
                Console.WriteLine($"LearningBlock: {item.LearningElement.Name} - experience: ${item.TotalExperience}");
            }

            Console.WriteLine("==== Displaying Esp ====");
            foreach (var item in Esp.SkillBlocks)
            {
                Console.WriteLine($"SkillBlock: {Enum.GetName(typeof(Skill), item.Skill)} - experience: ${item.TotalExperience}");
            }

            Console.WriteLine("==== Displaying Eip ====");
            foreach (var item in Eip.IntelligencePoints)
            {
                Console.WriteLine($"IntelligenceType: {Enum.GetName(typeof(IntelligenceType), item.Key)} - points: {item.Value}");
            }
        }
    }
}
