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
    public class BirthdaySearcher : ISearcher
    {
        public string EventGeneralName
        {
            get { return "Birthday"; }
        }
        public List<Event> GetEventsBetweenDates(int kindergartenId, DateTime start, DateTime end)
        {
            var garden = SessionFactoryHelper.CurrentSession.Get<Kindergarden>(kindergartenId);
            var celebrationChildren = (from child in garden.Children
                                       where (child.BirthDay.Day >= start.Day && child.BirthDay.Day <= end.Day) && 
                                       (child.BirthDay.Month >= start.Month && child.BirthDay.Month <= end.Month)
                                       select child).ToList();

            return celebrationChildren.Select(celebrationChild => new Event
            {
                SpecificType = "יום הולדת ל" + celebrationChild.FullName,
                Title = "יום הולדת ל" +
                    celebrationChild.FullName + " בתאריך " + celebrationChild.BirthDay.Day + "." +
                    celebrationChild.BirthDay.Month,
                ShoppingListForChild =
                    {
                        { "מתנת יום הולדת", 1 }, 
                        { "במבה", 0.2 }, 
                        { "ביסלי", 0.2 },
                        { "עוגה", 0.1 }
                    }
            }).ToList();
        }
    }
}
