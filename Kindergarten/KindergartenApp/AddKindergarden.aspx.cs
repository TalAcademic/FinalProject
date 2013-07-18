using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL;
using Kindergarten.BL.Utils;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp
{
    public partial class AddKindergarden : Page
    {
        private Kindergarden _currentKindergarden;
        public Kindergarden CurrentKindergarden
        {
            get { return (Kindergarden)ViewState["CurrentKindergarden"]; }
            set { ViewState["CurrentKindergarden"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindLists();
            //ChildrenGrid.DataSource = new List<Child>
            //                              {
            //                                  new Child {FirstName = "טל", LastName = "ברקוביץ", Id = 300253747}
            //                              };
            //ChildrenGrid.DataBind();
        }

        private void BindLists()
        {
            Cities.DataSource = EnumUtils.GetDescriptions(typeof(Cities));
            Cities.DataBind();

            Teachers.DataSource = SessionFactoryHelper.CurrentSession.Query<Teacher>();
            Teachers.DataBind();

            ChildrenList.DataSource = SessionFactoryHelper.CurrentSession.Query<Child>();
            ChildrenList.DataBind();
        }

        protected void SaveClick(object sender, EventArgs e)
        {
          //  var contant = ImageLoader.FileContent;
           // var bmp = new Bitmap(contant);

            //Cities city;
            var city = Enum.Parse(typeof(Cities),Cities.SelectedIndex.ToString(), true);

            var current = new Kindergarden
                              {
                                  Name = Name.Text,
                                  City = (Cities)city,
                                  ChildQty = int.Parse(ChildrenNum.Text),
                                  Teacher = Teachers.SelectedValue  != "" ? SessionFactoryHelper.CurrentSession.Load<Teacher>((int.Parse(Teachers.SelectedValue))) : null,
                                  Children = ChildrenGrid.Items.Cast<Child>().ToList()
                                              

                              };

            SessionFactoryHelper.CurrentSession.Save(current);
            CurrentKindergarden = current;
        }

        protected void AddChildClick(object sender, EventArgs e)
        {
            var child = SessionFactoryHelper.CurrentSession.Load<Child>(ChildrenList.SelectedValue);
            CurrentKindergarden.Children.Add(child);

             SessionFactoryHelper.CurrentSession.Update(CurrentKindergarden);

            ChildrenGrid.DataSource = CurrentKindergarden.Children;
            ChildrenGrid.DataBind();

        }
    }
}