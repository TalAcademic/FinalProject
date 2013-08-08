using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Query;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp.Messaging
{
    public partial class ViewMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.Params["messageId"]);
            var msg = new MessageQuery().Get(id);
                //SessionFactoryHelper.CurrentSession.Query<Message>().Single(c => c.Id == id);
            if (msg != null)
            {
                Date.Text = msg.SendTime.ToString();
                Title.Text = msg.Title;
                Message.Text = msg.Body;
                From.Text = msg.Sender.FullName;

            }
        }
    }
}