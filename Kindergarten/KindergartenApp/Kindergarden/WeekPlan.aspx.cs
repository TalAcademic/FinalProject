using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Query;

namespace KindergartenApp.Kindergarden
{
    public partial class WeekPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Gardens.DataSource = new KindergardenQuery().Get();
                Gardens.DataBind();
            }
        }

        protected void Planclick(object sender, EventArgs e)
        {
            var firstDay = Calendar.SelectedDates.Cast<DateTime>().First();
            var lastDay = Calendar.SelectedDates.Cast<DateTime>().Last();


        }
    }
}