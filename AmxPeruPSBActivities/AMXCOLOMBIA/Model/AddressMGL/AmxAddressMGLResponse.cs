using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model
{
    public class cmtAddressResponseDto
    {     
        public List<listAddresses> listAddresses { get; set; }
        public object message { get; set; }
        public object messageType { get; set; }
    }
    public class cmtRegionDto
    {
        public string name { get; set; }
        public object regionId { get; set; }
    }

    public class cmtGeographycStateDto
    {
        public string name { get; set; }
        public decimal stateId { get; set; }
        public string dateCode { get; set; }
    }

    public class cmtCityDto
    {
        public string name { get; set; }
        public cmtRegionDto region { get; set; }
        public int cityId { get; set; }
        public cmtGeographycStateDto geographycState { get; set; }
    }

    public class cmtDireccionTabuladaDto
    {
        public string idTipoDireccion { get; set; }
        public string barrio { get; set; }
        public string idDirCatastro { get; set; }
        public string itTipoPlaca { get; set; }
        public string itValorPlaca { get; set; }        
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
        public string idDireccionDetallada { get; set; }
    }

    public class cmtNodeDto
    {
        public string state { get; set; }
        public long qualificationDate { get; set; }
    }

    public class cmtSubCcmmTechnologyDto
    {
        public string state { get; set; }
        public long qualificationDate { get; set; }
        public decimal subCcmmTechnologyId { get; set; }
        public decimal subCcmmId { get; set; }
        public decimal ccmmId { get; set; }
        public List<cmtCcmmMarksDto> listCcmmMarks { get; set; }
    }

    public class cmtCcmmMarksDto {
        public string markId { get; set; }
        public string descriptionMark { get; set; }
    }

    public class cmtAddresMarksDto
    {
        public string markId { get; set; }
        public string descriptionMark { get; set; }
    }
    public class cmtHhppDto
    {
        public string state { get; set; }
        public cmtNodeDto node { get; set; }
        public decimal hhppId { get; set; }
        public string technology { get; set; }
        public string viability { get; set; }
        public cmtSubCcmmTechnologyDto subCcmmTechnology { get; set; }
        public cmtAddresMarksDto listAddresMarks { get; set; }
    }
    public class cmtCoverDto
    {
       
        public string technology { get; set; }
        public string node { get; set; }
    }

    public class cmtAddressDto
    {
        public string addressId { get; set; }
        public string igacAddress { get; set; }
        public object adressReliability { get; set; }
        public string latitudeCoordinate { get; set; }
        public string lengthCoordinate { get; set; }
        public cmtDireccionTabuladaDto splitAddres { get; set; }
        public List<cmtCoverDto> listCover { get; set; }
        public List<string> listCarrierCover { get; set; }
        public object stratum { get; set; }
        public List<cmtHhppDto> listHhpps { get; set; }
    }

    public class cmtDefaultBasicResponse {
        public cmtCityDto city { get; set; }
    }

    public class listAddresses
    {        
        public cmtAddressDto cmtAddressDto { get; set; }
        public cmtDefaultBasicResponse cmtDefaultBasicResponse { get; set; }
    }
}


