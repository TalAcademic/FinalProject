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
    public class MessageEdit : SingletoneClass<MessageEdit>,IEdit<Message>
    {
        public void Add(Message item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Message item)
        {
            SessionFactoryHelper.CurrentSession.Update(item);
        }

        public void Delete(int id)
        {
            var entity = new MessageQuery().Get(id);
            SessionFactoryHelper.CurrentSession.Save(entity);
        }
    }
}
