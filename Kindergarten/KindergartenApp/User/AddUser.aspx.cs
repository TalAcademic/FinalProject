using System;
using Kindergarten.BL.Messages;

namespace KindergartenApp.User
{
    public partial class AddUser : System.Web.UI.Page
    {
        public IMessanger msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var x = 8;
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
    }
}