using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;

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
            return new List<Event>();
        }
    }
}
