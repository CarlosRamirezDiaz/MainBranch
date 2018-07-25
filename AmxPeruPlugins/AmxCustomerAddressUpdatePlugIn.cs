using Ericsson.ETELCRM.CrmFoundationLibrary.Business;
using Ericsson.ETELCRM.Integration;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    
    public class AmxCustomerAddressUpdatePlugIn : PlugInBase<IAmxCustomerAddressUpdate>, IPlugin
    {

    }

    public interface IAmxCustomerAddressUpdate : IBusinessBase
    {

    }
}
