using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI.BusinessObjects
{
    public class VoteData
    {
        public string StudentNumber { get; set; }

        public string FullName { get; set; }

        public int GradeLevel { get; set; }

        public string Section { get; set; }

        public string CandidateNumber { get; set; }

        public DateTime DateTimeVoted { get; set; }

    }
}