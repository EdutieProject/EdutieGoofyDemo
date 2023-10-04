using Domain.Entities.Curriculum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Profiles.Interfaces;

public interface ILearningProfile
{
    public DateTime LastUpadate { get; }
    public abstract void Adjust(LearningResult result);
}
