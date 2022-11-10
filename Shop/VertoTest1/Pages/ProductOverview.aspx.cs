using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VertoTest1;
using VertoTest1.App_Data;

namespace Shop
{
    public partial class ProductOverview : System.Web.UI.Page
    {
        ShopDataContext db = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            var fetch = from p in db.Products
                        select p;
            GridView.DataSource = fetch;
            GridView.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var search = from p in db.Products
                         where p.Name.Contains(txtSearch.Text)
                         select p;
            GridView.DataSource = search;
            GridView.DataBind();
            txtSearch.Text = "";

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Product products = new Product()
            {
                Name = txtName.Text,
                Price = txtPrice.Text
            };
            db.Products.InsertOnSubmit(products);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
      
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            if (btnEdit.Text == "Edit")
            {
                btnEdit.Text = "Update";
                trowId.Visible = true;

            }
            else if (btnEdit.Text == "Update")
            {

                if (txtId.Text != string.Empty)
                {
                    var FindProduct = from p in db.Products
                                      where p.Id == Convert.ToInt64(txtId.Text)
                                      select p;

                    foreach (Product pro in FindProduct)
                    {
                        pro.Name = txtName.Text;
                        pro.Price = txtPrice.Text;
                    }
                    db.SubmitChanges();
                    // lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please enter the product Id";
                }
                trowId.Visible = false;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                btnEdit.Text = "Edit";
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int x = 0;
            bool intValueChecker = int.TryParse(txtId.Text, out x);
            if (btnDelete.Text == "Delete")
            {
                btnDelete.Text = "Remove";
                trowId.Visible = true;
                trowName.Visible = false;
                trowPrice.Visible = false;

            }
            else if (btnDelete.Text == "Remove")
            {
                btnDelete.Text = "Delete";
                if (txtId.Text != String.Empty && intValueChecker == true)
                {
                    var FindProduct = from p in db.Products
                                      where p.Id == Convert.ToInt64(txtId.Text)
                                      select p;
                    foreach (Product pro in FindProduct)
                    {
                        db.Products.DeleteOnSubmit(pro);
                    }

                    db.SubmitChanges();
                    lblMessage.Visible = false;
                }

                else
                {

                    lblMessage.Visible = true;
                    lblMessage.Text = "Please enter a valid product Id (e.g 1,2,10)";
                }
                trowId.Visible = false;
                trowName.Visible = true;
                trowPrice.Visible = true;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           /* txtId.Text= String.Empty;
            trowId.Visible = false;
            txtName.Text= String.Empty;
            txtPrice.Text= String.Empty;
            btnEdit.Text = "Edit";*/
        }


        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView.PageIndex = e.NewPageIndex;
            GridView.DataBind();
        }

       
    }
}