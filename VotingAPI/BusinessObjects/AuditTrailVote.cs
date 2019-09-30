using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI.BusinessObjects
{
    public class AuditTrailVote
    {
        public int StudentNumber { get; set; }
        public string President { get; set; }
        public string VicePresident { get; set; }
        public string Secretary { get; set; }
        public string Treasurer { get; set; }
        public string Auditor { get; set; }
        public string BusinessManager { get; set; }
        public string PublicInformationOfficer { get; set; }
        public int DateTimeVoted { get; set; }
    }
}