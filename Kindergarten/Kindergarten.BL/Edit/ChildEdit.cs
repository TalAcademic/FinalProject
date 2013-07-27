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
    public class ChildEdit : SingletoneClass<ChildEdit>,IEdit<Child>
    {
      
        public void Add(Child item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Child item)
        {
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            var entity = new ChildQuery().Get(id);
            SessionFactoryHelper.CurrentSession.Delete(entity);
        }
    }
}
