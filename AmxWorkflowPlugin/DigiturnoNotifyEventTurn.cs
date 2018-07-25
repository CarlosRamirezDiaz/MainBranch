// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

//<snippetDistanceCalculator>
using System;
using System.Activities;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;

// These namespaces are found in the Microsoft.Xrm.Sdk.dll assembly
// located in the SDK\bin folder of the SDK download.
using Microsoft.Xrm.Sdk;

// These namespaces are found in the Microsoft.Xrm.Sdk.Workflow.dll assembly
// located in the SDK\bin folder of the SDK download.
using Microsoft.Xrm.Sdk.Workflow;
using System.Text;

namespace AmxWorkflowPlugins
{

    public sealed partial class DigiturnoNotifyEventTurn : CodeActivity
    {
        // Define Input/Output Arguments
        [RequiredArgument]
        [Input("Digiturno Id")]
        public InArgument<string> digiturnoId { get; set; }

        [RequiredArgument]
        [Input("Event Id")]
        public InArgument<string> eventId { get; set; }

        [Input("BusinessInteraction Id")]
        public InArgument<string> businessInteractionId { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {

            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory =
                executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service =
                serviceFactory.CreateOrganizationService(context.UserId);

            // Set the result in the output parameter
            this.SendDigiturnoNotifyEventTurn(this.digiturnoId.Get(executionContext),
                this.eventId.Get(executionContext),
                this.businessInteractionId.Get(executionContext));
        }

        private void SendDigiturnoNotifyEventTurn(string digiturnoId, string eventId, string interactionId)
        {
            var request = "{\"request\":" +
                "{ \"$type\":\"AmxCoPSBActivities.Model.Digiturno.DigiturnoNotifyEventTurnRequest, AmxPeruPSBActivities\"," +
                " \"IdBusinessInteraction\" : {{IdBusinessInteraction}}," +
                "\"IdEvent\" : {{IdEvent}}," +
                "\"IdTurn\" : \"{{IdTurn}}\"" +
                 "}" +
            "}";

            request = request.Replace("{{IdBusinessInteraction}}", interactionId);
            request = request.Replace("{{IdEvent}}", eventId);
            request = request.Replace("{{IdTurn}}", digiturnoId);

            var url = @"http://localhost:6006" + @"/api/v1/workflow/AmxCoDigiturnoNotifyEventTurn";

            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);

                //NetworkCredential credential = new NetworkCredential(user, password, domain);
                //CredentialCache credentialCache = new CredentialCache();
                //credentialCache.Add(new Uri(url), "NTLM", credential);

                //webrequest.Credentials = credentialCache;
                webrequest.Credentials = CredentialCache.DefaultCredentials;

                webrequest.Method = "POST";
                webrequest.Timeout = 30000;
                webrequest.ContentType = "application/json";
                byte[] sentData = Encoding.UTF8.GetBytes(request);
                webrequest.ContentLength = sentData.Length;

                using (System.IO.Stream sendStream = webrequest.GetRequestStream())
                {
                    sendStream.Write(sentData, 0, sentData.Length);
                    sendStream.Close();
                }

                string jsonResponse = string.Empty;
                System.Net.WebResponse res = webrequest.GetResponse();
                System.IO.Stream ReceiveStream = res.GetResponseStream();
                using (System.IO.StreamReader sr = new
                System.IO.StreamReader(ReceiveStream, Encoding.UTF8))
                {
                    Char[] read = new Char[256];
                    int count = sr.Read(read, 0, 256);

                    while (count > 0)
                    {
                        String str = new String(read, 0, count);
                        jsonResponse += str;
                        count = sr.Read(read, 0, 256);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}