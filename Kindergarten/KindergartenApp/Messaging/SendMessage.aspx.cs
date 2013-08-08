using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Messages;
using Kindergarten.BL.Query;
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
                var toList = new List<string>();

                if (_messageSender is Teacher)
                {
                    toList.Add("ילד ספציפי");
                    toList.Add("כל ילדי הגן");
                    toList.Add("מפקחת");
                }
                if (_messageSender is Supervisor)
                {
                    toList.Add("גננת");
                    toList.Add("ילדי המחוז");
                    toList.Add("גננות המחוז");
                }

                Who.DataSource = toList;
                Who.AutoPostBack = true;
                Who.DataBind();
                if (_messageSender is Child)
                {
                    Who.Visible = false;
                    WhoLable.Visible = true;
                }

            }
        }

        protected void SendClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                var recipients = new List<Person>();
                if (_messageSender is Child)
                {
                    var c = (Child)_messageSender;
                    recipients.Add(c.Kindergarden.Teacher);
                }
                if (_messageSender is Teacher)
                {
                    SendMessageFromTeacher(recipients);
                }
                if (_messageSender is Supervisor)
                {
                    SendMessageFromSupervisor(recipients);
                }

                MessageManager.SendMessage(_messageSender, Title.Text, Message.Text, recipients);
                ClearControls();
                ClientScript.RegisterStartupScript(GetType(), "msg", "<script language='javascript'>showMessage()</script>");
            }
        }

        private void SendMessageFromSupervisor(List<Person> recipients)
        {
            var countyGardens =
                new KindergardenQuery {City = ((Supervisor) _messageSender).City}.GetByFilter().ToList();

            switch (Who.SelectedValue)
            {
                case "גננת":
                    var teacher = new PersonQuery().Get(int.Parse(Where.SelectedValue));
                    
                    if (teacher != null)
                    {
                        recipients.Add(teacher);
                    }
                    break;
                case "גננות המחוז":

                    recipients.AddRange(countyGardens.Select(c => c.Teacher).ToList());
                    break;
                case "ילדי המחוז":
                    foreach (var kindergarden in countyGardens)
                    {
                        recipients.AddRange(kindergarden.Children);
                    }
                    break;
            }
        }

        private void SendMessageFromTeacher(List<Person> recipients)
        {
            var garden = new KindergardenQuery {TeacherId = _messageSender.Id}.Get().First();

            switch (Who.SelectedValue)
            {
                case "ילד ספציפי":
                    {
                        var child = new PersonQuery().Get(int.Parse(Where.SelectedValue));

                        if (child != null)
                        {
                            recipients.Add(child);
                        }
                        break;
                    }
                case "כל ילדי הגן":
                    {


                        if (garden != null)
                        {
                            recipients.AddRange(garden.Children);
                        }
                        break;
                    }
                case "מפקחת":
                    {
                        var supervisor = new SupervisorQuery {City = garden.City}.GetByFilter().FirstOrDefault();

                        if (supervisor != null)
                            recipients.Add(supervisor);
                        break;
                    }
            }
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
                if (Who.SelectedValue == "ילד ספציפי")
                {
                    var garden = new KindergardenQuery { TeacherId = _messageSender.Id }.GetByFilter();

                    if (garden != null)
                    {
                        WhereLabel.Visible = true;
                        Where.Visible = true;
                        Where.DataSource = garden.SelectMany(x => x.Children).ToList();
                        Where.DataTextField = "FullName";
                        Where.DataValueField = "id";
                        Where.DataBind();
                    }
                }
                else
                {
                    Where.Visible = false;
                    WhereLabel.Visible = false;
                }
            }
            if (_messageSender is Supervisor)
            {
                if (Who.SelectedValue == "גננת")
                {
                    var countyGardens =
                        new KindergardenQuery { City = ((Supervisor)_messageSender).City }.GetByFilter().ToList();

                    var teachers = countyGardens.Select(c => new { name = c.Teacher.FullName, id = c.Teacher.Id });
                    WhereLabel.Visible = true;
                    Where.Visible = true;
                    Where.DataSource = teachers;
                    Where.DataTextField = "name";
                    Where.DataValueField = "id";
                    Where.DataBind();
                }
                else
                {
                    Where.Visible = false;
                    WhereLabel.Visible = false;
                }
            }
            if (_messageSender is Child)
            {
                Where.Visible = false;
                WhereLabel.Visible = false;
            }
        }
    }
}