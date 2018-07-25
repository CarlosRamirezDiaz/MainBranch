using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Bureau
{
    public class GetBureauResponse
    {
            public CustomerCreditProfile customerCreditProfile { get; set; }
            public HeaderResponse headerResponse { get; set; }
            public CustomerIdentification customerIdentification { get; set; }
            public CustomerName customerName { get; set; }
    }

    public class CustomerCreditProfile
    {
            public string score { get; set; }
            public int creditScore { get; set; }
            public string classification { get; set; }
            public string type { get; set; }
    }

    public class HeaderResponse
    {
            public string traceabilityId { get; set; }
            public DateTime responseDate { get; set; }
    }

    public class CustomerIdentification
    {
            public string issueDate { get; set; }
    }

    public class CustomerName
    {
            public string familyNames { get; set; }
            public string givenNames { get; set; }
    }

}
