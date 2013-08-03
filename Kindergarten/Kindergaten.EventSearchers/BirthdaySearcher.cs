using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;


namespace Kindergaten.EventSearchers
{
    public class BirthdaySearcher:ISearcher
    {
        public string EventGeneralName 
        {
            get { return "Birthday"; }
        }
        public List<Event> GetEventsBetweenDates(int kindergartenId, DateTime start, DateTime end)
        {
            Kindergarden garden =
                SessionFactoryHelper.CurrentSession.Query<Kindergarden>().Single(k => k.Id == kindergartenId);
            List<Child> celebrationChildren = (from child in garden.Children
                                               where (child.BirthDay.Day >= start.Day && child.BirthDay.Day <= end.Day) && (child.BirthDay.Month >= start.Month && child.BirthDay.Month <= end.Month)
                                               select child).ToList();
            List<Event> bdays = new List<Event>();
            foreach (Child celebrationChild in celebrationChildren)
            {
                bdays.Add(new Event() { SpecificType = "יום הולדת ל" + celebrationChild.FullName, Title = "יום הולדת ל" + celebrationChild.FullName + " בתאריך " + celebrationChild.BirthDay.Date, ShoppingListForChild = { { "מתנת יום הולדת", 1 }, { "במבה", 0.2 }, { "ביסלי", 0.2 }, { "עוגה", 0.1 } } });
            }
            return bdays;
        }
    }
}
