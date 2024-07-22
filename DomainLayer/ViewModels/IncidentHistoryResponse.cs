using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class IncidentHistoryResponse
    {
        public string IncidentName { get; set; }
        public DateTime Created_On { get; set; }

        public List<AttemptDetail> AttemptDetails { get; set; }
        public IncidentStatus LastAction {  get; set; }
        public DateTime LastAction_On { get; set; }

    }
    public class AttemptDetail
    {
        public int Attempt_Number { get; set; }
        public string Attempt_Method { get; set; }
        public string Estimated_Time { get; set; }
        public bool IsSuccessful { get; set; }
    }



}
