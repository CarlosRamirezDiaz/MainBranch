using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.Certicamara;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Certicamara
{
    public class AmxGetHClientJsonWebToken : XrmAwareCodeActivity
    {
        public InArgument<string> documentId { get; set; }
        public InArgument<string> fullName { get; set; }
        public OutArgument<BaseResponse<string>> response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var certicamaraBusiness = new CerticamaraBusiness(ContextProvider.OrganizationService);

            var returnValue = new BaseResponse<string>();
            try
            {
                var response = certicamaraBusiness.GetJsonWebToken(this.documentId.Get(context), this.fullName.Get(context));
                returnValue.Value = response;
                returnValue.Success = true;
            }
            catch (Exception ex)
            {
                returnValue.Success = false;
                returnValue.ErrorMessage = ex.Message;
            }

            this.response.Set(context, returnValue);
        }
    }
}
