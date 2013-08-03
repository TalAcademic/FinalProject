using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.EventSearcher;
using Kindergarten.BL.Query;
using Kindergarten.Domain.Entities;

namespace KindergartenApp
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var isUserLogIn = Session["CurrentUser"] != null;

            GeneralTitle.Visible = !isUserLogIn;
            LogedInTitle.Visible = isUserLogIn;
            MessagesDiv.Visible = isUserLogIn;

            if(isUserLogIn)
            {
                Messages.DataSource = new MessageQuery {Person = (Person) Session["CurrentUser"]}.GetByFilter();
                Messages.DataBind();
            }

        }
    }
}