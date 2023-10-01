using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Users.Common;

namespace Domain.Entities.Users
{
    // a user that would be a tutor
    public class TutorUser : User
    {
        public TutorUser(string username) : base(username) { }
    }
}
