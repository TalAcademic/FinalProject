using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class ActivityMap :ClassMap<Activity>
    {
        public ActivityMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Date);
            Map(x => x.Type).CustomType<ActivityTypes>();
            Map(x => x.Info);
            References(x => x.Kindergarden);
        }
    }
}
