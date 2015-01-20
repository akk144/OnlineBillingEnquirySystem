using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEP.TYPES;
using BEP.BLL;
using BEP.BLL_FACTORY;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.DAL;
using BEP.DAL_FACTORY;
namespace WebApplication1
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // try
                if (Session["userid"] == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                }
                else
                {
                    if (Session["userid"].Equals("admin"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr61", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr62", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                    }
                    else
                    {
                        IPaymentManager paymentmanager = PaymentManagerFactory.CreatePaymentManager();
                        string id = Session["userid"].ToString();
                        string name = paymentmanager.GetName(id);
                        Label1.Text = "Welcome     " + name;
                       
                        Label1.Visible = true;
                        Label3.Text = (DateTime.Now).ToString();
                    }

                }
            }
        }
    }
}