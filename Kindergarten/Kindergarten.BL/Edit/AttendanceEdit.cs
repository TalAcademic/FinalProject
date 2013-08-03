using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.Edit
{
    public class AttendanceEdit :SingletoneClass<AttendanceEdit>, IEdit<Attendance>
    {
        public void Add(Attendance item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Attendance item)
        {
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
