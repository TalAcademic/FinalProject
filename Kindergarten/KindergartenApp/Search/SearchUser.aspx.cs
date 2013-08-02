using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Query;

namespace KindergartenApp.Search
{
    public partial class SearchUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchClick(object sender, EventArgs e)
        {
            GetByFilter();
        }

        private void GetByFilter()
        {
            var query = new PersonQuery
                            {
                                FirstName = FirstNameFilter.Text,
                                LastName = LastNameFilter.Text,
                                IdNum = IdFilter.Text,
                                BirthDate = BirthDate.Text != "" ? DateTime.Parse(BirthDate.Text) : (DateTime?) null
                            };
            EntitiesGrid.DataSource = query.GetByFilter();
            EntitiesGrid.DataBind();
        }

        protected void DeleteUser(object source, DataGridCommandEventArgs e)
        {
            var id = EntitiesGrid.DataKeys[e.Item.ItemIndex];
            PersonEdit.Instance.Delete((int)id);

            GetByFilter();
        }

        protected void EditUser(object source, DataGridCommandEventArgs e)
        {
            var id = EntitiesGrid.DataKeys[e.Item.ItemIndex];
            var url = ResolveUrl("../User/AddUser.aspx?code=" + id);

            Response.Redirect(url);
        }
    }
}