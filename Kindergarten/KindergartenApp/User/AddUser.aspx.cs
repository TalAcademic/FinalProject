using System;
using System.Linq;
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
            Teacher t = new Teacher() { Id = 123, FirstName = "Dana", LastName = "ss",BirthDay = DateTime.Now};
            SessionFactoryHelper.CurrentSession.Save(t);
            Child c = new Child() { Id = 322, FirstName = "ssdsd", LastName = "sdds", BirthDay = DateTime.Now };
            SessionFactoryHelper.CurrentSession.Save(c);
            msg.SendMessage(t, "Hello", "You are gay", new List<Person>(){c});

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