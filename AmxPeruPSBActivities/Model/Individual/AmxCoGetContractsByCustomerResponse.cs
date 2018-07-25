using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Individual
{
    public class AmxCoGetContractsByCustomerResponse
    {
        public List<string> ErrorDetail { get; set; }
        public bool Error { get; set; }
        public List<Contract> Contracts { get; set;}
        public List<Cycle> Cyclies { get; set; }
    }

    public class Contract
    {
        public string ContractName { get; set; }
        public string ContractCoId { get; set; }
        public string ContractIdPub { get; set; }
    }

    public class Cycle
    {
        public string Billcycle { get; set; }
        public string Description { get; set; }
        public string LastRunDate { get; set; }
        public string BchRunDate { get; set; }
    }

}
