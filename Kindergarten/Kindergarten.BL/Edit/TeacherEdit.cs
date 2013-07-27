using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.BL.Query;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.Edit
{
    public class TeacherEdit : SingletoneClass<TeacherEdit>, IEdit<Teacher>
    {
        public void Add(Teacher item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Teacher item)
        {
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            var entity = new TeachersQuery().Get(id);
            SessionFactoryHelper.CurrentSession.Delete(entity);
        }
    }
}
