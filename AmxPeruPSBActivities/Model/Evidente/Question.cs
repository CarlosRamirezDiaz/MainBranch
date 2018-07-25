using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model.Evidente
{
    public class Question
    {
        public string text { get; set; }
        public string sequenceQuestion { get; set; }
        public List<answer> answers { get; set; }
    }

    public class answer
    {
        public string text { get; set; }
        public string sequenceAnswer { get; set; }
        public string sequenceQuestion { get; set; }
    }
}
