using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Messages;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.Messaging
{
    public partial class MyMessages : System.Web.UI.Page
    {
        public IMessanger IMessanger { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var msgs = IMessanger.GetPersonMessages((Person)Session["CurrentUser"]);
                if (msgs.Count == 0)
                {
                    NoMessages.Visible = true;
                }
                else
                {
                    NoMessages.Visible = false;
                    GridView1.DataSource = msgs;
                    DataBind();
                }
            }

        }

    }
}