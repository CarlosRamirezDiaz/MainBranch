using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// GENERAL INTERFACE TO GET/WRITE ATTRIBUTES FROM CUSTOMER AMX CO

namespace AmxPeruPSBActivities.Interfaces
{
    public interface ICustomerModel : ICustomer
    {
        OptionSetValue amxperu_documenttype { get; set; }

    }
}
