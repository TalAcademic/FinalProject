using System;
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