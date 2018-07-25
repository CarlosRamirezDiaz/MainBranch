using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model.Digiturno
{
    public class DigiturnoNotifyEventTurnRequest
    {
        public int IdTurn { get; set; }
        public int IdEvent { get; set; }
        public int IdBusinessInteraction { get; set; }
    }
}
