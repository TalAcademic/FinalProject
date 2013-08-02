using System;
using System.Web.UI;
using Kindergarten.BL.Query;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;
using System.Linq;

namespace KindergartenApp.User
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DoLoginClick(object sender, EventArgs e)
        {
            var user = new PersonQuery { IdNum = UserName.Text }.GetByIdNum();

            if (!user.Any())
            {
                UserValidator.IsValid = false;
                return;
            }

            var currUser = user.Single();
            if (currUser.Password != Password.Text)
            {
                PasswordValidator.IsValid = false;
            }
            else
            {
                Session["CurrentUser"] = currUser;
                Page.Response.Redirect("~/Main.aspx");
            }
        
        }
    }
}