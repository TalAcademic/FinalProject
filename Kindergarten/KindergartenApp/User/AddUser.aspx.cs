using System;
using System.Linq;
using System.Web.UI.WebControls;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Query;
using Kindergarten.Domain.Entities;
using System.Collections.Generic;
using Kindergarten.BL;
using Kindergarten.BL.Messages;
using Kindergarten.Domain.Entities;


namespace KindergartenApp.User
{
    public partial class AddUser : System.Web.UI.Page
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
                        var entity = new Child
                                         {
                                             IdNum = Id.Text,
                                             FirstName = FirstName.Text,
                                             LastName = LastName.Text,
                                             BirthDay = DateTime.Parse(BirthDate.Text),
                                             PhoneNum = Phone.Text,
                                             Password = "abc123",
                                             Sensitivitieses = GetSensetivities()
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
                                             Substitute = new TeachersQuery().Get(int.Parse(Teachers.SelectedValue)),
                                             PhoneNum = Phone.Text,
                                             Seniority = int.Parse(Sen.Text),
                                             Password = "abc123"
                                         };
                        break;
                    }
            }
        }

        private IList<Sensitivity> GetSensetivities()
        {
            var selectedItems = (from ListItem item in Sensetivities.Items
                                 where item.Selected
                                 select int.Parse(item.Value)).ToList();

            return SensetivitiesQuery.Instance.Get(selectedItems).ToList();

        }
    }
}