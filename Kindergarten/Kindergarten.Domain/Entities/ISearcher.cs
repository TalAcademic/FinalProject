using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public interface ISearcher
    {
        List<Event> GetEventsBetweenDates(int kindergartenId, DateTime start, DateTime end);
        string EventGeneralName { get;  }
    }
}
