using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.Domain.Entities;

namespace KindergartenApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var isUserLogIn = Session["CurrentUser"] != null;

            if(!isUserLogIn)
            {
                menu.Visible = false;
            }
            else
            {
                menu.Visible = true;

                ShowMenuByUserType();
            }
        }

        private void ShowMenuByUserType()
        {
            var user = Session["CurrentUser"];
            if(user is Child)
            {
                KindergardenMenu.Visible = false;
                AddUser.Visible = false;
            }
            else if (user is Teacher)
            {
                KindergardenMenu.Visible = true;
                AddUser.Visible = true;
                AddKindergarden.Visible = true;
                AddActivity.Visible = true;
            }
            else if(user is Supervisor)
            {
                KindergardenMenu.Visible = true;
                AddUser.Visible = true;
                AddKindergarden.Visible = false;
                AddActivity.Visible = false;
            }
        }
    }
}