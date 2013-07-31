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
    public class KindergardenEdit :SingletoneClass<KindergardenEdit>,IEdit<Kindergarden>
    {
        public void Add(Kindergarden item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Kindergarden item)
        {
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            var entity = new KindergardenQuery().Get(id);
            SessionFactoryHelper.CurrentSession.Delete(entity);
        }
    }
}
