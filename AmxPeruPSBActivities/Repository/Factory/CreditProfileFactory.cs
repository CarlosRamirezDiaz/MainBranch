using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.CreditProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class CreditProfileFactory
    {
        internal static Entity CreateEntityFrom(CreditProfileModel creditProfile)
        {
            Entity entity = new Entity("etel_creditprofile");

            entity.Attributes.Add("amxco_bureauclassification", creditProfile.BureauClassification);
            entity.Attributes.Add("amxco_bureaucreditscore", creditProfile.BureauCreditScore);
            entity.Attributes.Add("amxco_bureaudate", creditProfile.BureauDate);
            entity.Attributes.Add("amxco_bureaufamilynames", creditProfile.BureauFamilyNames);
            entity.Attributes.Add("amxco_bureaugivennames", creditProfile.BureauGivenNames);
            entity.Attributes.Add("amxco_bureauscore", creditProfile.BureauScore);
            entity.Attributes.Add("amxco_bureautype", creditProfile.BureauType);
            entity.Attributes.Add("amx_burointernoedaddelclientescore", creditProfile.BuroInternoScoreCustomerAge);
            entity.Attributes.Add("amx_burointernoantiguedaddelclientescore", creditProfile.BuroInternoScoreCustomerSince);
            entity.Attributes.Add("amx_burointernolineasactivasscore", creditProfile.BuroInternoScoreActiveLines);
            entity.Attributes.Add("amx_burointernoscore", creditProfile.BuroInternoScore);
            entity.Attributes.Add("amx_buroorigen", creditProfile.BureauSource);
            entity.Attributes.Add("etel_individualid", new EntityReference("contact", creditProfile.IndividualCustomerId));

            return entity;
        }

        internal static CreditProfileModel CreateCreditProfileFrom(Entity entity)
        {
            var creditProfile = new CreditProfileModel();

            creditProfile.Id = entity.Id;

            if (entity.Contains("amx_listasinternas_clientesaction"))
                creditProfile.BureauClassification = entity.GetAttributeValue<string>("amx_listasinternas_clientesaction");

            if (entity.Contains("amxco_bureauclassification"))
                creditProfile.BureauClassification = entity.GetAttributeValue<string>("amxco_bureauclassification");

            if (entity.Contains("amxco_bureaucreditscore"))
                creditProfile.BureauCreditScore = entity.GetAttributeValue<string>("amxco_bureaucreditscore");

            if (entity.Contains("amxco_bureaudate"))
                creditProfile.BureauDate = entity.GetAttributeValue<DateTime>("amxco_bureaudate");

            if (entity.Contains("amxco_bureaufamilynames"))
                creditProfile.BureauFamilyNames = entity.GetAttributeValue<string>("amxco_bureaufamilynames");

            if (entity.Contains("amxco_bureaugivennames"))
                creditProfile.BureauGivenNames = entity.GetAttributeValue<string>("amxco_bureaugivennames");

            if (entity.Contains("amxco_bureauscore"))
                creditProfile.BureauScore = entity.GetAttributeValue<string>("amxco_bureauscore");

            if (entity.Contains("amxco_bureautype"))
                creditProfile.BureauType = entity.GetAttributeValue<string>("amxco_bureautype");

            if (entity.Contains("amx_burointernoantiguedaddelclientescore"))
                creditProfile.BuroInternoScoreCustomerSince = entity.GetAttributeValue<int>("amx_burointernoantiguedaddelclientescore");

            if (entity.Contains("amx_burointernoedaddelclientescore"))
                creditProfile.BuroInternoScoreCustomerAge = entity.GetAttributeValue<int>("amx_burointernoedaddelclientescore");

            if (entity.Contains("amx_burointernolineasactivasscore"))
                creditProfile.BuroInternoScoreActiveLines = entity.GetAttributeValue<int>("amx_burointernolineasactivasscore");

            if (entity.Contains("amx_burointernoscore"))
                creditProfile.BuroInternoScore = entity.GetAttributeValue<int>("amx_burointernoscore");

            if (entity.Contains("amx_buroorigen"))
                creditProfile.BureauSource = entity.GetAttributeValue<string>("amx_buroorigen");

            if (entity.Contains("etel_individualid"))
                creditProfile.IndividualCustomerId = entity.GetAttributeValue<EntityReference>("etel_individualid").Id;



            return creditProfile;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_creditprofileid"
                                                    ,"amxco_bureauclassification"
                                                    ,"amxco_bureaucreditscore"
                                                    ,"amxco_bureaudate"
                                                    ,"amxco_bureaufamilynames"
                                                    ,"amxco_bureaugivennames"
                                                    ,"amxco_bureauscore"
                                                    ,"amxco_bureautype"
                                                    ,"amx_burointernoantiguedaddelclientescore"
                                                    ,"amx_burointernoedaddelclientescore"
                                                    ,"amx_burointernolineasactivasscore"
                                                    ,"amx_burointernoscore"
                                                    ,"amx_buroorigen"
                                                    ,"etel_individualid"});
            }
        }
    }
}
