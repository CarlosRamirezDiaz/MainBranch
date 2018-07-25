using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class PostCreateIndividualCreation : IPlugin
    {
        string translationFormId = "PostCreateIndividualCreationProspect";
        IPluginExecutionContext _context = null;
        IOrganizationService _orgService = null;
        IOrganizationServiceFactory _orgServiceFactory = null;
        Guid CreatedIndividualGuid = Guid.Empty;
        public void Execute(IServiceProvider serviceProvider)
        {
            _context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            _orgServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            _orgService = _orgServiceFactory.CreateOrganizationService(_context.UserId);

            if (_context.InputParameters.Contains("Target") && _context.InputParameters["Target"] is Entity && _context.PostEntityImages.Contains("POSTIMG"))
            {
                Entity entity = (Entity)_context.InputParameters["Target"];
                Entity postImage = (Entity)_context.PostEntityImages["POSTIMG"];

                if (_context.Depth == 1 && entity.LogicalName == constants.IndividualCreationEntityName)
                {
                    if (postImage.Attributes.Contains("amxperu_submit") &&
                        (postImage.Attributes["amxperu_submit"] as OptionSetValue).Value == 250000000)
                    {
                        try
                        {
                            CreatedIndividualGuid = CreateIndividualCustomer(postImage, _orgService);
                            if (CreatedIndividualGuid != Guid.Empty)
                            {
                                Entity _Entity = new Entity(postImage.LogicalName);
                                _Entity.Id = postImage.Id;
                                _Entity.Attributes.Add("amxperu_createdindividualid", new EntityReference("contact", CreatedIndividualGuid));
                                _orgService.Update(_Entity);
                                Entity _indCreation = new Entity(postImage.LogicalName);
                                _indCreation.Id = postImage.Id;
                                _indCreation.Attributes.Add("amxperu_iscreatedinbscs", new OptionSetValue(250000000));
                                _orgService.Update(_indCreation);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidPluginExecutionException(ex.Message);
                        }
                    }
                }
            }
        }

        private Guid CreateIndividualCustomer(Entity postImage, IOrganizationService _orgService)
        {
            Entity _entity = new Entity("contact");
            if (postImage.Attributes.Contains("amxperu_firstname"))
            {
                if (postImage.Attributes["amxperu_firstname"] != null)
                {
                    _entity.Attributes.Add("firstname", postImage.Attributes["amxperu_firstname"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_lastname"))
            {
                if (postImage.Attributes["amxperu_lastname"] != null)
                {
                    _entity.Attributes.Add("lastname", postImage.Attributes["amxperu_lastname"].ToString());
                }
            }
            //if (postImage.Attributes.Contains("amxperu_street1"))
            //{
            //    if (postImage.Attributes["amxperu_street1"] != null)
            //    {
            //        _entity.Attributes.Add("address1_line1", postImage.Attributes["amxperu_street1"].ToString());
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_street2"))
            //{
            //    if (postImage.Attributes["amxperu_street2"] != null)
            //    {
            //        _entity.Attributes.Add("address1_line2", postImage.Attributes["amxperu_street2"].ToString());
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_street3"))
            //{
            //    if (postImage.Attributes["amxperu_street3"] != null)
            //    {
            //        _entity.Attributes.Add("address1_line3", postImage.Attributes["amxperu_street3"].ToString());
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_documentid"))
            {
                if (postImage.Attributes["amxperu_documentid"] != null)
                {
                    _entity.Attributes.Add("etel_passportnumber", postImage.Attributes["amxperu_documentid"].ToString());
                }
            }
            //if (postImage.Attributes.Contains("amxperu_nickname"))
            //{
            //    if (postImage.Attributes["amxperu_nickname"] != null)
            //    {
            //        _entity.Attributes.Add("nickname", postImage.Attributes["amxperu_nickname"].ToString());
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_motherslastname"))
            {
                if (postImage.Attributes["amxperu_motherslastname"] != null)
                {
                    _entity.Attributes.Add("amxperu_motherslastname", postImage.Attributes["amxperu_motherslastname"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_jobtitle"))
            {
                if (postImage.Attributes["amxperu_jobtitle"] != null)
                {
                    _entity.Attributes.Add("jobtitle", postImage.Attributes["amxperu_jobtitle"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_mainphone"))
            {
                if (postImage.Attributes["amxperu_mainphone"] != null)
                {
                    _entity.Attributes.Add("mobilephone", postImage.Attributes["amxperu_mainphone"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_homephone"))
            {
                if (postImage.Attributes["amxperu_homephone"] != null)
                {
                    _entity.Attributes.Add("amxperu_otherphonehome", postImage.Attributes["amxperu_homephone"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_businessphone"))
            {
                if (postImage.Attributes["amxperu_businessphone"] != null)
                {
                    _entity.Attributes.Add("amxperu_otherphonebusiness", postImage.Attributes["amxperu_businessphone"].ToString());
                }
            }
            //if (postImage.Attributes.Contains("amxperu_personalnotes"))
            //{
            //    if (postImage.Attributes["amxperu_personalnotes"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_personalnotes", postImage.Attributes["amxperu_personalnotes"].ToString());
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_email"))
            {
                if (postImage.Attributes["amxperu_email"] != null)
                {
                    _entity.Attributes.Add("emailaddress1", postImage.Attributes["amxperu_email"].ToString());
                }
            }
            //if (postImage.Attributes.Contains("amxperu_password"))
            //{
            //    if (postImage.Attributes["amxperu_password"] != null)
            //    {
            //        _entity.Attributes.Add("etel_password", postImage.Attributes["amxperu_password"].ToString());
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_clarocommunityuser"))
            {
                if (postImage.Attributes["amxperu_clarocommunityuser"] != null)
                {
                    _entity.Attributes.Add("amxperu_clarocommunityuser", postImage.Attributes["amxperu_clarocommunityuser"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_claroaccountuser"))
            {
                if (postImage.Attributes["amxperu_claroaccountuser"] != null)
                {
                    _entity.Attributes.Add("amxperu_claroaccountuser", postImage.Attributes["amxperu_claroaccountuser"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_businessname"))
            {
                if (postImage.Attributes["amxperu_businessname"] != null)
                {
                    _entity.Attributes.Add("amxperu_businessname", postImage.Attributes["amxperu_businessname"].ToString());
                }
            }
            //if (postImage.Attributes.Contains("amxperu_blackliststatusreason"))
            //{
            //    if (postImage.Attributes["amxperu_blackliststatusreason"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_blackliststatusreason", postImage.Attributes["amxperu_blackliststatusreason"].ToString());
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_companyname"))
            {
                if (postImage.Attributes["amxperu_companyname"] != null)
                {
                    _entity.Attributes.Add("company", postImage.Attributes["amxperu_companyname"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_socialprofiletwitter"))
            {
                if (postImage.Attributes["amxperu_socialprofiletwitter"] != null)
                {
                    _entity.Attributes.Add("etel_socialmediatwitter", postImage.Attributes["amxperu_socialprofiletwitter"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_socialprofilelinkedin"))
            {
                if (postImage.Attributes["amxperu_socialprofilelinkedin"] != null)
                {
                    _entity.Attributes.Add("etel_socialmedialinkedin", postImage.Attributes["amxperu_socialprofilelinkedin"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_socialprofileinstagram"))
            {
                if (postImage.Attributes["amxperu_socialprofileinstagram"] != null)
                {
                    _entity.Attributes.Add("amxperu_socialmediainstagram", postImage.Attributes["amxperu_socialprofileinstagram"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_socialprofilefacebook"))
            {
                if (postImage.Attributes["amxperu_socialprofilefacebook"] != null)
                {
                    _entity.Attributes.Add("etel_socialmediafacebook", postImage.Attributes["amxperu_socialprofilefacebook"].ToString());
                }
            }
            //if (postImage.Attributes.Contains("amxperu_zip"))
            //{
            //    if (postImage.Attributes["amxperu_zip"] != null)
            //    {
            //        _entity.Attributes.Add("address1_postalcode", postImage.Attributes["amxperu_zip"].ToString());
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_prefferedgivenname"))
            {
                if (postImage.Attributes["amxperu_prefferedgivenname"] != null)
                {
                    _entity.Attributes.Add("etel_prefferedgivenname", postImage.Attributes["amxperu_prefferedgivenname"].ToString());
                }
            }
            if (postImage.Attributes.Contains("amxperu_placeofbirth"))
            {
                if (postImage.Attributes["amxperu_placeofbirth"] != null)
                {
                    _entity.Attributes.Add("etel_placeofbirth", postImage.Attributes["amxperu_placeofbirth"].ToString());
                }
            }
            //if (postImage.Attributes.Contains("amxperu_sendmarketingmate"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_sendmarketingmate"] != null)
            //    {
            //        int marketingMate = (postImage.Attributes["amxperu_sendmarketingmate"] as OptionSetValue).Value;
            //        _entity.Attributes.Add("amxperu_sendmarketingmate", new OptionSetValue(marketingMate));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_addresstype"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_addresstype"] != null)
            //    {
            //        int addressType = (postImage.Attributes["amxperu_addresstype"] as OptionSetValue).Value;
            //        _entity.Attributes.Add("etel_customeraddresstypecode", new OptionSetValue(addressType));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_blackliststatus"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_blackliststatus"] != null)
            //    {
            //        int blacklistStatus = (postImage.Attributes["amxperu_blackliststatus"] as OptionSetValue).Value;
            //        _entity.Attributes.Add("etel_blackliststatuscode", new OptionSetValue(blacklistStatus));
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_allowsocialnetwork"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_allowsocialnetwork"] != null)
                {
                    int socialNetwork = (postImage.Attributes["amxperu_allowsocialnetwork"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_allowsocialnetworks", new OptionSetValue(socialNetwork));
                }
            }
            if (postImage.Attributes.Contains("amxperu_gender"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_gender"] != null)
                {
                    int gender = (postImage.Attributes["amxperu_gender"] as OptionSetValue).Value;
                    if (gender == 250000000)
                    {
                        _entity.Attributes.Add("gendercode", new OptionSetValue(1));
                    }
                    else if (gender == 250000001)
                    {
                        _entity.Attributes.Add("gendercode", new OptionSetValue(2));
                    }
                }
            }
            if (postImage.Attributes.Contains("amxperu_allowphone"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_allowphone"] != null)
                {
                    int phone = (postImage.Attributes["amxperu_allowphone"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_allowphone", new OptionSetValue(phone));
                }
            }
            if (postImage.Attributes.Contains("amxperu_allowsmsinstantmessaging"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_allowsmsinstantmessaging"] != null)
                {
                    int sms = (postImage.Attributes["amxperu_allowsmsinstantmessaging"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_allowsmsinstantmessaging", new OptionSetValue(sms));
                }
            }
            if (postImage.Attributes.Contains("amxperu_allowmail"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_allowmail"] != null)
                {
                    int mail = (postImage.Attributes["amxperu_allowmail"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_allowmail", new OptionSetValue(mail));
                }
            }
            if (postImage.Attributes.Contains("amxperu_allowfax"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_allowfax"] != null)
                {
                    int fax = (postImage.Attributes["amxperu_allowfax"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_allowfax", new OptionSetValue(fax));
                }
            }
            if (postImage.Attributes.Contains("amxperu_allowemail"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_allowemail"] != null)
                {
                    int email = (postImage.Attributes["amxperu_allowemail"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_allowemail", new OptionSetValue(email));
                }
            }
            if (postImage.Attributes.Contains("amxperu_allowbulkemail"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_allowbulkemail"] != null)
                {
                    int bulkemail = (postImage.Attributes["amxperu_allowbulkemail"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_allowbulkemail", new OptionSetValue(bulkemail));
                }
            }
            if (postImage.Attributes.Contains("amxperu_documenttype"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_documenttype"] != null)
                {
                    int documentType = (postImage.Attributes["amxperu_documenttype"] as OptionSetValue).Value;
                    _entity.Attributes.Add("amxperu_documenttype", new OptionSetValue(documentType));
                }
            }
            //if (postImage.Attributes.Contains("amxperu_paymentterm"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_paymentterm"] != null)
            //    {
            //        int paymentterm = (postImage.Attributes["amxperu_paymentterm"] as OptionSetValue).Value;
            //        _entity.Attributes.Add("etel_paymentterm", new OptionSetValue(paymentterm));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_paymentarrangement"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_paymentarrangement"] != null)
            //    {
            //        int paymentArrangement = (postImage.Attributes["amxperu_paymentarrangement"] as OptionSetValue).Value;
            //        _entity.Attributes.Add("etel_paymentarrangement", new OptionSetValue(paymentArrangement));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_typesofcontacts"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_typesofcontacts"] != null)
            //    {
            //        int typeofContact = (postImage.Attributes["amxperu_typesofcontacts"] as OptionSetValue).Value;
            //        _entity.Attributes.Add("amxperu_typesofcontacts", new OptionSetValue(typeofContact));
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_language"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_language"] != null)
                {
                    int language = (postImage.Attributes["amxperu_language"] as OptionSetValue).Value;
                    _entity.Attributes.Add("etel_languagecode", new OptionSetValue(language));
                }
            }
            if (postImage.Attributes.Contains("amxperu_salutation"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_salutation"] != null)
                {
                    int salutationcode = (postImage.Attributes["amxperu_salutation"] as OptionSetValue).Value;
                    _entity.Attributes.Add("etel_salutationcode", new OptionSetValue(salutationcode));
                }
            }
            //if (postImage.Attributes.Contains("amxperu_marketsegment"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_marketsegment"] != null)
            //    {
            //        int marketsegment = (postImage.Attributes["amxperu_marketsegment"] as OptionSetValue).Value;
            //        _entity.Attributes.Add("amxperu_marketsegment", new OptionSetValue(marketsegment));
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_maritalstatus"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_maritalstatus"] != null)
                {
                    int maritalStatus = (postImage.Attributes["amxperu_maritalstatus"] as OptionSetValue).Value;
                    if (maritalStatus == 250000000)
                    {
                        _entity.Attributes.Add("familystatuscode", new OptionSetValue(1));
                    }
                    else if (maritalStatus == 250000001)
                    {
                        _entity.Attributes.Add("familystatuscode", new OptionSetValue(2));
                    }
                    else if (maritalStatus == 250000002)
                    {
                        _entity.Attributes.Add("familystatuscode", new OptionSetValue(3));
                    }
                    else if (maritalStatus == 250000003)
                    {
                        _entity.Attributes.Add("familystatuscode", new OptionSetValue(4));
                    }
                }
            }
            //if (postImage.Attributes.Contains("amxperu_prefferedtime"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_prefferedtime"] != null)
            //    {
            //        int preferedTime = (postImage.Attributes["amxperu_prefferedtime"] as OptionSetValue).Value;
            //        if (preferedTime == 250000000)
            //        {
            //            _entity.Attributes.Add("preferredappointmenttimecode", new OptionSetValue(1));
            //        }
            //        else if (preferedTime == 250000001)
            //        {
            //            _entity.Attributes.Add("preferredappointmenttimecode", new OptionSetValue(2));
            //        }
            //        else if (preferedTime == 250000002)
            //        {
            //            _entity.Attributes.Add("preferredappointmenttimecode", new OptionSetValue(3));
            //        }
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_role"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_role"] != null)
                {
                    int accountRole = (postImage.Attributes["amxperu_role"] as OptionSetValue).Value;
                    if (accountRole == 250000000)
                    {
                        _entity.Attributes.Add("accountrolecode", new OptionSetValue(1));
                    }
                    else if (accountRole == 250000001)
                    {
                        _entity.Attributes.Add("accountrolecode", new OptionSetValue(2));
                    }
                    else if (accountRole == 250000002)
                    {
                        _entity.Attributes.Add("accountrolecode", new OptionSetValue(3));
                    }
                }
            }
            //if (postImage.Attributes.Contains("amxperu_prefferedday"))
            //{
            //    if ((OptionSetValue)postImage.Attributes["amxperu_prefferedday"] != null)
            //    {
            //        int preferedDay = (postImage.Attributes["amxperu_prefferedday"] as OptionSetValue).Value;
            //        if (preferedDay == 250000000)
            //        {
            //            _entity.Attributes.Add("preferredappointmentdaycode", new OptionSetValue(0));
            //        }
            //        else if (preferedDay == 250000001)
            //        {
            //            _entity.Attributes.Add("preferredappointmentdaycode", new OptionSetValue(1));
            //        }
            //        else if (preferedDay == 250000002)
            //        {
            //            _entity.Attributes.Add("preferredappointmentdaycode", new OptionSetValue(2));
            //        }
            //        else if (preferedDay == 250000003)
            //        {
            //            _entity.Attributes.Add("preferredappointmentdaycode", new OptionSetValue(3));
            //        }
            //        else if (preferedDay == 250000004)
            //        {
            //            _entity.Attributes.Add("preferredappointmentdaycode", new OptionSetValue(4));
            //        }
            //        else if (preferedDay == 250000005)
            //        {
            //            _entity.Attributes.Add("preferredappointmentdaycode", new OptionSetValue(5));
            //        }
            //        else if (preferedDay == 250000006)
            //        {
            //            _entity.Attributes.Add("preferredappointmentdaycode", new OptionSetValue(6));
            //        }
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_contactmethod"))
            {
                if ((OptionSetValue)postImage.Attributes["amxperu_contactmethod"] != null)
                {
                    int contactMethod = (postImage.Attributes["amxperu_contactmethod"] as OptionSetValue).Value;
                    if (contactMethod == 250000000)
                    {
                        _entity.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(0));
                    }
                    else if (contactMethod == 250000001)
                    {
                        _entity.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(1));
                    }
                    else if (contactMethod == 250000002)
                    {
                        _entity.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(2));
                    }
                    else if (contactMethod == 250000003)
                    {
                        _entity.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(3));
                    }
                    else if (contactMethod == 250000004)
                    {
                        _entity.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(4));
                    }
                    else if (contactMethod == 250000005)
                    {
                        _entity.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(5));
                    }
                    else if (contactMethod == 250000006)
                    {
                        _entity.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(6));
                    }
                }
            }
            //if (postImage.Attributes.Contains("amxperu_originatinglead"))
            //{
            //    if ((EntityReference)postImage.Attributes["amxperu_originatinglead"] != null)
            //    {
            //        _entity.Attributes.Add("originatingleadid", new EntityReference("lead", (postImage.Attributes["amxperu_originatinglead"] as EntityReference).Id));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_city"))
            //{
            //    if ((EntityReference)postImage.Attributes["amxperu_city"] != null)
            //    {
            //        _entity.Attributes.Add("etel_cityid", new EntityReference("etel_city", (postImage.Attributes["amxperu_city"] as EntityReference).Id));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_country"))
            //{
            //    if ((EntityReference)postImage.Attributes["amxperu_country"] != null)
            //    {
            //        _entity.Attributes.Add("etel_countryid", new EntityReference("etel_country", (postImage.Attributes["amxperu_country"] as EntityReference).Id));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_occrateplan"))
            //{
            //    if ((EntityReference)postImage.Attributes["amxperu_occrateplan"] != null)
            //    {
            //        _entity.Attributes.Add("etel_occrateplanid", new EntityReference("etel_rateplan", (postImage.Attributes["amxperu_occrateplan"] as EntityReference).Id));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_paymentresponsible"))
            //{
            //    if ((bool)postImage.Attributes["amxperu_paymentresponsible"])
            //    {
            //        _entity.Attributes.Add("etel_paymentresponsible", true);
            //    }
            //    else
            //    {
            //        _entity.Attributes.Add("etel_paymentresponsible", false);
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_annualincome"))
            //{
            //    if (postImage.Attributes["amxperu_annualincome"] != null)
            //    {
            //        //decimal annualincome = ((Money)(postImage.Attributes["amxperu_annualincome"])).Value;
            //        _entity.Attributes.Add("annualincome", ((Money)(postImage.Attributes["amxperu_annualincome"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_availablecreditlimit"))
            //{
            //    if (postImage.Attributes["amxperu_availablecreditlimit"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_availablecreditlimit", ((Money)(postImage.Attributes["amxperu_availablecreditlimit"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_bamwallet"))
            //{
            //    if (postImage.Attributes["amxperu_bamwallet"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_bamwallet", ((Money)(postImage.Attributes["amxperu_bamwallet"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_confirmedcrmcreditlimit"))
            //{
            //    if (postImage.Attributes["amxperu_confirmedcrmcreditlimit"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_confirmedcrmcreditlimit", ((Money)(postImage.Attributes["amxperu_confirmedcrmcreditlimit"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_currentbureaucreditlimit"))
            //{
            //    if (postImage.Attributes["amxperu_currentbureaucreditlimit"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_currentbureaucreditlimit", ((Money)(postImage.Attributes["amxperu_currentbureaucreditlimit"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_currentcrmcreditlimit"))
            //{
            //    if (postImage.Attributes["amxperu_currentcrmcreditlimit"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_currentcrmcreditlimit", ((Money)(postImage.Attributes["amxperu_currentcrmcreditlimit"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_currentwalletscreditlimits"))
            //{
            //    if (postImage.Attributes["amxperu_currentwalletscreditlimits"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_currentwalletscreditlimits", ((Money)(postImage.Attributes["amxperu_currentwalletscreditlimits"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_fixedwallet"))
            //{
            //    if (postImage.Attributes["amxperu_fixedwallet"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_fixedwallet", ((Money)(postImage.Attributes["amxperu_fixedwallet"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_requestedcrmcreditlimit"))
            //{
            //    if (postImage.Attributes["amxperu_requestedcrmcreditlimit"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_requestedcrmcreditlimit", ((Money)(postImage.Attributes["amxperu_requestedcrmcreditlimit"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_satelitaltvwallet"))
            //{
            //    if (postImage.Attributes["amxperu_satelitaltvwallet"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_satelitaltvwallet", ((Money)(postImage.Attributes["amxperu_satelitaltvwallet"])));
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_wirelessfixedwallet"))
            //{
            //    if (postImage.Attributes["amxperu_wirelessfixedwallet"] != null)
            //    {
            //        _entity.Attributes.Add("amxperu_wirelessfixedwallet", ((Money)(postImage.Attributes["amxperu_wirelessfixedwallet"])));
            //    }
            //}
            if (postImage.Attributes.Contains("amxperu_dateofbirth"))
            {
                if (postImage.Attributes["amxperu_dateofbirth"] != null)
                {
                    DateTime DOB = (DateTime)postImage.Attributes["amxperu_dateofbirth"];
                    _entity.Attributes.Add("birthdate", DOB.Date);
                }
            }
            //if (postImage.Attributes.Contains("amxperu_lastdateincludedin"))
            //{
            //    if (postImage.Attributes["amxperu_lastdateincludedin"] != null)
            //    {
            //        DateTime lastdateincludedin = (DateTime)postImage.Attributes["amxperu_lastdateincludedin"];
            //        _entity.Attributes.Add("amxperu_lastdateincludedin", lastdateincludedin.Date);
            //    }
            //}
            //if (postImage.Attributes.Contains("amxperu_validfrom"))
            //{
            //    if (postImage.Attributes["amxperu_validfrom"] != null)
            //    {
            //        DateTime ValidFrom = (DateTime)postImage.Attributes["amxperu_validfrom"];
            //        _entity.Attributes.Add("etel_validfrom", ValidFrom.Date);
            //    }
            //}
            Guid CreatedIndividualGuid = _orgService.Create(_entity);
            if (postImage.Attributes.Contains("amxperu_customertype"))
            {
                if (postImage.Attributes["amxperu_customertype"] != null)
                {
                    int customerType = (postImage.Attributes["amxperu_customertype"] as OptionSetValue).Value;
                    if (customerType == 250000000)
                    {
                        common.SetRecordStatus(_orgService, _entity.LogicalName, CreatedIndividualGuid, 0, 831260000);
                    }
                    else
                    {
                        common.SetRecordStatus(_orgService, _entity.LogicalName, CreatedIndividualGuid, 0, 1);
                    }
                }
            }
            return CreatedIndividualGuid;
        }
    }
}
