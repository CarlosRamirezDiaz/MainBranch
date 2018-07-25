using System.Collections.Generic;

namespace AmxPeruPlugins.Model.ProductOfferingSync
{
    public class ProductOfferingRequest
    {
        public List<ProductOffering> ProductOfferingList { get; set; }
    }

    public class ProductOffering
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string ProductTechnicalType { get; set; }
        public string StartDate { get; set; }
        public string Description { get; set; }
        public string OfferType { get; set; }
        public string OfferSubType { get; set; }

        public bool IsSellable { get; set; }
        public bool IsBundle { get; set; }
        public bool IsRollback { get; set; }
        public ProductSpecification ProductSpecification { get; set; }
        public List<Characteristic> CharacteristicList { get; set; }
        public List<POP> POPList { get; set; }
        public List<Relation> RelationList { get; set; }
        public List<Attachment> AttachmentList { get; set; }
        public List<Group> GroupList { get; set; }

    }

    public class ProductSpecification
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public List<CFSS> CFSSList { get; set; }
        public List<ResourceSpecification> ResourceSpecificationList { get; set; }
    }

    public class Attachment
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string MimeType { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentCode { get; set; }
        public string URL { get; set; }
    }

    public class Group
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string MinCardinality { get; set; }
        public string MaxCardinality { get; set; }
        public List<GroupSubOffer> GroupSubOffers { get; set; }
    }

    public class GroupSubOffer
    {
        public string POExternalId { get; set; }
        public string Type { get; set; }
        public string POPExternalId { get; set; }
    }

    public class CFSS
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string ServiceTechnicalType { get; set; }
        public List<Characteristic> CharacteristicList { get; set; }
    }

    public class ResourceSpecification
    {
        public string ExternalId { get; set; } //lrs_MSISDN
        public string Name { get; set; } //MSISDN
        public string ResourceType { get; set; } //LogicalResourceSpec
        public string SpecificationSubType { get; set; } //
        public List<Characteristic> ResourceCharacteristicList { get; set; }

        public string DefaultCardinality { get; set; }
        public string TargetCardinalityMin { get; set; }
        public string TargetCardinalityMax { get; set; }
    }

    public class POP
    {
        public string ExternalId { get; set; }
        public string PriceType { get; set; }
        public string Value { get; set; }
        public List<Characteristic> CharacteristicList { get; set; }
    }

    public class Relation
    {
        public string RelationExternalId { get; set; }
        public string RelationType { get; set; }
        public string ChangeType { get; set; }
        public string Sequence { get; set; }
        public string MaxQuantity { get; set; }
        public string MinQuantity { get; set; }
        public bool SuppressBSCSOneTimeCharges { get; set; }
    }

    public class Characteristic
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public bool Editable { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }

        public List<CharacteristicValue> CharacteristicValueList { get; set; }
    }

    public class CharacteristicValue
    {
        public string ExternalId { get; set; }
        public string Value { get; set; }
        public bool IsDefaultValue { get; set; }
    }

}
