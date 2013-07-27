using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.Edit
{
    public class SupervisorEdit : SingletoneClass<SupervisorEdit>, IEdit<Supervisor>
    {
        public void Add(Supervisor item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Supervisor item)
        {
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
