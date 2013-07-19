using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities =  Kindergarten.Domain.Entities;

namespace KindergartenApp.Kindergarden
{
    public partial class OpenDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Gardens.DataSource = new List<string>
                                     {
                                          "גן המגדלור"
                                     };
            Gardens.DataBind();
            ChildrenGrid.DataSource = new List<Entities.Child>
                                          {
                                              new Entities.Child {FirstName = "ישראל", LastName = "ישראלי", Id = 1233},
                                              new Entities.Child {FirstName = "דני", LastName = "דהן", Id = 4444},
                                              new Entities.Child {FirstName = "טל", LastName = "כהן", Id = 656},
                                              new Entities.Child {FirstName = "שני", LastName = "לוי", Id = 1233}
                                          };
            ChildrenGrid.DataBind();
        }
    }
}