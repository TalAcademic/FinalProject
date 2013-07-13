using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public enum Cities
    {
        [Description("ראשון לציון")]
        Rishon,
        [Description("רחובות")]
        Rehovot,
        [Description("חולון")]
        Holon,
        [Description("תל אביב")]
        TelAviv,
        [Description("הרצליה")]
        Herzelia,
        [Description("בת ים")]
        BatYam,
        [Description("נהריה")]
        Naharia,
        [Description("אילת")]
        Eilat,
        [Description("ירושלים")]
        Jerusalem,
        [Description("רמת גן")]
        RamatGen,
        [Description("נתניה")]
        Natania,
        [Description("אחר")]
        Other
    }
}
