﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAppAPI.BusinessObjects
{
    public class Students
    {
        public int StudentNumber { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }
    }
}