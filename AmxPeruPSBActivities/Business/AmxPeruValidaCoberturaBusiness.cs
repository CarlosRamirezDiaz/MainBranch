using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.Business
{
   public class AmxPeruValidaCoberturaBusiness
    { 
        public AMxperuValidaCoberturaResponse AMxperuValidaCobertura(AMxperuValidaCoberturaRequest _AMxperuValidaCoberturaRequest, OrganizationServiceProxy orgservice)
        {
            AMxperuValidaCoberturaResponse _AMxperuValidaCoberturaResponse = null;
            try
            {
                //if (_AMxperuValidaCoberturaRequest != null)
                //{
                    //ConsultCoverageRequestType objReqService = new ConsultCoverageRequestType()
                    //{
                    //    latitude = "12.0464° S",
                    //    longitude = "77.0428° W"
                    //};

                    //// ConsultCoverage.ConsultCoverage objService = new ConsultCoverage.ConsultCoverage();
                    ////objService.ConsultCoverage(objReqService);

                    //ConsultCoverageResponseType objResService = new ConsultCoverageResponseType()
                    //{
                    //    TechnologiesType = new TechnologiesType()
                    //    {
                    //        ListTechnologies = new ListTechnologiesType()
                    //        {
                    //            Plane = "plane",
                    //            Type = "type"
                    //        }
                    //    },

                    //    ProjectsType = new ProjectsType()
                    //    {
                    //            FechaFinProyecto = DateTime.Now,
                    //            NombreProyecto = "NombreProyecto",
                    //            TecnologiaProyecto = "TecnologiaProyecto"
                    //    }                    

                    //};


                    _AMxperuValidaCoberturaResponse = new AMxperuValidaCoberturaResponse()
                    {
                        technologies = new TechnologiesType()
                        {
                            ListTechnologies = new ListTechnologiesType()
                            {
                                Plane = "plane",
                                Type = "type"
                            }
                        },

                        Projects = new ProjectsType()
                        {
                            FechaFinProyecto = DateTime.Now,
                            NombreProyecto = "NombreProyecto",
                            TecnologiaProyecto = "TecnologiaProyecto"
                        }
                    };
                //}

                return _AMxperuValidaCoberturaResponse;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
