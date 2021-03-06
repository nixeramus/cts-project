﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class TrialCenterDataFilter : DataFilter<TrialCenter>
    {
        public int? Id { get; set; }

        public string TrialCode { get; set; }

        public int? TrialVersion { get; set; }
    }
}
