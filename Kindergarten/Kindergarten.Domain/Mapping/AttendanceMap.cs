using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class AttendanceMap :ClassMap<Attendance>
    {
        public AttendanceMap()
        {
            CompositeId().KeyProperty(x => x.Date).KeyReference(x => x.Child);
            Map(x => x.Arrived);
        }
    }
}
