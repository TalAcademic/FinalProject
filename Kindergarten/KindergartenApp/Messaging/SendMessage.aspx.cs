using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp.Messaging
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private Person _messageSender;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _messageSender = (Person)Session["CurrentUser"];
            if (!IsPostBack)
            {
                List<string> toList = new List<string>();
                if (_messageSender is Child)
                {

                }
                if (_messageSender is Teacher)
                {
                    toList.Add("ילד ספציפי");
                    toList.Add("כל ילדי הגן");
                }
                if (_messageSender is Supervisor)
                {
                    toList.Add("גננת");
                    toList.Add("מחוז");
                }
                Who.DataSource = toList;
                Who.AutoPostBack = true;
                Who.DataBind();
            }
        }

        protected void SendClick(object sender, EventArgs e)
        {
            Message msg = new Message() { Body = Message.Text, Title = Title.Text, Sender = (Person)Session["CurrentUser"] };

        }

        protected void SelectedWho(object sender, EventArgs e)
        {
            switch (Who.SelectedValue)
            {
                case "ילד ספציפי":
                    Kindergarten.Domain.Entities.Kindergarden garden = SessionFactoryHelper.CurrentSession.Query<Kindergarten.Domain.Entities.Kindergarden>().SingleOrDefault(g => g.Teacher.Id == _messageSender.Id); 
                    if (garden!= null)
                    {
                        Where.DataSource = garden.Children;
                        Where.DataTextField = "name";
                        Where.DataBind();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}