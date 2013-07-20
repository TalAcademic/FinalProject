using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Utils;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.Kindergarden
{
    public partial class AddActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Gardens.DataSource = new List<string>
                                     {
                                         "גן המגדלור"
                                     };

            Gardens.DataBind();

            Types.DataSource = EnumUtils.GetDescriptions(typeof(ActivityTypes));
            Types.DataBind();
        }
    }
}