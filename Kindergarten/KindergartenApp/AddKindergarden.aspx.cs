using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL;
using Kindergarten.BL.Utils;
using Kindergarten.Domain.Entities;

namespace KindergartenApp
{
    public partial class AddKindergarden : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindLists();
            ChildrenGrid.DataSource = new List<Child>
                                          {
                                              new Child {FirstName = "טל", LastName = "ברקוביץ", Id = 300253747}
                                          };
            ChildrenGrid.DataBind();
        }

        private void BindLists()
        {
            Cities.DataSource = EnumUtils.GetDescriptions(typeof(Cities));
            Cities.DataBind();

            Teachers.DataSource = new List<Teacher>();
            Teachers.DataBind();
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            var contant = ImageLoader.FileContent;
            var bmp = new Bitmap(contant);

            Cities city;
            Kindergarten.Domain.Entities.Cities.TryParse(Cities.SelectedValue, true, out city);

            var current = new Kindergarden
                              {
                                  Name = Name.Text,
                                  City = city,
                                  ChildQty = int.Parse(ChildrenNum.Text),

                              };
        }
    }
}