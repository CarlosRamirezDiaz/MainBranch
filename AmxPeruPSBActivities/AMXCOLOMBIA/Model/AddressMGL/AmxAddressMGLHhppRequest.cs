using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model
{
    public class AmxAddressMGLHhppRequest
    {
        public DrDireccion drDireccion { get; set; }
        public string comunidad { get; set; }
        public string tipoAdicion { get; set; }
        public string tipoNivel { get; set; }
        public string valorNivel { get; set; }
        public string idUsuario { get; set; }
    }

    public class DrDireccion
    {
        public string id { get; set; }
        public string estrato { get; set; }
        public string barrio { get; set; }
        public string idSolicitud { get; set; }
        public string idDirCatastro { get; set; }
        public string itTipoPlaca { get; set; }
        public string itValorPlaca { get; set; }
        public string idTipoDireccion { get; set; }
        public string dirPrincAlt { get; set; }
        public string tipoViaPrincipal { get; set; }
        public string numViaPrincipal { get; set; }
        public string ltViaPrincipal { get; set; }
        public string nlPostViaP { get; set; }
        public string bisViaPrincipal { get; set; }
        public string cuadViaPrincipal { get; set; }
        public string tipoViaGeneradora { get; set; }
        public string numViaGeneradora { get; set; }
        public string ltViaGeneradora { get; set; }
        public string nlPostViaG { get; set; }
        public string bisViaGeneradora { get; set; }
        public string cuadViaGeneradora { get; set; }
        public string placaDireccion { get; set; }
        public string cpTipoNivel1 { get; set; }
        public string cpTipoNivel2 { get; set; }
        public string cpTipoNivel3 { get; set; }
        public string cpTipoNivel4 { get; set; }
        public string cpTipoNivel5 { get; set; }
        public string cpTipoNivel6 { get; set; }
        public string cpValorNivel1 { get; set; }
        public string cpValorNivel2 { get; set; }
        public string cpValorNivel3 { get; set; }
        public string cpValorNivel4 { get; set; }
        public string cpValorNivel5 { get; set; }
        public string cpValorNivel6 { get; set; }
        public string mzTipoNivel1 { get; set; }
        public string mzTipoNivel2 { get; set; }
        public string mzTipoNivel3 { get; set; }
        public string mzTipoNivel4 { get; set; }
        public string mzTipoNivel5 { get; set; }
        public string mzValorNivel1 { get; set; }
        public string mzValorNivel2 { get; set; }
        public string mzValorNivel3 { get; set; }
        public string mzValorNivel4 { get; set; }
        public string mzValorNivel5 { get; set; }
        public string mzTipoNivel6 { get; set; }
        public string mzValorNivel6 { get; set; }
        public string estadoDirGeo { get; set; }
        public string letra3G { get; set; }
        public string dirEstado { get; set; }
        public string barrioTxtBM { get; set; }
    }
}
