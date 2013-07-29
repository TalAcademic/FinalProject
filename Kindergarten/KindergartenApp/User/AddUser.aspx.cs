using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Messages;
using Kindergarten.BL.Query;
using Kindergarten.BL.Utils;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.User
{
    public partial class AddUser : Page
    {
        public IMessanger msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }

        }

        private void BindList()
        {
            Sensetivities.DataSource = SensetivitiesQuery.Instance.Get();
            Sensetivities.DataBind();

            Cities.DataSource = EnumUtils.GetDescriptions(typeof(Cities));
            Cities.DataBind();

            Teachers.DataSource = new TeachersQuery().Get();
            Teachers.DataBind();
        }

        protected void PersonTypesChanged(object sender, EventArgs e)
        {
            var selected = PersonTypes.SelectedValue;

            switch (selected)
            {
                case "1":
                    {
                        ChildData.Visible = true;
                        TeacherData.Visible = false;
                        SupervisorData.Visible = false;
                        break;
                    }
                case "2":
                    {
                        ChildData.Visible = false;
                        TeacherData.Visible = true;
                        SupervisorData.Visible = false;
                        break;
                    }
                case "3":
                    {
                        ChildData.Visible = false;
                        TeacherData.Visible = false;
                        SupervisorData.Visible = true;
                        break;
                    }
                default:
                    {
                        ChildData.Visible = false;
                        TeacherData.Visible = false;
                        SupervisorData.Visible = false;
                        break;
                    }
            }

        }

        protected void SaveClick(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                var isUserExist = PersonQuery.Instance.GetByIdNum(Id.Text).Any();
                if (isUserExist)
                {
                    IdValidator.IsValid = false; return;
                }

                var selected = PersonTypes.SelectedValue;

                switch (selected)
                {
                    case "1":
                        {
                            var entity = new Child
                                             {
                                                 IdNum = Id.Text,
                                                 FirstName = FirstName.Text,
                                                 LastName = LastName.Text,
                                                 BirthDay = DateTime.Parse(BirthDate.Text),
                                                 PhoneNum = Phone.Text,
                                                 Password = "abc123",
                                                 Sensitivitieses = GetSensitivitieses()
                                             };

                            ChildEdit.Instance.Add(entity);
                            break;
                        }
                    case "2":
                        {
                            var entity = new Teacher
                                             {
                                                 IdNum = Id.Text,
                                                 FirstName = FirstName.Text,
                                                 LastName = LastName.Text,
                                                 BirthDay = DateTime.Parse(BirthDate.Text),
                                                 Substitute =
                                                     Teachers.SelectedValue != ""
                                                         ? new TeachersQuery().Get(int.Parse(Teachers.SelectedValue))
                                                         : null,
                                                 PhoneNum = Phone.Text,
                                                 Seniority = int.Parse(Sen.Text),
                                                 Password = "abc123"
                                             };
                            TeacherEdit.Instance.Add(entity);
                            break;
                        }

                    case "3":
                        {
                            var city = Enum.Parse(typeof(Cities), Cities.SelectedIndex.ToString(), true);

                            var entity = new Supervisor
                                             {
                                                 IdNum = Id.Text,
                                                 FirstName = FirstName.Text,
                                                 LastName = LastName.Text,
                                                 BirthDay = DateTime.Parse(BirthDate.Text),
                                                 PhoneNum = Phone.Text,
                                                 Password = "abc123",
                                                 City = (Cities)city
                                             };
                            SupervisorEdit.Instance.Add(entity);
                            break;
                        }
                }
            }
            ClearAll();
            BindList();

            ClientScript.RegisterStartupScript(GetType(), "msg", "<script language='javascript'>showMessage()</script>");
        }

        private void ClearAll()
        {
            Id.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            BirthDate.Text = "";
            Phone.Text = "";
            Sensetivities.ClearSelection();
            PersonTypes.SelectedValue = "0";
            Sen = null;
            Teachers.ClearSelection();
            Cities.SelectedIndex = 0;

            ChildData.Visible = false;
            TeacherData.Visible = false;
            SupervisorData.Visible = false;
        }

        private List<Sensitivity> GetSensitivitieses()
        {
            var selectedItems = (from ListItem item in Sensetivities.Items
                                 where item.Selected
                                 select int.Parse(item.Value)).ToList();

            return SensetivitiesQuery.Instance.Get(selectedItems).ToList();
        }
    }
}

