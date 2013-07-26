using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.Edit
{
    public class ChildEdit : IEdit<Child>
    {
        private static ChildEdit _instance;

        public static ChildEdit Instance
        {
            get { return _instance ?? (_instance = new ChildEdit()); }
        }

        public ChildEdit()
        {
        }

        public void Add(Child item)
        {
            SessionFactoryHelper.CurrentSession.Save(item);
        }

        public void Update(Child item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
