using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary.OptionSets
{
    public enum etel_offertypecode
    {
        Offer = 831260000,
        Allowance = 831260001,
        Discount = 831260002,
        Promotion = 831260003,
        CSBundle = 831260004,
        SimpleSalesOffering = 831260005,
        Basic = 831260006,
        AdminCharge = 831260010,
        Device = 831260007,
        Addon = 831260008,
        Optional = 831260009
    }

    public enum etel_datatypecode
    {
        Text = 831260000,
        Number = 831260001,
        Datebox = 831260002,
        Combobox = 831260003,
        List = 831260004,
    }

    public enum amxperu_ordertypecode
    {
        BarringUnbarring = 831260015,
        MoveInstallationAddress = 250000002
    }

    public enum DataTypeCode
    {
        Value = 831260000,
        CharacteristicValue = 831260003,
    }

    public enum amxperu_creditcheckresult
    {
        Approved = 0,
        Rejected = 1,
        ManeulCreditCheck = 2,
        ApprovedWithCharges = 3
    }

    public enum amxperu_documenttype
    {
        CC__CEDULA_DE_CIUDADANIA = 1,
        NIT__NIT = 2,
        NE__NIT_DE_EXTRANJERIA = 3,
        CE__CEDULA_EXTRANJERIA = 4,
        PS__PASAPORTE = 5,
        CD__CARNET_DIPLOMATICO = 6,
        TI__TARJETA_DE_IDENTIDAD = 7,
        TE__TARJETA_DE_EXTRANJERIA = 8,
        RN__REGISTRO_DE_NACIMIENTO = 9
    }

    public enum amxperu_ordercapture_statuscode
    {
        Draft = 1,
        SubmittedwithErrors = 831260005,
        EligibilityFailure = 831260007,
        InProgress = 2,
        Scheduled = 831260000,
        Completedsuccessfully = 831260001,
        Completedwitherror_s = 831260002,
        Expired = 831260003,
        Completedwithpaymentresourceerror_s = 831260008,
        RejectedByCreditCheck = 831260011,
        WaitingForApproval = 831260012
    }

    public enum amxperu_offertypecode
    {
        Equipment = 1,
        Addon = 2,
        AddonService = 3,
        Discount = 4,
        Feature = 5,
        FreeUnit = 6,
        Gift = 7,
        Insurance = 8,
        OptionalService = 9,
        Plan = 10,
        Product = 11,
        Promotion = 12,
        Retention = 13,
        Testing = 14
    }

    public enum amxperu_offersubtypecode
    {
        Device = 1,
        BonusPoint = 2,
        Bundle = 3,
        Channel = 4,
        ChannelPackage = 5,
        Commitment = 6,
        Data = 7,
        DigitalAPI = 8,
        Discount = 9,
        MMS = 10,
        Policy = 11,
        Rate = 12,
        Rewards = 13,
        SMS = 14,
        Security = 15,
        Service = 16,
        Voice = 17,
        Volume = 18
    }

    public enum amxperu_customerdocument_signaturestatus
    {
        NotRequired = 1,
        PendingSignature = 2,
        ElectronicSignature = 3,
        ManualSignature = 4
    }

    public enum amxperu_customerdocument_status
    {
        NotGenerated = 1,
        Generated = 2,
        Canceled = 3
    }

    public enum amx_orderitemaction
    {
        Add =1,
        Modify = 2,
        No_Change = 3,
        Delete = 4
    }

    public enum amxperu_periodcode
    {
        Daily = 831260000,
        Monthly = 831260002
    }

    public enum amxperu_pricetypecode
    {
        OneTime = 831260000,
        Recurring = 831260001,
        Deposit = 831260002,
        Checkout = 831260003
    }

    public enum amx_offertypecode
    {
        Equipment = 1,
        Addon = 2,
        Addon_Service = 3,
        Discount = 4,
        Feature = 5,
        Gift = 7,
        Insurance = 8,
        Optional_Service = 9,
        Plan = 10,
        Product = 11,
        Promotion = 12,
        Retention = 13,
        Testing = 14
    }

    public enum amx_taxtype
    {
        IVA = 173800000,
        IMP_TELFIJA = 173800001,
        IMP_NUEVASINST = 173800002
    }

    public enum amx_unit
    {
        Percent = 173800000,
        Fixed = 173800001
    }

    public enum amx_family
    {
        Internet = 173800000,
        Telephony = 173800001,
        Television = 173800002,
        Mobile = 173800003,
        Telephony2 = 173800004
    }

    public enum amxperu_specificationsubtypecode
    {
        SIM = 1,
        CPE = 2,
        DataKit = 3,
        Device = 4,
        Equipment = 5,
        Handset = 6,
        API = 7,
        AccessPointName = 8,
        CardNumber = 9,
        ElectronicSerialNumber = 10,
        IMSI = 11,
        IP = 12,
        MACAdress = 13,
        MDFEquipmentID = 14,
        MSISDN = 15,
        PrivateID = 16,
        SerialNumber = 17,
        TelephoneNumber = 18,
        UID = 19,
    }

    public enum amxperu_datatypecode
    {
        Text = 831260000,
        Number = 831260001,
        Datebox = 831260002,
        Combobox = 831260003,
        List = 831260004,
        Decimal = 831260005
    }
}
