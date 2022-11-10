using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VertoTest1.Pages
{
    public partial class AdminLogIn : System.Web.UI.Page
    {
        ShopDataContext db = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                var fetch = from ad in db.AdminLogIns
                            where ad.Id == txtAdminId.Text && ad.Password == txtPassword.Text
                            select ad;
                foreach (var ad in fetch)
                {
                    if (ad != null)
                    {

                        Session["userName"] = ad.Name;
                        Session["role"] = "Admin";
                        Response.Write("<script>alert('" + ad.Name + "');</script>");
                        Response.Redirect("ProductOverview.aspx");
                    }
                    else
                    {
                        Response.Redirect("AdminLogIn.aspx");

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}