using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Query;
using Kindergarten.BL.Utils;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.Kindergarden
{
    public partial class AddActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Gardens.DataSource = KindergardenQuery.Instance.Get();
                Gardens.DataBind();

                Types.DataSource = EnumUtils.GetDescriptions(typeof(ActivityTypes));
                Types.DataBind();
            }
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            var type = Enum.Parse(typeof(ActivityTypes), Types.SelectedIndex.ToString(), true);
            var entity = new Activity
                             {
                                 Name = Name.Text,
                                 Info = Info.Text,
                                 Date = Date.SelectedDate,
                                 Kindergarden = KindergardenQuery.Instance.Get(int.Parse(Gardens.SelectedValue)),
                                 Type = (ActivityTypes)type
                             };
            ActivityEdit.Instance.Add(entity);

            ClientScript.RegisterStartupScript(GetType(), "msg", "<script language='javascript'>showMessage()</script>");
        }
    }
}