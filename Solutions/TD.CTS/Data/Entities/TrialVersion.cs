using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialVersion : Entity
    {
        public int Id { get; set; }

        public string TrialCode { get; set; }

        public string AuthorLogin { get; set; }

        public DateTime VersionDate { get; set; }

        public string VersionStatus { get; set; }
    }
}
