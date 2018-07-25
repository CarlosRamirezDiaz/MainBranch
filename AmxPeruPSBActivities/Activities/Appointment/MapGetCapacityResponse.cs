using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using AmxPeruPSBActivities.Model.Appointment;
using System.IO;

namespace AmxPeruPSBActivities.Activities.Appointment
{
    
    public sealed class MapGetCapacityResponse: CodeActivity
    {
        public InArgument<GetCapacityResponseModel> GetCapacityResponse { get; set; }
        public InOutArgument<List<AppEventModel>> CalendarEvents { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {
            GetCapacityResponseModel capacity = GetCapacityResponse != null ? context.GetValue(GetCapacityResponse) : null;
            List<AppEventModel> Events = new List<AppEventModel>();
            if (capacity != null && capacity.capacities != null)
            {
                string[] hours;
                string startDateString, endDateString;
                foreach (CapacityModel cModel in capacity.capacities)
                {
                    if (cModel.WorkSkill != null)
                    {
                        AppEventModel appEvent = new AppEventModel();
                        appEvent.Title = "Available : " + cModel.Available; 
                        appEvent.AvailableTechnician = cModel.Available;
                        if (cModel.TimeSlot == "all-day")
                        {
                            startDateString = cModel.Date + " " + "00:00:00";
                            endDateString = cModel.Date + " " + "23:59:59";
                        }
                        else
                        {
                            hours = cModel.TimeSlot.Split('-');
                            startDateString = cModel.Date + " " + hours[0] + ":00:00";
                            endDateString = cModel.Date + " " + hours[1] + ":00:00";
                        }

                        appEvent.Start = DateTime.ParseExact(startDateString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        appEvent.End = DateTime.ParseExact(endDateString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        if (cModel.Restriction != null)
                        {
                            appEvent.Restriction = new Restriction();
                            appEvent.Restriction.Code = cModel.Restriction.Code != null ? cModel.Restriction.Code : string.Empty;
                            appEvent.Restriction.Type = cModel.Restriction.Type != null ? cModel.Restriction.Type : string.Empty;
                            appEvent.Restriction.Description = cModel.Restriction.Description != null ? cModel.Restriction.Description : string.Empty;
                        }

                        Events.Add(appEvent);
                    }
                }
            }

            CalendarEvents.Set(context, Events);
        }

    }

    public class LogHelper
    {

        public void CreateLog(string t)
        {
            StreamWriter writer = new StreamWriter("C:\\tcrm\\logs\\InstantErrorLog.txt", true);
            writer.WriteLine(t);
            writer.Close();
        }
    }

}
