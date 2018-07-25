using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Model.BiHeader
{
    public class BiHeaderModel
    {
        public string Subject { get; set; }
        public string ChannelInteractionId { get; set; }
        public Guid CsrId { get; set; }
        public Guid AccountId { get; set; }
        public Guid IndividualCustomerId { get; set; }
    }
}
