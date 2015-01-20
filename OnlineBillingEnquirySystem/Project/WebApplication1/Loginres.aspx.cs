using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using BEP.TYPES;
using BEP.DAL;
using BEP.BLL;
using BEP.DAL_FACTORY;
using BEP.BLL_FACTORY;

namespace WebApplication1
{
    public partial class Loginres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["userid"] = null;
                Session["billid"] = null;
                Session["connection"] = null;
                //Label1.Visible = false;

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                string uid = TextBox3.Text;
                string password = TextBox1.Text;
                bool rem = true;
                if (FormsAuthentication.Authenticate(uid, password))
                {
                    Session["userid"] = uid;
                    Session["pass"] = password;
                    FormsAuthentication.RedirectFromLoginPage(uid, rem);

                }
                else
                {
                    ICustomerManager customerManager = CustomerManagerFactory.CreateCustomerManager();
                    bool b = customerManager.LoginCust(uid, password);
                    if (b)
                    {
                        Session["userid"] = uid;
                        Session["pass"] = password;
                        Response.Redirect("CustomerHome.aspx");
                    }
                    else
                    {
                        TextBox1.Text = "";
                        TextBox3.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Invalid login Credentials'); </script>", false);
                        // Label1.Text = "Invalid login Credentials";
                        //Label1.Visible = true;


                    }

                }
            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox1.Text = "";
                TextBox3.Text = ""; 
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            }
        }
    }
}