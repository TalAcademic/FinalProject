using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.Messaging
{
    public partial class MyMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Message> msgs = new List<Message>();
            msgs.Add(new Message(){Title = "הודעה לסיום השנה", SendTime = DateTime.Now.AddDays(-2), Sender = new Teacher(){FirstName = "דנה", LastName = "כהן"}});
            msgs.Add(new Message() { Title = "אבחון הילד אבי אברמוב", SendTime = DateTime.Now.AddDays(-1).AddHours(3), Sender = new Teacher() { FirstName = "דנה", LastName = "כהן" } });
            msgs.Add(new Message() { Title = "לגבי בני אלי", SendTime = DateTime.Now.AddDays(1).AddHours(5).AddMinutes(12), Sender = new Teacher() { FirstName = "חנה", LastName = "אליהו" } });

            GridView1.DataSource = msgs;
            DataBind();
        }
    }
}