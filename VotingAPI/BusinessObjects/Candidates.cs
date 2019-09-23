using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI.BusinessObjects
{
    public class Candidates
    {
        public string StudentNumber { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string MI { get; set; }

        public string LastName { get; set; }

        public int GradeLevel { get; set; }

        public string Section { get; set; }

        public string Gender { get; set; }

        public string Position { get; set; }

        public string SchoolYear { get; set; }
    }
}