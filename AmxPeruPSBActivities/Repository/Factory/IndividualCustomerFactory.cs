using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.Individual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class IndividualCustomerFactory
    {
        internal static Entity CreateEntityFrom(IndividualCustomerModel individual)
        {
            Entity entity = new Entity("contact");
            //entity.Id = individual.Id;
            //entity.LogicalName = individual.LogicalName;


            return entity;
        }

        internal static IndividualCustomerModel CreateIndividualFrom(Entity entity)
        {
            var individual = new IndividualCustomerModel();

            individual.IndividualCustomerId = entity.Id;

            if (entity.Contains("firstname"))
                individual.FirstName = entity.GetAttributeValue<string>("firstname");

            if (entity.Contains("lastname"))
                individual.LastName = entity.GetAttributeValue<string>("lastname");

            if (entity.Contains("fullname"))
                individual.FullName = entity.GetAttributeValue<string>("fullname");

            if (entity.Contains("etel_iddocumentnumber"))
                individual.DocumentNumber = entity.GetAttributeValue<string>("etel_iddocumentnumber");

            if (entity.Contains("amx_documentissuedate"))
                individual.DocumentIssueDate = entity.GetAttributeValue<DateTime>("amx_documentissuedate");

            if (entity.Contains("amxperu_documenttype"))
                individual.DocumentType = entity.GetAttributeValue<OptionSetValue>("amxperu_documenttype").Value;

            if (entity.Attributes.Contains("mobilephone"))
                individual.PhoneNumber = entity.Attributes["mobilephone"].ToString();

            if (entity.Attributes.Contains("emailaddress1"))
                individual.Email = entity.Attributes["emailaddress1"].ToString();

            if (entity.Attributes.Contains("company"))
                individual.CompanyName = entity.Attributes["company"].ToString();

            if (entity.Attributes.Contains("etel_placeofbirth"))
                individual.BirthPlace = entity.Attributes["etel_placeofbirth"].ToString();

            if (entity.Attributes.Contains("etel_nationalid"))
                individual.Nationality = entity.Attributes["etel_nationalid"].ToString();

            if (entity.Attributes.Contains("etel_externalid"))
                individual.CustomerId = entity.Attributes["etel_externalid"].ToString();

            if (entity.Attributes.Contains("statecode"))
            {
                int status = ((OptionSetValue)entity["statecode"]).Value;
                if (status == 1)
                {
                    individual.ActiveFlag = false;
                }
                if (status == 0)
                {
                    individual.ActiveFlag = true;
                }
            }

            if (entity.Attributes.Contains("statuscode"))
                individual.StatusCode = entity.FormattedValues["statuscode"].ToString();

            if (entity.Attributes.Contains("gendercode"))
                individual.Gender = entity.FormattedValues["gendercode"].ToString();

            if (entity.Attributes.Contains("birthdate"))
                individual.BirthDate = entity.GetAttributeValue<DateTime>("birthdate");

            if (entity.Attributes.Contains("amx_customersince"))
                individual.CustomerSince = entity.GetAttributeValue<DateTime>("amx_customersince");

            if (entity.Attributes.Contains("amx_segmentid"))
            {
                individual.Segment = new AmxPeruPSBActivities.Model.Segment();
                individual.Segment.Id = entity.GetAttributeValue<EntityReference>("amx_segmentid").Id;
                individual.Segment.Name = entity.GetAttributeValue<EntityReference>("amx_segmentid").Name;
            }

            if (entity.Contains("amx_biographicvalidationdate"))
                individual.BiographicValidationDate = entity.GetAttributeValue<DateTime>("amx_biographicvalidationdate");

            return individual;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "contactid"
                                                    ,"firstname"
                                                    ,"lastname"
                                                    ,"fullname"
                                                    ,"amxperu_documenttype"
                                                    ,"etel_iddocumentnumber"
                                                    ,"amx_documentissuedate"
                                                    ,"mobilephone"
                                                    ,"emailaddress1"
                                                    ,"company"
                                                    ,"etel_placeofbirth"
                                                    ,"etel_nationalid"
                                                    ,"etel_externalid"
                                                    ,"etel_accountnumber"
                                                    ,"statecode"
                                                    ,"statuscode"
                                                    ,"gendercode"
                                                    ,"birthdate"
                                                    ,"amx_customersince"
                                                    ,"amx_segmentid"
                                                    ,"amx_biographicvalidationdate"});

            }
        }
    }
}
