using AmxPeruCommonLibrary.OptionSets;

namespace AmxPeruPSBActivities.Common
{
    public class OptionSet
    {
        public static string RetrieveDocumentTypeByValue(int value)
        {
            switch (value)
            {
                case (int)amxperu_documenttype.CC__CEDULA_DE_CIUDADANIA:
                    return FormatOptionSetName(amxperu_documenttype.CC__CEDULA_DE_CIUDADANIA.ToString());
                case (int)amxperu_documenttype.NIT__NIT:
                    return FormatOptionSetName(amxperu_documenttype.NIT__NIT.ToString());
                case (int)amxperu_documenttype.NE__NIT_DE_EXTRANJERIA:
                    return FormatOptionSetName(amxperu_documenttype.NE__NIT_DE_EXTRANJERIA.ToString());
                case (int)amxperu_documenttype.CE__CEDULA_EXTRANJERIA:
                    return FormatOptionSetName(amxperu_documenttype.CE__CEDULA_EXTRANJERIA.ToString());
                case (int)amxperu_documenttype.PS__PASAPORTE:
                    return FormatOptionSetName(amxperu_documenttype.PS__PASAPORTE.ToString());
                case (int)amxperu_documenttype.CD__CARNET_DIPLOMATICO:
                    return FormatOptionSetName(amxperu_documenttype.CD__CARNET_DIPLOMATICO.ToString());
                case (int)amxperu_documenttype.TI__TARJETA_DE_IDENTIDAD:
                    return FormatOptionSetName(amxperu_documenttype.TI__TARJETA_DE_IDENTIDAD.ToString());
                case (int)amxperu_documenttype.TE__TARJETA_DE_EXTRANJERIA:
                    return FormatOptionSetName(amxperu_documenttype.TE__TARJETA_DE_EXTRANJERIA.ToString());
                case (int)amxperu_documenttype.RN__REGISTRO_DE_NACIMIENTO:
                    return FormatOptionSetName(amxperu_documenttype.RN__REGISTRO_DE_NACIMIENTO.ToString());
                default:
                    return null;
            }
        }

        private static string FormatOptionSetName(string name)
        {
            return name.Replace("__", "-").Replace("_", " ");
        }
    }
}
