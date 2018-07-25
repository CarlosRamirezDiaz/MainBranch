using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
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
   public class AmxPeruBulkIndividualCreationBusiness
    {
        public List<Annotation> CreateMultipleAnnotationFromFile(Guid OrderCaptureId, string EncodedFile)
        {
            List<Annotation> annotationList = new List<Annotation>();
            List<string> rows = new List<string>();
            string headerData;

            if (!string.IsNullOrEmpty(EncodedFile))
            {
                //  var fileData0 = Convert.ToBase64String(EncodedFile);
                var fileData0 = EncodedFile;
                var fileData = Convert.FromBase64String(fileData0);
                if (fileData.Length > 0)
                {
                    string[] data = Encoding.UTF8.GetString(fileData).Split(new char[] { '\n' });
                    headerData = data[0];   //  get header to use for other files
                    rows = data.Skip(1).ToList(); // get all lines except header
                    int rowsCountPerFile = 200;
                    int filecount = Convert.ToInt32(Math.Ceiling(rows.Count / Convert.ToDouble(rowsCountPerFile)));
                    List<string> encodedFiles = new List<string>();
                    for (int i = 0; i < filecount; i++)
                    {
                        string newFileData = string.Join("\n", rows.Skip(i * rowsCountPerFile).Take(rowsCountPerFile).ToArray()); // take n rows
                        string newFileString = string.Format("{0}\n{1}", headerData, newFileData);

                        annotationList.Add(new Annotation()
                        {
                            ObjectId = new EntityReference()
                            {
                                LogicalName = etel_ordercapture.EntityLogicalName,
                                Id = OrderCaptureId
                            },
                            StepId = "C",
                            Subject = "Bulk Upload Entity Data",
                            DocumentBody = Convert.ToBase64String(Encoding.UTF8.GetBytes(newFileString)),
                        });
                    }
                }
            }
            return annotationList;
        }
    }
}
