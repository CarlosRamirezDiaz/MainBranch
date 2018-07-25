using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public String FullName { get; set; }
        public string PrimaryEmailAddress { get; set; }
    }
}
