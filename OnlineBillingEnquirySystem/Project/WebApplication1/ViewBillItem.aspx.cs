///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the events regarding the ViewBillItembyAdmin.aspx page>
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
    public partial class ViewBillItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr17", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr18", "<script type='text/javascript'>window.location.href='Loginres.aspx';</script>", false);

                }
                else
                {
                    if (Session["userid"].Equals("admin"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr17", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr18", "<script type='text/javascript'>window.location.href='Loginres.aspx';</script>", false);

                    }
                    else
                    {
                        try
                        {
                            bind();
                        }
                        catch (Exception ex)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
                        }
                    }
                }
            }
        }

        protected void BillItemGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BillItemGrid.PageIndex = e.NewPageIndex;
            bind();
        }
        public void bind()
        {
            IBillItemManager billItemManagerObj = BillItemManagerFactory.CreateBillItemManager();
            Int64 connection = Convert.ToInt64(Session["connection"].ToString());
            DateTime date = Convert.ToDateTime(Session["date"].ToString());
            IBillItem billItem = BillItemFactory.CreateBillItem(connection, date);
            List<IBillItem> billItemList = billItemManagerObj.ViewAllBillItemByConnection(billItem);
            BillItemGrid.DataSource = billItemList;
            BillItemGrid.DataBind();
            BillItemGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            TableCellCollection cells = BillItemGrid.HeaderRow.Cells;
            cells[0].Attributes.Add("data-class", "expand");
            cells[1].Attributes.Add("data-hide", "phone,tablet,screen");
            cells[2].Attributes.Add("data-hide", "phone,tablet,screen");
            cells[3].Attributes.Add("data-hide", "phone,tablet,screen");
            cells[4].Attributes.Add("data-hide", "phone,tablet,screen");
            cells[5].Attributes.Add("data-hide", "phone,tablet");
            cells[6].Attributes.Add("data-hide", "phone,tablet");
            cells[7].Attributes.Add("data-hide", "phone");
        }

        protected void Back_Click(object sender, EventArgs e)
        {

            Response.Redirect("ViewBill.aspx");
        }
    }
}