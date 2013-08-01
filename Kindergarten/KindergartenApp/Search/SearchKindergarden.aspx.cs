using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Query;
using Kindergarten.BL.Utils;
using Entities = Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp.Search
{
    public partial class SearchKindergarden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindData();
            }
        
        }

        private void BindData()
        {
            TeachersFilter.DataSource = new TeachersQuery().Get();
            TeachersFilter.DataBind();
            TeachersFilter.Items.Insert(0,new ListItem("בחר גננת לחיפוש", "999"));


            var cities = EnumUtils.GetDescriptions(typeof (Entities.Cities)).ToList();
            cities.Insert(0,new KeyValuePair<int, string>(-1, "בחר עיר לחיפוש.."));
            CitiesFilter.DataSource = cities;
            CitiesFilter.DataBind();
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            GetByFilter();
        }

        private void GetByFilter()
        {
            var query = new KindergardenQuery
                            {
                                Name = GardenNameFilter.Text,
                                TeacherId =
                                    TeachersFilter.SelectedValue != "999"
                                        ? int.Parse(TeachersFilter.SelectedValue)
                                        : default(int?)
                            };

            if (CitiesFilter.SelectedValue != "-1")
            {
                var city = Enum.Parse(typeof (Entities.Cities), CitiesFilter.SelectedValue, true);
                query.City = (Entities.Cities?) city;
            }

            EntitiesGrid.DataSource = query.GetByFilter().ToList();
            EntitiesGrid.DataBind();
        }

        protected void GridCommand(object source, DataGridCommandEventArgs e)
        {
            if(e.CommandName == "Delete")
            {
                KindergardenEdit.Instance.Delete((int.Parse(e.Item.Cells[0].Text)));
                GetByFilter();
            }

            if(e.CommandName == "Edit")
            {
                var id = int.Parse(e.Item.Cells[0].Text);
                var url = ResolveUrl("../Kindergarden/AddKindergarden.aspx?code=" + id);

                Response.Redirect(url);
            }
        }
    }
}