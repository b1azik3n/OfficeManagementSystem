using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class IncidentReportSummaryRequest
    {
        public Guid ClientId { get; set; }
    }
    public class IncidentReportSummaryResponse
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime ReportedOn { get; set; }
        public Guid LastAssignedToId { get; set; }
        public string LastAssignedToName { get; set; }
    }
    public class IncidentReportDetailedRequest
    {
        public Guid ClientId { get; set; }
        public Guid UserId { get; set; }

    }
    public class IncidentReportDetailedResponse
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public DateTime ReportedOn { get; set; }
        public Status Status { get; set; }
        public List<ForDetailedIncident>  forDetailedIncidents { get; set; }

    }
    public class ForDetailedIncident
    {
        public string AssignedTo { get; set; }
        public string AssignedOn { get; set; }
        public string AttemptMethod { get; set; }
        public string ApproximateTime { get; set; }
    }
}
