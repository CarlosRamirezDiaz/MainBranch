﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class GetCreditScoreRequest : BaseRequest
    {
        public string customerId { get; set; }
        public string documentType { get; set; }
        public string documentNumber { get; set; }
    }
}