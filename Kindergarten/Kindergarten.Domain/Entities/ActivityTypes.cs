using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public enum ActivityTypes
    {
        [Description("יום הולדת")]
        BirthDay,
        [Description("קבלת שבת")]
        Shaabat,
        [Description("חג")]
        Holiday,
        [Description("מסיבה עם הורים")]
        ParyWithParents,
        [Description("הצגה")]
        Show,
        [Description("טיול")]
        Trip
    }
}
