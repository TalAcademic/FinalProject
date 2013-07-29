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
    public class PersonEdit : SingletoneClass<PersonEdit>,IEdit<Person>
    {
        public void Add(Person item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Person item)
        {
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            var entity = new PersonQuery().Get(id);
            SessionFactoryHelper.CurrentSession.Delete(entity);
        }
    }
}
