using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.EventSearcher;
using Kindergarten.BL.Query;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp.Kindergarden
{
    public partial class WeekPlan : System.Web.UI.Page
    {
        public ISearcherFactory _searcher { get; set; }
        private Teacher _teacher;
        private Kindergarten.Domain.Entities.Kindergarden _garden;

        private Dictionary<string, double> _everyweekList = new Dictionary<string, double>() { { "מלפפון", 3 }, { "עגבניה", 2 }, { "גמבה", 2 }, { "גבינה לבנה", 0.5 }, { "לחם", 0.5 }, { "חומוס", 0.2 },  { "שוקולד למריחה", 0.1 } };

        protected void Page_Load(object sender, EventArgs e)
        {
            Teacher teacher = (Teacher) Session["CurrentUser"];
            _garden = SessionFactoryHelper.CurrentSession.Query<Kindergarten.Domain.Entities.Kindergarden>().First(g => g.Teacher.Id == teacher.Id);
        }

        protected void Planclick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Calendar.SelectedDate == DateTime.MinValue)
                {
                    CalendarValidator.IsValid = false;
                    return;
                }
                var firstDay = Calendar.SelectedDates.Cast<DateTime>().First();
                var lastDay = Calendar.SelectedDates.Cast<DateTime>().Last();
                List<ISearcher> searchers = _searcher.GetAllSearchers();
                Dictionary<string, double> shoppingList = new Dictionary<string, double>();
                List<Event> allEvents = new List<Event>();
                foreach (ISearcher searcher in searchers)
                {
                    List<Event> events = searcher.GetEventsBetweenDates(_garden.Id, firstDay, lastDay);
                    allEvents.AddRange(events);
                    foreach (var @event in events)
                    {
                        MergeToBigList(ref shoppingList, @event.ShoppingListForChild);
                    }
                }
                MergeToBigList(ref shoppingList, _everyweekList);
                List<ShoppingItem> finalList = new List<ShoppingItem>();
                int childrenCount = _garden.Children.Count;
                foreach (var d in shoppingList)
                {
                    finalList.Add(new ShoppingItem()
                                      {Name = d.Key, Quantity = Convert.ToInt32(Math.Ceiling(d.Value*childrenCount))});
                }
                ListLabel.Visible = true;
                ProductsLabel.Visible = true;
                ListView1.DataSource = allEvents;
                GridView1.DataSource = finalList;
                ListView1.DataBind();
                GridView1.DataBind();
            }

        }

        private void MergeToBigList(ref Dictionary<string, double> finalShoppingList, Dictionary<string, double> shoppingListToAdd)
        {
            foreach (KeyValuePair<string, double> item in shoppingListToAdd)
            {
                if (finalShoppingList.ContainsKey(item.Key))
                {
                    finalShoppingList[item.Key] += item.Value;
                }
                else
                {
                    finalShoppingList.Add(item.Key, item.Value);
                }
            }
        }
    }

    public class ShoppingItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}