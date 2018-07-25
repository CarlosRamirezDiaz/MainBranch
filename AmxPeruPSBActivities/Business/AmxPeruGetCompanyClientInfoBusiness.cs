using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruGetCompanyClientInfoBusiness
    {
        //AmxPeruCompanyClientlistResponse
        public AmxPeruCompanyClientlistResponse AmxperuGetcompanyList(AmxPeruCompanyClientlistRequest _AmxPeruCompanyClientlistRequest, OrganizationServiceProxy orgservice)
        {
            AmxPeruCompanyClientlistResponse _AmxPeruCompanyClientlistResponse = null;
            try
            {
                if (_AmxPeruCompanyClientlistRequest != null)
                {

                    AmxPeruCompanyClientlistResponse response = new AmxPeruCompanyClientlistResponse()
                    {

                        codeResponse = "CodeResponse",
                        descriptionResponse = "Description Response",
                        Error= "No Error Found",
                        Status="OK",
                        interests = new List<CompanyType>()
                        {
                            new CompanyType()
                            {
                                description="Description",
                                documentNumber="VZXCDF",
                                startDateTime=DateTime.Now,
                                endDateTime=DateTime.Now,
                                ID="123456789",
                                MarketcampaignName="Campaign",
                                MarketsegmentName="marketSegment",
                                phoneNumber1="12345678",
                                status="OK"                 
                            }
                        }
                       
                        
                    };
                    _AmxPeruCompanyClientlistResponse = response;
                }
                return _AmxPeruCompanyClientlistResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
