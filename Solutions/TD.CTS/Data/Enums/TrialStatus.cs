using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Data.Attributes;

namespace TD.CTS.Data.Enums
{
    public enum TrialStatus
    {
        [EnumDescriptionAttribute("Планируется")]
        Planning,
        [EnumDescriptionAttribute("В работе")]
        InWork,
        [EnumDescriptionAttribute("Завершено")]
        Comleted,
        [EnumDescriptionAttribute("Прервано")]
        Interrupted
    }
}
