﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Digiturno
{
    public class NotifyEventTurnResponse : AmxCoClaroESBResponseBase
    {
        public int code { get; set; }
        public string description { get; set; }
    }
}