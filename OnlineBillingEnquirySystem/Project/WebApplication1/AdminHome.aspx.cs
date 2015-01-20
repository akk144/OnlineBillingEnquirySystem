using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminHome : System.Web.UI.Page
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
                        Label1.Text = "Welcome Admin";
                        Label3.Text = (DateTime.Now).ToString();
                        Label1.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr61", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr62", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                    }
                    
                }

            }
        }
    }
}