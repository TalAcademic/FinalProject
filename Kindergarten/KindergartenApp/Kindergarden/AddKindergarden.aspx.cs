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
            get { return (Entities.Kindergarden) ViewState["CurrentKindergarden"]; }
            set { ViewState["CurrentKindergarden"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindLists();
                var kindergardenCode = Request.QueryString["code"];
                if (kindergardenCode != null)
                {
                    var current = new KindergardenQuery().Get(int.Parse(kindergardenCode));
                    CurrentKindergarden = current;
                    FillFields(current);

                    InitByUser();
                }

            }
        }

        private void InitByUser()
        {
            var displayKinderGarden = CurrentKindergarden;
            var currentUser = Session["CurrentUser"];

            if (currentUser is Entities.Child)
            {
                EnableFields((currentUser as Entities.Child).Kindergarden.Equals(displayKinderGarden));
            }
            else if (currentUser is Entities.Teacher)
            {
                var kinder = new KindergardenQuery {TeacherId = (currentUser as Entities.Teacher).Id}.GetByFilter().SingleOrDefault();

                var canEdit = kinder != null && (kinder.Equals(displayKinderGarden));

                EnableFields(canEdit);
            }
            else if (currentUser is Entities.Supervisor)
            {
                var canEdit = (currentUser as Entities.Supervisor).City.Equals(displayKinderGarden.City);
                EnableFields(canEdit);
            }

        }

        private void EnableFields(bool canEdit)
        {
            Name.Enabled = canEdit;
            Cities.Enabled = canEdit;
            ChildrenNum.Enabled = canEdit;
            Teachers.Enabled = canEdit;
            ChildrenGrid.Enabled = canEdit;
            ChildrenList.Enabled = canEdit;

            AddChild.Visible = canEdit;
            SaveGarden.Visible = canEdit;
        }

        private void FillFields(Entities.Kindergarden current)
        {
            Name.Text = current.Name;

            Cities.SelectedValue =
                EnumUtils.GetDescriptionOfEnumValue(typeof (Entities.Cities),
                                                    Enum.GetName(typeof (Entities.Cities), current.City));
            ChildrenNum.Text = current.ChildQty.ToString();
            Teachers.SelectedValue = current.Teacher != null ? current.Teacher.Id.ToString() : "";

            ChildrenGrid.DataSource = current.Children;
            ChildrenGrid.DataBind();
        }

        private void BindLists()
        {
            Cities.DataSource = EnumUtils.GetDescriptions(typeof (Entities.Cities));
            Cities.DataBind();

            Teachers.DataSource = new TeachersQuery().Get();
            Teachers.DataBind();

            ChildrenList.DataSource = new ChildQuery().Get();
            ChildrenList.DataBind();
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (CurrentKindergarden == null)
                {
                    Save();
                }
                else
                {
                    Update();
                }
                ClientScript.RegisterStartupScript(GetType(), "msg",
                                                   "<script language='javascript'>showMessage()</script>");
            }
        }

        private void Update()
        {
            var city = Enum.Parse(typeof (Entities.Cities), Cities.SelectedIndex.ToString(), true);

            var entity = CurrentKindergarden;
            entity.Name = Name.Text;
            entity.City = (Entities.Cities) city;
            entity.ChildQty = int.Parse(ChildrenNum.Text);
            entity.Teacher =
                Teachers.SelectedValue != ""
                    ? new TeachersQuery().Get(int.Parse(Teachers.SelectedValue))
                    : null;

            KindergardenEdit.Instance.Update(entity);

        }

        private void Save()
        {
            var city = Enum.Parse(typeof (Entities.Cities), Cities.SelectedIndex.ToString(), true);

            var current = new Entities.Kindergarden
                              {
                                  Name = Name.Text,
                                  City = (Entities.Cities) city,
                                  ChildQty = int.Parse(ChildrenNum.Text),
                                  Teacher =
                                      Teachers.SelectedValue != ""
                                          ? new TeachersQuery().Get(int.Parse(Teachers.SelectedValue))
                                          : null
                              };

            KindergardenEdit.Instance.Add(current);
            CurrentKindergarden = current;

            ClearData();
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

        protected void DeleteChild(object source, DataGridCommandEventArgs e)
        {
            var id = ChildrenGrid.DataKeys[e.Item.ItemIndex];
            KindergardenEdit.Instance.RemoveChild(CurrentKindergarden, (int) id);

            ChildrenGrid.DataSource = CurrentKindergarden.Children;
            ChildrenGrid.DataBind();
        }

        protected void EditChild(object source, DataGridCommandEventArgs e)
        {
            var id = ChildrenGrid.DataKeys[e.Item.ItemIndex];
            var url = ResolveUrl("../User/AddUser.aspx?code=" + id);

            Response.Redirect(url);
        }
    }
}