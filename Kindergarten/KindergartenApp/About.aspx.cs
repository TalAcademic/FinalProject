using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.EventSearcher;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;

namespace KindergartenApp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Child c1 = new Child() {FirstName = "דני", LastName = "אברהמי", BirthDay = new DateTime(2013, 9, 15)};
            SessionFactoryHelper.CurrentSession.Save(c1);

            Child c2 = new Child() { FirstName = "דוד", LastName = "כהן", BirthDay = new DateTime(2013, 5, 15) };
            SessionFactoryHelper.CurrentSession.Save(c2);

            Child c3 =new Child(){FirstName = "צדי", LastName = "צרפית", BirthDay = new DateTime(2013,9, 18)};
            SessionFactoryHelper.CurrentSession.Save(c3);
            List<Child> childs = new List<Child>(){c1,c2,c3};
            Kindergarten.Domain.Entities.Kindergarden k = new Kindergarten.Domain.Entities.Kindergarden(){Children = childs,Name = "מגדלור"};
            SessionFactoryHelper.CurrentSession.Save(k);
            EventSearcherFactory f = new EventSearcherFactory();
            List<ISearcher> s = f.GetAllSearchers();
            foreach (var searcher in s)
            {
               List<Event> all = searcher.GetEventsBetweenDates(k.Id, new DateTime(2013, 9, 10), new DateTime(2013, 9, 25));
            }
            int x = 7;
        } 
    }
}