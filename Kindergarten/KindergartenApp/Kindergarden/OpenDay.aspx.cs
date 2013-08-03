using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Edit;
using Kindergarten.BL.EventSearcher;
using Kindergarten.BL.Query;
using Kindergarten.Data;
using Entities = Kindergarten.Domain.Entities;

namespace KindergartenApp.Kindergarden
{
    public partial class OpenDay : System.Web.UI.Page
    {
        public ISearcherFactory _searcher { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Gardens.DataSource = new KindergardenQuery().Get();
                Gardens.DataBind();
            }
        }

        protected void ShowAttendanceClick(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                if (DatePicker.SelectedDate == DateTime.MinValue)
                {
                    CalendarValidator.IsValid = false;
                    return;
                }
                var garden = new KindergardenQuery().Get(int.Parse(Gardens.SelectedValue));
                var query = new AttendanceQuery
                                {
                                    Kindergarden = garden,
                                    Date = DatePicker.SelectedDate
                                };
                var result = query.GetByFilter().ToList();
                if (!result.Any())
                {

                    foreach (var child in garden.Children)
                    {
                        var entity = new Entities.Attendance
                                         {
                                             Arrived = false,
                                             Child = child,
                                             Date = DatePicker.SelectedDate
                                         };
                        AttendanceEdit.Instance.Add(entity);
                        result.Add(entity);
                    }

                }
                ChildrenGrid.DataSource = result;
                ChildrenGrid.DataBind();

                List<Entities.ISearcher> searchers = _searcher.GetAllSearchers();
                List<Entities.Event> allEvents = new List<Entities.Event>();
                foreach (Entities.ISearcher searcher in searchers)
                {
                    allEvents.AddRange(searcher.GetEventsBetweenDates(garden.Id, DatePicker.SelectedDate,
                                                                      DatePicker.SelectedDate));
                }
                ListLabel.Visible = true;
                ListView1.DataSource = allEvents;
                ListView1.DataBind();
            }
        }

        protected void SaveClick(object sender, EventArgs e)
        {


            foreach (var item in ChildrenGrid.Items)
            {
                var childId = ((Label)((DataGridItem)item).FindControl("Id")).Text;
                var arrived = ((CheckBox)((DataGridItem)item).FindControl("Arrived")).Checked;

                var entity = new Entities.Attendance
                                 {
                                     //   Arrived = (bool)arrived,
                                     Child = new ChildQuery().Get(int.Parse(childId)),
                                     Date = DatePicker.SelectedDate,
                                     Arrived = arrived
                                 };

                AttendanceEdit.Instance.Update(entity);
            }
        }


        protected void EditChild(object source, DataGridCommandEventArgs e)
        {
            var id = ((Label)(e.Item).FindControl("Id")).Text;
            var url = ResolveUrl("../User/AddUser.aspx?code=" + id);

            Response.Redirect(url);
        }
    }
}