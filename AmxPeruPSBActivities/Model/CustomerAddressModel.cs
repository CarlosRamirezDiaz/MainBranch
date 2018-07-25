using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class CustomerAddressModel
    {
        public Guid Id { get; set; }

        public string AddressName { get; set; }

        public string AddressNumber { get; set; }

        public string AddressType { get; set; }

        public string PrimaryAddress { get; set; }

        public string Province { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string Street3 { get; set; }

        public string District { get; set; }

        public  string Department { get; set; }

        public string Country { get; set; }


        //addressrow['addressname'] = (fetchaddressvaluexml[eachfetch].attributes.etel_name != null) ? fetchaddressvaluexml[eachfetch].attributes.etel_name.value : "";
        //                    addressrow['addressnumber'] = (fetchaddressvaluexml[eachfetch].attributes.etel_addressnumber != null) ? fetchaddressvaluexml[eachfetch].attributes.etel_addressnumber.value : "";
        //                    addressrow['addresstype'] = (fetchaddressvaluexml[eachfetch].attributes.etel_customeraddresstypecode != null) ? fetchaddressvaluexml[eachfetch].attributes.etel_customeraddresstypecode.formattedValue : "";
        //                    addressrow['primaryaddress'] = (fetchaddressvaluexml[eachfetch].attributes.etel_isprimaryaddress != null) ? fetchaddressvaluexml[eachfetch].attributes.etel_isprimaryaddress.value : "";
        //                    addressrow['province'] = (fetchaddressvaluexml[eachfetch].attributes.amxbase_province != null) ? fetchaddressvaluexml[eachfetch].attributes.amxbase_province.value : "";
        //                    addressrow['street1'] = (fetchaddressvaluexml[eachfetch].attributes.amxbase_street1 != null) ? fetchaddressvaluexml[eachfetch].attributes.amxbase_street1.formattedValue : "";
        //                    addressrow['street2'] = (fetchaddressvaluexml[eachfetch].attributes.etel_addressline2 != null) ? fetchaddressvaluexml[eachfetch].attributes.etel_addressline2.value : "";
        //                    addressrow['street3'] = (fetchaddressvaluexml[eachfetch].attributes.etel_addressline3 != null) ? fetchaddressvaluexml[eachfetch].attributes.etel_addressline3.value : "";
        //                    addressrow['district'] = (fetchaddressvaluexml[eachfetch].attributes.amxbase_district != null) ? fetchaddressvaluexml[eachfetch].attributes.amxbase_district.value : "";
        //                    addressrow['department'] = (fetchaddressvaluexml[eachfetch].attributes.amxbase_department != null) ? fetchaddressvaluexml[eachfetch].attributes.amxbase_department.value : "";
        //                    addressrow['country'] = (fetchaddressvaluexml[eachfetch].attributes.etel_countryid != null) ? fetchaddressvaluexml[eachfetch].attributes.etel_countryid.value : "";
        //                    listOfAddresses.push(addressrow);
    }
}
