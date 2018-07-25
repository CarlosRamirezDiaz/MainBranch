using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.Certicamara
{
    public class CerticamaraHClientPayload
    {
        public CerticamaraHClientPayload()
        {
            var expirationDateInMinutes = 5;

            this.iat = ((Int64)DateTime.UtcNow.AddMinutes(-1).Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            this.exp = ((Int64)DateTime.UtcNow.AddMinutes(expirationDateInMinutes).Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();

            this.DataRequestFingerPrint = new DataRequestFingerPrintModel();
        }

        public string iat { get; set; }
        public string exp { get; set; }
        public DataRequestFingerPrintModel DataRequestFingerPrint { get; set; }
    }
    public class DataRequestFingerPrintModel
    {
        public DataRequestFingerPrintModel()
        {
            this.idOperacion = "TCRM Test";
            this.idSucursal = "03";
            this.numeroIntentos = 5;
            this.minimoCalidad = 80;
            this.numeroIntentosCalidad = 3;
            this.url = @"http://pruebas.certihuella.co";
            this.urlUsuario = "ClaroPruebas_1";
            this.urlPassword = "9cc95cef75c595df9aab68adf5472a3ac282aeb98006448a635c5db035df2bed";
        }

        public string usuario { get; set; }
        public string idOperacion { get; set; }
        public string idSucursal { get; set; }
        public string cedula { get; set; }
        public int numeroIntentos { get; set; }
        public int minimoCalidad { get; set; }
        public int numeroIntentosCalidad { get; set; }
        public string url { get; set; }
        public string urlUsuario { get; set; }
        public string urlPassword { get; set; }
    }
}
