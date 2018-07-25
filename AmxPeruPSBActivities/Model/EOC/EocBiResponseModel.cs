using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AmxPeruPSBActivities.Model.EOC
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class EocBiResponseModel
    {
        public EocBiResponseModelE[] attrs;

        public DateTime? completionDate;

        public string createdBy;

        public System.DateTime? createdDate;

        public string description;

        public string externalID;

        public bool hasBI;

        public string id;

        public DateTime? interactionDate;

        public bool? isBundled;

        public bool? isLocked;

        public DateTime? lastModifiedDate;

        public string mode;

        public string modifiedBy;

        public string notes;

        public List<EocBiResponseModelItem> orderItems;

        public string orderSpecification;

        public string orderType;

        public string origOrderId;

        public EocBiResponseModelEItemRelatedEntities[] relatedEntities;

        public EocBiResponseModelRelatedOrders[] relatedOrders;

        public EocBiResponseModelRelatedParties[] relatedParties;

        public string requestID;

        public System.DateTime? requestedCompletionDate;

        public DateTime? requestedStartDate;

        public string requester;

        public string state;

        public string version;
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelE
    {
        public string name;

        public string value;
    }

    public partial class EocBiResponseModelItem
    {
        /// <remarks/>
        //[System.Xml.Serialization.XmlArrayItemAttribute("e", IsNullable = false)]
        //[JsonProperty("item")]
        public EocBiResponseModelEItem item;
    }

    public partial class EocBiResponseModelEItem
    {
        public string action;

        public string assignedPriority;

        public EocBiResponseModelEItemAttrsE[] attrs;

        public string createdBy;

        public DateTime? createdDate;

        public string description;

        public DateTime? dueDate;

        public string entities;

        public string id;

        public DateTime? lastModifiedDate;

        public string modifiedBy;

        public string notes;

        public string orderSpecification;

        public string orderType;

        public string parentOrderItemId;

        public EocBiResponseModelProduct product;

        public EocBiResponseModelEItemProductOffering productOffering;

        public string quantity;

        public EocBiResponseModelERelatedBusinessInteractions[] relatedBusinessInteractions;

        public EocBiResponseModelEItemRelatedEntities[] relatedEntities;

        public EocBiResponseModelItemRelatedOrderItems[] relatedOrderItems;

        public EocBiResponseModelEItemRelatedParties relatedParties;

        public EocBiResponseModelEItemRelatedScItems relatedScItems;

        public string requestID;

        public string requestedCompletionDate;

        public string requestedStartDate;

        public string requester;

        //public string resources;

        public string scId;

        public string services;
    }

    public class EocBiResponseModelProduct
    {
        public string productCharacteristics { get; set; }
        public string productId { get; set; }
        public string productPrice { get; set; }
        public bool? isBundled { get; set; }
        public string productSpecification { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemAttrsE
    {
        public string name;

        public string value;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemProductOffering
    {
        public string id;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemRelatedEntities
    {
        public string dependentEntityName;

        public EocBiResponseModelEItemRelatedEntitiesEEntity entity;

        public string entitySpecification;

        public string name;

        public string reference;

        public string type;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemRelatedEntitiesEEntity
    {
        public EocBiResponseModelEItemRelatedEntitiesEEntityContractCreationInformation contractCreationInformation;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemRelatedEntitiesEEntityContractCreationInformation
    {
        public EocBiResponseModelEItemRelatedEntitiesEEntityContractCreationInformationE[] attributes;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemRelatedEntitiesEEntityContractCreationInformationE
    {
        public string name;

        public string value;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelItemRelatedOrderItems
    {
        public string reference;

        public string relationCode;

        public string role;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemRelatedParties
    {
        private bool nullField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool @null
        {
            get
            {
                return this.nullField;
            }
            set
            {
                this.nullField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelEItemRelatedScItems
    {
        private bool nullField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool @null
        {
            get
            {
                return this.nullField;
            }
            set
            {
                this.nullField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelRelatedOrders
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelRelatedParties
    {
        public string role;

        public string reference;

        public EocBiResponseModelRelatedPartiesEParty party;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelRelatedPartiesEParty
    {
        public EocBiResponseModelRelatedPartiesEPartyCustomerInformation customerInformation;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelRelatedPartiesEPartyCustomerInformation
    {
        public EocBiResponseModelRelatedPartiesEPartyCustomerInformationE[] attributes;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EocBiResponseModelRelatedPartiesEPartyCustomerInformationE
    {
        public string name;

        public string value;
    }

    public class EocBiResponseModelERelatedBusinessInteractions
    {
        public string id { get; set; }
        public EocBiResponseModelValidFor validFor { get; set; }
        public EocBiResponseModelERelatedBusinessInteractionsCharacteristics[] characteristics { get; set; }

        public string getCharacteristicBiTypeValue()
        {
            foreach (var characteristic in this.characteristics)
                foreach (var version in characteristic.versions)
                    if (version.id == "BI_type")
                        return version.value;

            return string.Empty;
        }
        public string getCharacteristicValue(string id)
        {
            foreach (var characteristic in this.characteristics)
                foreach (var version in characteristic.versions)
                    if (version.id == id)
                        return version.value;

            return string.Empty;
        }

        public string getCharacteristicDisplayValue(string id)
        {
            foreach (var characteristic in this.characteristics)
                foreach (var version in characteristic.versions)
                    if (version.id == id)
                        return version.displayValue;

            return string.Empty;
        }
    }

    public class EocBiResponseModelValidFor
    {
        public DateTime? startDateTime { get; set; }
    }

    public class EocBiResponseModelERelatedBusinessInteractionsCharacteristics
    {
        public string id { get; set; }
        public EocBiResponseModelERelatedBusinessInteractionsVersions[] versions { get; set; }
    }

    public class EocBiResponseModelERelatedBusinessInteractionsVersions
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string displayValue { get; set; }
        public EocBiResponseModelValidFor validFor { get; set; }
        public string type { get; set; }
        public string valueType { get; set; }
        public EocBiResponseModelERelatedBusinessInteractionsCharacteristicValues[] characteristicValues { get; set; }
        public EocBiResponseModelERelatedBusinessInteractionsPropertiesPermissions[] propertiesPermissions { get; set; }
    }

    public class EocBiResponseModelERelatedBusinessInteractionsCharacteristicValues
    {
        public EocBiResponseModelValidFor validFor { get; set; }
        public string valueType { get; set; }
    }

    public class EocBiResponseModelERelatedBusinessInteractionsPropertiesPermissions
    {
        public string id { get; set; }
        public string type { get; set; }
        public bool isSelected { get; set; }
    }
}
