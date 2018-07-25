using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class CustomerAddressCreateBI : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = null;
            IOrganizationService OrganizationService = null;
            Entity postEntityImage = null;
            Entity entity = null;
            Guid CustomerAddressId = Guid.Empty;

            try
            {
                context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                if (context.Depth == 1)
                {
                    if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity && context.PostEntityImages.Contains("POSTIMG"))
                    {
                        // Get the target entity from the input parameters.
                        entity = (Entity)context.InputParameters["Target"];
                        postEntityImage = (Entity)context.PostEntityImages["POSTIMG"];
                        IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                        OrganizationService = serviceFactory.CreateOrganizationService(context.UserId);
                        CustomerAddressId = CreateCustomerAddress(postEntityImage, OrganizationService);

                        if (CustomerAddressId != Guid.Empty)
                        {
                            Entity currentRecord = new Entity(postEntityImage.LogicalName, postEntityImage.Id);
                            currentRecord["etel_customeraddress"] = new EntityReference("etel_customeraddress", CustomerAddressId);
                            OrganizationService.Update(currentRecord);
                        }

                        BILogSchema _BILogSchema = new BILogSchema
                        {
                            LoggedInUserId = context.UserId,
                            Subject = "Create Customer Address",
                            Description = "Customer Address Created Successfully",
                            Channel = "External Channel"
                        };
                       common.CreateBILogValues(postEntityImage, OrganizationService, _BILogSchema);
                    }
                }
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public Guid CreateCustomerAddress(Entity entity, IOrganizationService service)
        {
            Guid CustomerAddressGuid = Guid.Empty;
            string addressName = string.Empty;
            string street1 = string.Empty;
            string street2 = string.Empty;
            string postalcode = string.Empty;
            string addressTypeText = string.Empty;
            string cityText = string.Empty;

            try
            {
                Entity newCustomerAddress = new Entity("etel_customeraddress");

                if (entity.Attributes.Contains("amxperu_longitude"))
                {
                    if (entity.Attributes["amxperu_longitude"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_longitude", entity.Attributes["amxperu_longitude"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_latitude"))
                {
                    if (entity.Attributes["amxperu_latitude"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_latitude", entity.Attributes["amxperu_latitude"]));
                    }
                }
                //Updated tp new attributes
                if (entity.Attributes.Contains("amxperu_square"))
                {
                    if (entity.Attributes["amxperu_square"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_square", entity.Attributes["amxperu_square"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_allotment"))
                {
                    if (entity.Attributes["amxperu_allotment"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_allotment", entity.Attributes["amxperu_allotment"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_number"))
                {
                    if (entity.Attributes["amxperu_number"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_number", entity.Attributes["amxperu_number"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_grouping"))
                {
                    if (entity.Attributes["amxperu_grouping"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_grouping", entity.Attributes["amxperu_grouping"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_street1"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_street1"] != null)
                    {
                        int avenueStreet = (entity.Attributes["amxperu_street1"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_street1", new OptionSetValue(avenueStreet));
                    }
                }
                if (entity.Attributes.Contains("amxperu_building"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_building"] != null)
                    {
                        int building = (entity.Attributes["amxperu_building"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_building", new OptionSetValue(building));
                    }
                }
                if (entity.Attributes.Contains("amxperu_buildtype"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_buildtype"] != null)
                    {
                        int buildtype = (entity.Attributes["amxperu_buildtype"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_buildtype", new OptionSetValue(buildtype));
                    }
                }
                if (entity.Attributes.Contains("amxperu_billingemail"))
                {
                    if (entity.Attributes["amxperu_billingemail"] != null)
                    {
                        street1 = entity.Attributes["amxperu_billingemail"].ToString();
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_billingemail", entity.Attributes["amxperu_billingemail"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_normalized"))
                {
                    if ((bool)entity.Attributes["amxperu_normalized"])
                    {
                        newCustomerAddress.Attributes.Add("amxperu_normalized", true);
                    }
                    else
                    {
                        newCustomerAddress.Attributes.Add("amxperu_normalized", false);
                    }
                }
                if (entity.Attributes.Contains("etel_street3"))
                {
                    if (entity.Attributes["etel_street3"] != null)
                    {
                        street1 = entity.Attributes["etel_street3"].ToString();
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_addressline3", entity.Attributes["etel_street3"]));
                    }
                }
                //Updated to new attribute END
                if (entity.Attributes.Contains("amxperu_ubigeo"))
                {
                    if (entity.Attributes["amxperu_ubigeo"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_ubigeo", entity.Attributes["amxperu_ubigeo"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_referencedescription"))
                {
                    if (entity.Attributes["amxperu_referencedescription"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("amxperu_referencedescription", entity.Attributes["amxperu_referencedescription"]));
                    }
                }
                if (entity.Attributes.Contains("amxperu_department"))
                {
                    if ((EntityReference)entity.Attributes["amxperu_department"] != null)
                    {
                        newCustomerAddress.Attributes.Add("amxperu_department", new EntityReference("amxperu_department", (entity.Attributes["amxperu_department"] as EntityReference).Id));
                    }
                }
                if (entity.Attributes.Contains("amxperu_province"))
                {
                    if ((EntityReference)entity.Attributes["amxperu_province"] != null)
                    {
                        newCustomerAddress.Attributes.Add("amxperu_province", new EntityReference("amxperu_province", (entity.Attributes["amxperu_province"] as EntityReference).Id));
                    }
                }
                if (entity.Attributes.Contains("amxperu_district"))
                {
                    if ((EntityReference)entity.Attributes["amxperu_district"] != null)
                    {
                        newCustomerAddress.Attributes.Add("amxperu_district", new EntityReference("amxperu_district", (entity.Attributes["amxperu_district"] as EntityReference).Id));
                    }
                }
                if (entity.Attributes.Contains("amxperu_apartmenttypeinterior"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_apartmenttypeinterior"] != null)
                    {
                        int apartmentInterior = (entity.Attributes["amxperu_apartmenttypeinterior"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_apartmenttypeinterior", new OptionSetValue(apartmentInterior));
                    }
                }
                if (entity.Attributes.Contains("amxperu_blockedifice"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_blockedifice"] != null)
                    {
                        int blockEdifice = (entity.Attributes["amxperu_blockedifice"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_blockedifice", new OptionSetValue(blockEdifice));
                    }
                }
                if (entity.Attributes.Contains("amxperu_populationzone"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_populationzone"] != null)
                    {
                        int populationZone = (entity.Attributes["amxperu_populationzone"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_populationzone", new OptionSetValue(populationZone));
                    }
                }
                if (entity.Attributes.Contains("amxperu_zonetype"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_zonetype"] != null)
                    {
                        int zoneType = (entity.Attributes["amxperu_zonetype"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_zonetype", new OptionSetValue(zoneType));
                    }
                }
                if (entity.Attributes.Contains("amxperu_urbanizationtype"))
                {
                    if ((OptionSetValue)entity.Attributes["amxperu_urbanizationtype"] != null)
                    {
                        int urbanType = (entity.Attributes["amxperu_urbanizationtype"] as OptionSetValue).Value;
                        newCustomerAddress.Attributes.Add("amxperu_urbanizationtype", new OptionSetValue(urbanType));
                    }
                }
                if (entity.Attributes.Contains("amxperu_isinstallation"))
                {
                    if ((bool)entity.Attributes["amxperu_isinstallation"])
                    {
                        newCustomerAddress.Attributes.Add("amxperu_isinstallation", true);
                    }
                    else
                    {
                        newCustomerAddress.Attributes.Add("amxperu_isinstallation", false);
                    }
                }
                if (entity.Attributes.Contains("etel_customeraddresstypecode"))
                {
                    if ((OptionSetValue)entity.Attributes["etel_customeraddresstypecode"] != null)
                    {
                        int addressType = (entity.Attributes["etel_customeraddresstypecode"] as OptionSetValue).Value;
                        addressTypeText = entity.FormattedValues["etel_customeraddresstypecode"];
                        newCustomerAddress.Attributes.Add("etel_customeraddresstypecode", new OptionSetValue(addressType));
                    }
                }
                if (entity.Attributes.Contains("etel_street1"))
                {
                    if (entity.Attributes["etel_street1"] != null)
                    {
                        street1 = entity.Attributes["etel_street1"].ToString();
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_addressline1", entity.Attributes["etel_street1"]));
                    }
                }
                if (entity.Attributes.Contains("etel_street2"))
                {
                    if (entity.Attributes["etel_street2"] != null)
                    {
                        street2 = entity.Attributes["etel_street2"].ToString();
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_addressline2", entity.Attributes["etel_street2"]));
                    }
                }
                if (entity.Attributes.Contains("etel_postalcode"))
                {
                    if (entity.Attributes["etel_postalcode"] != null)
                    {
                        postalcode = entity.Attributes["etel_postalcode"].ToString();
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_postalcode", entity.Attributes["etel_postalcode"]));
                    }
                }
                if (entity.Attributes.Contains("etel_telephone1"))
                {
                    if (entity.Attributes["etel_telephone1"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_telephone1", entity.Attributes["etel_telephone1"]));
                    }
                }
                if (entity.Attributes.Contains("etel_telephone2"))
                {
                    if (entity.Attributes["etel_telephone2"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_telephone2", entity.Attributes["etel_telephone2"]));
                    }
                }
                if (entity.Attributes.Contains("etel_emailaddress"))
                {
                    if (entity.Attributes["etel_emailaddress"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_emailaddress", entity.Attributes["etel_emailaddress"]));
                    }
                }
                if (entity.Attributes.Contains("etel_fax"))
                {
                    if (entity.Attributes["etel_fax"] != null)
                    {
                        newCustomerAddress.Attributes.Add(new KeyValuePair<string, object>("etel_fax", entity.Attributes["etel_fax"]));
                    }
                }
                if (entity.Attributes.Contains("etel_countryid"))
                {
                    if ((EntityReference)entity.Attributes["etel_countryid"] != null)
                    {
                        newCustomerAddress.Attributes.Add("etel_countryid", new EntityReference("etel_country", (entity.Attributes["etel_countryid"] as EntityReference).Id));
                    }
                }
                if (entity.Attributes.Contains("etel_cityid"))
                {
                    if ((EntityReference)entity.Attributes["etel_cityid"] != null)
                    {
                        EntityReference city = new EntityReference("etel_city", (entity.Attributes["etel_cityid"] as EntityReference).Id);
                        newCustomerAddress.Attributes.Add("etel_cityid", city);
                        string fetchCityName = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
                                                    + "<entity name='etel_city'>"
                                                    + "<attribute name='etel_name'/>"
                                                    + "<order descending='false' attribute='etel_name'/>"
                                                    + "<filter type='and'>"
                                                    + "<condition attribute='etel_cityid' value='" + city.Id + "' operator='eq'/>"
                                                    + "</filter></entity></fetch>";
                        EntityCollection result = new EntityCollection();
                        result = service.RetrieveMultiple(new FetchExpression(fetchCityName));
                        if (result != null && result.Entities.Count > 0)
                        {
                            foreach (Entity _entity in result.Entities)
                            {
                                if (_entity.Contains("etel_name"))
                                {
                                    if (_entity.Attributes["etel_name"] != null)
                                        cityText = _entity.Attributes["etel_name"].ToString();
                                }
                            }
                        }
                    }
                }
                if (entity.Attributes.Contains("etel_individualcustomer"))
                {
                    if ((EntityReference)entity.Attributes["etel_individualcustomer"] != null)
                    {
                        EntityReference Individual = new EntityReference("contact", (entity.Attributes["etel_individualcustomer"] as EntityReference).Id);
                        newCustomerAddress.Attributes.Add("etel_individualcustomerid", Individual);
                    }
                }
                if (entity.Attributes.Contains("etel_corporatecustomer"))
                {
                    if ((EntityReference)entity.Attributes["etel_corporatecustomer"] != null)
                    {
                        EntityReference Corporate = new EntityReference("account", (entity.Attributes["etel_corporatecustomer"] as EntityReference).Id);
                        newCustomerAddress.Attributes.Add("etel_corporatecustomerid", Corporate);
                    }
                }
                addressName = addressTypeText + "-" + street1 + " " + street2 + ", " + postalcode + ", " + cityText;
                newCustomerAddress.Attributes.Add("etel_name", addressName);
                CustomerAddressGuid = service.Create(newCustomerAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CustomerAddressGuid;
        }
    }
}
