using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kindergarten.BL;
using Kindergarten.BL.Utils;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace KindergartenApp.Reports
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entities.DataSource = new List<string>
                                      {
                                          "גן",
                                          "משתמש"
                                      };
            Entities.DataBind();

            var cities = EnumUtils.GetDescriptions(typeof(Kindergarten.Domain.Entities.Cities));
            cities.Add(0, "בחר עיר לחיפוש..");
            CitiesFilter.DataSource = cities;
            CitiesFilter.DataBind();

            //TeachersFilter.DataSource = SessionFactoryHelper.CurrentSession.Query<Kindergarten.Domain.Entities.Teacher>();
            TeachersFilter.DataSource = new List<string>
                                            {
                                                "בחר גננת לחיפוש.."
                                            };
            TeachersFilter.DataBind();

            //EntitiesGrid.DataSource = new List<Kindergarten.Domain.Entities.Kindergarden>
            //                              {
            //                                  new Kindergarten.Domain.Entities.Kindergarden
            //                                      {
            //                                          Id=44,
            //                                          Name = "גן המגדלור",
            //                                          ChildQty = 30,
            //                                          Teacher = new Teacher{FirstName = "שרה",LastName = "ישראלי"},
            //                                          City = Cities.Rishon
            //                                      }
            //                              };

            EntitiesGrid.DataSource = new List<Child>
                                          {
                                              new Child
                                                  {
                                                         Id = 2345,
                                             FirstName = "אור",
                                             LastName = "שבת"
                                                  },
                                                    new Child
                                                  {
                                                         Id = 7835,
                                             FirstName = "הילה",
                                             LastName = "גולן"
                                                  },
                                           
                                          };
            EntitiesGrid.DataBind();
        }
    }
}