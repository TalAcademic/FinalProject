using System;
using System.Linq;
using Kindergarten.BL.Query;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.User
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            Teachers.DataSource = new TeachersQuery().Get().ToList();
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

                    break;
                    }
                case "2":
                    {
                        ChildData.Visible = false;
                        TeacherData.Visible = true;
                        break;
                    }
            }

        }

        protected void SaveClick(object sender, EventArgs e)
        {
            var selected = PersonTypes.SelectedValue;

            switch (selected)
            {
                case "1":
                    {
                        ChildData.Visible = true;
                        TeacherData.Visible = false;

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
                                             Substitute = new TeachersQuery().Get(int.Parse(Teachers.SelectedValue)),
                                             PhoneNum = Phone.Text,
                                             Seniority = int.Parse(Sen.Text),
                                             Password = Id.Text
                                         };
                        break;
                    }
            }
        }
    }
}