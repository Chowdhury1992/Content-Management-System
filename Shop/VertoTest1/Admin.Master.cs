using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]==null)
            {
                Response.Redirect("AdminLogIn.aspx");
            }

            else if (Session["role"].Equals("Admin"))
            {
                lblUserName.Text = Session["userName"].ToString();
            }
           
        }
       
    }
}