using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Query;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.Kindergarden
{
    public partial class Activities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Gardens.DataSource = new KindergardenQuery().Get();
                Gardens.DataBind();
            }
           
        }

        protected void ShowClick(object sender, EventArgs e)
        {
            var kindergarden = new KindergardenQuery().Get(int.Parse(Gardens.SelectedValue));
            ActivitiesGrid.DataSource = new ActivityQuery() { Kindergarden = kindergarden }.GetByFilter();
            ActivitiesGrid.DataBind();
        }
    }
}