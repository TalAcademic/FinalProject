﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;

namespace Kindergaten.EventSearchers
{
    public class HolidaySearcher:ISearcher
    {
        List<Holiday> knownHolidays = new List<Holiday>();
        public HolidaySearcher()
        {
            knownHolidays.Add(new Holiday() { Name = "ראש השנה", StartDate = new DateTime(2013, 9, 5) });
            knownHolidays.Add(new Holiday() { Name = "יום כיפור", StartDate = new DateTime(2013, 9, 13) });
            knownHolidays.Add(new Holiday() { Name = "סוכות", StartDate = new DateTime(2013, 9,19) });
            knownHolidays.Add(new Holiday() { Name = "חנוכה", StartDate = new DateTime(2013, 11,28) });
            knownHolidays.Add(new Holiday() { Name = "טו בשבט", StartDate = new DateTime(2013,1,16)});
            knownHolidays.Add(new Holiday() { Name = "פורים", StartDate = new DateTime(2013, 3, 16) });
            knownHolidays.Add(new Holiday() { Name = "פסח", StartDate = new DateTime(2013, 4, 14) });
            knownHolidays.Add(new Holiday() { Name = "יום השואה", StartDate = new DateTime(2013, 4, 28) });
            knownHolidays.Add(new Holiday() { Name = "יום הזכרון", StartDate = new DateTime(2013, 5, 5) });
            knownHolidays.Add(new Holiday() { Name = "יום העצמאות", StartDate = new DateTime(2013, 5, 6) });
            knownHolidays.Add(new Holiday() { Name = "לג בעומר", StartDate = new DateTime(2013, 5, 18) });
            knownHolidays.Add(new Holiday() { Name = "יום ירושלים", StartDate = new DateTime(2013, 5, 28) });
            knownHolidays.Add(new Holiday() { Name = "שבועות", StartDate = new DateTime(2013, 6, 4) });
        }

        public List<Event> GetEventsBetweenDates(int kindergartenId, DateTime start, DateTime end)
        {
            List <Event>  holidays= new List<Event>();
            var selected = from holy in knownHolidays
                           where holy.StartDate <= end && holy.StartDate >= start
                           select holy;
            foreach (var holiday in selected)
            {
                holidays.Add(new Event(){SpecificType = holiday.Name, Title = holiday.Name + " חל בתאריך "+holiday.StartDate});
            }
            for (int i=0;i<7;i++)
            {
                if(start.AddDays(i).DayOfWeek==DayOfWeek.Friday)
                {
                    holidays.Add(new Event() { SpecificType = "שישי", Title = "יום שישי חל בתאריך " + start.AddDays(i) });
                }
            }
            return holidays;
        }

        public string EventGeneralName
        {
            get { return "Holiday"; }
        }
    }

    public class Holiday
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }
}
