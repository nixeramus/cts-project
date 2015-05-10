﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class TrialCenterProcedureRoleDataFilter : DataFilter<TrialCenterProcedureRole>
    {
        public int? Id { get; set; }

        public int? TrialCenterId { get; set; }

        public int? TrialProcedureId { get; set; }

        public string RoleCode { get; set; }
    }
}