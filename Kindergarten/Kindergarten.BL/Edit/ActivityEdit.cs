using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.BL.Query;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.Edit
{
    public class ActivityEdit : SingletoneClass<ActivityEdit>, IEdit<Activity>
    {
        public void Add(Activity item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Activity item)
        { 
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            var entity = new ActivityQuery().Get(id);
            SessionFactoryHelper.CurrentSession.Delete(entity);
        }
    }
}
