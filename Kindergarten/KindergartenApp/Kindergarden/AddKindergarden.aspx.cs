using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL;
using Kindergarten.BL.Utils;
using Entities = Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp
{
    public partial class AddKindergarden : Page
    {
        public Entities.Kindergarden CurrentKindergarden
        {
            get { return (Entities.Kindergarden)ViewState["CurrentKindergarden"]; }
            set { ViewState["CurrentKindergarden"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindLists();
        }

        private void BindLists()
        {
            Cities.DataSource = EnumUtils.GetDescriptions(typeof(Entities.Cities));
            Cities.DataBind();

            Teachers.DataSource = SessionFactoryHelper.CurrentSession.Query<Entities.Teacher>();
            Teachers.DataBind();

            ChildrenList.DataSource = SessionFactoryHelper.CurrentSession.Query<Entities.Child>();
            ChildrenList.DataBind();
        }

        protected void SaveClick(object sender, EventArgs e)
        {
         //   var  contant = ImageLoader.FileContent;
          //  var len = (int)contant.Length;
          //  var bytes = new byte[len];
          //  contant.Read(bytes, 0, len);

            var city = Enum.Parse(typeof(Entities.Cities),Cities.SelectedIndex.ToString(), true);

            var current = new Entities.Kindergarden
                              {
                                  Name = Name.Text,
                                  City = (Entities.Cities)city,
                                  ChildQty = int.Parse(ChildrenNum.Text),
                                  Teacher = Teachers.SelectedValue  != "" ? SessionFactoryHelper.CurrentSession.Load<Entities.Teacher>((int.Parse(Teachers.SelectedValue))) : null,
                                  Children = ChildrenGrid.Items.Cast<Entities.Child>().ToList(),
                                //  Image = bytes
                              };

            SessionFactoryHelper.CurrentSession.Save(current);
            CurrentKindergarden = current;

       //     var path = ResolveUrl(Server.MapPath("ImagesMerge/") + "1");
         //   var bmp = new Bitmap(contant);
         //   bmp.Save(path);
        //    ShowImage.ImageUrl = path;
        }

        protected void AddChildClick(object sender, EventArgs e)
        {
            var child = SessionFactoryHelper.CurrentSession.Load<Entities.Child>(ChildrenList.SelectedValue);
            CurrentKindergarden.Children.Add(child);

             SessionFactoryHelper.CurrentSession.Update(CurrentKindergarden);

            ChildrenGrid.DataSource = CurrentKindergarden.Children;
            ChildrenGrid.DataBind();

        }
    }
}