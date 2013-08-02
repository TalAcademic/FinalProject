using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Messages;
using Kindergarten.BL.Utils;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp.Messaging
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private Person _messageSender;
        public IMessanger MessageManager { get; set; }
        
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
            List<Person> recipients = new List<Person>();
            if (_messageSender is Teacher)
            {

                switch (Who.SelectedValue)
                {
                    case "ילד ספציפי":
                        Person child =
                            SessionFactoryHelper.CurrentSession.Query<Person>().First(v => v.Id == Convert.ToInt32(Where.SelectedValue));
                        if (child != null)
                        {
                            recipients.Add(child);
                        }
                        break;
                    case "כל ילדי הגן":
                        Kindergarten.Domain.Entities.Kindergarden garden =
                            SessionFactoryHelper.CurrentSession.Query<Kindergarten.Domain.Entities.Kindergarden>().
                                First(g => g.Teacher.Id == _messageSender.Id);
                        if (garden != null)
                        {
                            recipients = garden.Children.Select(c=>(Person)c).ToList();
                        }
                        break;
                }
            }
            if (_messageSender is Supervisor)
            {
                switch (Who.SelectedValue)
                {
                    case "גננת":
                        Person teacher =
                            SessionFactoryHelper.CurrentSession.Query<Person>().First(v => v.Id == Convert.ToInt32(Where.SelectedValue));
                        if (teacher != null)
                        {
                            recipients.Add(teacher);
                        }
                        break;
                    case "מחוז":
                        List<Kindergarten.Domain.Entities.Kindergarden> countyGardens =
                            SessionFactoryHelper.CurrentSession.Query<Kindergarten.Domain.Entities.Kindergarden>().
                                Where(g => g.City == ((Supervisor)_messageSender).City).ToList();
                        recipients = countyGardens.Select(c => (Person)c.Teacher).ToList();
                        break;
                }
            }
            MessageManager.SendMessage(_messageSender, Title.Text, Message.Text, recipients);
            ClearControls();
            ClientScript.RegisterStartupScript(GetType(), "msg",
                                                   "<script language='javascript'>showMessage()</script>");

        }

        private void ClearControls()
        {
            Where.Visible = false;
            WhereLabel.Visible = false;
            Title.Text = "";
            Message.Text = "";
            Who.SelectedIndex = -1;
        }

        protected void SelectedWho(object sender, EventArgs e)
        {
            if (_messageSender is Teacher)
            {
                
                switch (Who.SelectedValue)
                {
                    case "ילד ספציפי":
                        Kindergarten.Domain.Entities.Kindergarden garden =
                            SessionFactoryHelper.CurrentSession.Query<Kindergarten.Domain.Entities.Kindergarden>().
                                First(g => g.Teacher.Id == _messageSender.Id);
                        if (garden != null)
                        {
                            WhereLabel.Visible = true;
                            Where.Visible = true;
                            Where.DataSource = garden.Children;
                            Where.DataTextField = "FullName";
                            Where.DataValueField = "id";
                            Where.DataBind();
                        }
                        break;
                    case "כל ילדי הגן" :
                        Where.Visible = false;
                        WhereLabel.Visible = false;
                        break;
                }
            }
            if (_messageSender is Supervisor)
            {
                switch (Who.SelectedValue)
                {
                    case "גננת":
                        List<Kindergarten.Domain.Entities.Kindergarden> countyGardens =
                            SessionFactoryHelper.CurrentSession.Query<Kindergarten.Domain.Entities.Kindergarden>().
                                Where(g => g.City == ((Supervisor) _messageSender).City).ToList();
                        var teachers =countyGardens.Select(c => new {name = c.Teacher.FullName, id = c.Teacher.Id});
                        WhereLabel.Visible = true;
                        Where.Visible = true;
                        Where.DataSource = teachers;
                        Where.DataTextField = "name";
                        Where.DataValueField = "id";
                        Where.DataBind();

                        break;
                    case "מחוז" :
                        Where.Visible = false;
                        WhereLabel.Visible = false;
                        break;
                }
            }
        }
    }
}