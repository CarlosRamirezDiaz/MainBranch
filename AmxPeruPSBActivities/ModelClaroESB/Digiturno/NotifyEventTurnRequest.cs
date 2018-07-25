using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Digiturno
{
    public class NotifyEventTurnRequest
    {
       //"idTurn" : 3,
       //"idEvent" : 3,
       //"idBusinessIteration" : 3

        public int idTurn { get; set; }
        public int idEvent { get; set; }
        public int idBusinessIteration { get; set; }
    }

    public enum IdEventEnum
    {
        StartAttention = 1,
        EndAttention = 2,
        EndTurn = 3
    }
}
