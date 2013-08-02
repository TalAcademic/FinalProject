using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Query;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {


                var userId = ((Person)Session["CurrentUser"]).Id;
                var user = new PersonQuery().Get(userId);

                user.Password = NewPassword.Text;
                PersonEdit.Instance.Update(user);

                NewPassword.Text = "";
                ClientScript.RegisterStartupScript(GetType(), "msg", "<script language='javascript'>showMessage()</script>");
            }
        }
    }
}