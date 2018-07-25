using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class AmxCoCurrencyFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoCurrencyModel currency)
        {
            Entity entity = new Entity("transactioncurrency");

            entity.Id = currency.transactioncurrencyid;
            entity.Attributes.Add("transactioncurrencyid", new EntityReference("transactioncurrency", currency.transactioncurrencyid));

            return entity;
        }

        internal static AmxCoCurrencyModel CreateCurrencyFrom(Entity entity)
        {
            var currency = new AmxCoCurrencyModel();

            currency.transactioncurrencyid = entity.Id;
            
            if (entity.Contains("currencyname"))
                currency.currencyname = entity.Attributes["currencyname"].ToString();
            if (entity.Contains("isocurrencycode"))
                currency.isocurrencycode = entity.Attributes["isocurrencycode"].ToString();

            return currency;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "transactioncurrencyid"
                                                    ,"currencyname"
                                                    ,"isocurrencycode"});
            }
        }
    }
}
