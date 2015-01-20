///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the events regarding the ViewOneBillItem.aspx page>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Saikat,Akansh> Tata Consultancy Services
// ---------------------------------------------------------------------------------
//  Change History :N/A
// Change Description# : N/A
// Changed By  : N/A
// Date Modified  : N/A
// Change Description# : N/A
// Changed By  : N/A
// Date Modified  : N/A
//
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEP.BLL;
using BEP.BLL_FACTORY;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.TYPES;
namespace WebApplication1
{
    public partial class ViewOneBillItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                }
                else
                {
                    if (Session["userid"].Equals("admin"))
                    {
                        try
                        {
                            IBillItemManager billItemManagerObj = BillItemManagerFactory.CreateBillItemManager();
                            Int64 itemId = Convert.ToInt64(Session["itemid"].ToString());
                            IBillItem billItem = BillItemFactory.CreateBillItem(itemId);
                            IBillItem billItemObj = billItemManagerObj.ViewBillItem(billItem);
                            billitemid.Text = (billItemObj.BillItemId).ToString();
                            connectionnumber.Text = (billItemObj.ConnectionId).ToString();
                            dateofcall.Text = (billItemObj.DateOfCall).ToString();
                            duration.Text = (billItemObj.Duration).ToString();
                            numbercalled.Text = (billItemObj.NumberCalled).ToString();
                            type.Text = (billItemObj.CallType).ToString();
                            pulse.Text = (billItemObj.PulseRate).ToString();
                            cost.Text = (billItemObj.CallCost).ToString() + "  INR";
                        }
                        catch (Exception ex)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);
                    }
                }
            }
            
        }
    }
}