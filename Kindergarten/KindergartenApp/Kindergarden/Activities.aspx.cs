using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.Domain.Entities;

namespace KindergartenApp.Kindergarden
{
    public partial class Activities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActivitiesGrid.DataSource = new List<Activity>
                                            {
                                                new Activity
                                                    {
                                                        Date = new DateTime(2013, 10, 10),
                                                        Name = "יום הולדת לנועה",
                                                        Info = "יום הולדת 5",
                                                        Type = ActivityTypes.BirthDay,
                                                        Kindergarden = new Kindergarten.Domain.Entities.Kindergarden{Name = "המגדלור"}
                                                    },
                                                    new Activity
                                                    {
                                                        Date = new DateTime(2013, 07, 24),
                                                        Name = "טיול שנתי",
                                                        Info = "טיול להרי הגולן",
                                                        Type = ActivityTypes.Trip,
                                                        Kindergarden = new Kindergarten.Domain.Entities.Kindergarden{Name = "המגדלור"}
                                                    },
                                                     new Activity
                                                    {
                                                        Date = new DateTime(2013, 5, 3),
                                                        Name = "קבלת שבת",
                                                        Info = "אמא של שבת: אפרת, אבא של שבת:מיכאל",
                                                        Type = ActivityTypes.Shaabat,
                                                        Kindergarden = new Kindergarten.Domain.Entities.Kindergarden{Name = "המגדלור"}
                                                    }
                                            };
            ActivitiesGrid.DataBind();
        }
    }
}