using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class BaseResponse
    {
        public string Error { get; set; }

        public string Status { get; set; }

        public bool Success { get; set; }
    }
}