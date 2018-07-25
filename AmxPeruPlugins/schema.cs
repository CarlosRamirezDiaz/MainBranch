using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class BILogSchema
    {
        public Guid BiHeaderRecordGuid { get; set; }
        public Guid LoggedInUserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Channel { get; set; }
    }

    public class BILogRequest
    {
        public Guid BiHeaderRecordGuid { get; set; }
        public Guid LoggedInUserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Channel { get; set; }

        public int CustomerType { get; set; }
        public Guid CustomerGuid { get; set; }

        public string RegargingEntityLogicialName { get; set; }
        public Guid RegargingEntityRecordGuid { get; set; }
    }
}
