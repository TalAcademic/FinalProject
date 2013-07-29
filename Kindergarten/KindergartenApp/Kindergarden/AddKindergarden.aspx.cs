using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Query;
using Kindergarten.BL.Utils;
using Kindergarten.Data;
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
            if(!Page.IsPostBack)
            {
                BindLists();
            }
        }

        private void BindLists()
        {
            Cities.DataSource = EnumUtils.GetDescriptions(typeof(Entities.Cities));
            Cities.DataBind();

            Teachers.DataSource = new TeachersQuery().Get();
            Teachers.DataBind();

            ChildrenList.DataSource = new ChildQuery().Get();
            ChildrenList.DataBind();
        }

        protected void SaveClick(object sender, EventArgs e)
        {

            var city = Enum.Parse(typeof(Entities.Cities), Cities.SelectedIndex.ToString(), true);

            var current = new Entities.Kindergarden
                              {
                                  Name = Name.Text,
                                  City = (Entities.Cities)city,
                                  ChildQty = int.Parse(ChildrenNum.Text),
                                  Teacher = Teachers.SelectedValue != "" ? new TeachersQuery().Get(int.Parse(Teachers.SelectedValue)) : null
                              };

            KindergardenEdit.Instance.Add(current);
            CurrentKindergarden = current;

            ClearData();
            ClientScript.RegisterStartupScript(GetType(), "msg", "<script language='javascript'>showMessage()</script>");

        }

        private void ClearData()
        {
            Name.Text = "";
            Cities.SelectedIndex = 0;
            ChildrenNum.Text = "";
            //Teachers.SelectedIndex = 0;
        }

        protected void AddChildClick(object sender, EventArgs e)
        {
            var child = new ChildQuery().Get(int.Parse(ChildrenList.SelectedValue));
            CurrentKindergarden.Children.Add(child);

           KindergardenEdit.Instance.Update(CurrentKindergarden);

            ChildrenGrid.DataSource = CurrentKindergarden.Children;
            ChildrenGrid.DataBind();

        }
    }
}