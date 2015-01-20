///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the events regarding the UpdateBill.aspx page>
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
using BEP.TYPES;
using BEP.BLL_FACTORY;
using BEP.BO_FACTORY;
using BEP.DAL_FACTORY;
using BEP.BLL;
using BEP.DAL;
using BEP.BO;

namespace WebApplication1
{
    public partial class UpdateBill : System.Web.UI.Page
    {
       private  static IBill staticbill;
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
                        fill();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                    }
                }
            }
        }
        protected void fill()
        {
            try
            {
                IBillManager billManagerObj = BillManagerFactory.CreateBillManager();
                List<IBill> billList = billManagerObj.CheckForUpdate();
                UpdateGrid.DataSource = billList;
                UpdateGrid.DataBind();
                UpdateGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = UpdateGrid.HeaderRow.Cells;
                cells[0].Attributes.Add("data-class", "expand");
                cells[1].Attributes.Add("data-hide", "phone,tablet,screen");
                cells[2].Attributes.Add("data-hide", "phone,tablet,screen");
                cells[3].Attributes.Add("data-hide", "phone,tablet,screen");
                cells[4].Attributes.Add("data-hide", "phone,tablet,screen");
                cells[5].Attributes.Add("data-hide", "phone,tablet,screen");
                cells[6].Attributes.Add("data-hide", "phone,tablet,screen");
                cells[7].Attributes.Add("data-hide", "phone,tablet");
                cells[8].Attributes.Add("data-hide", "phone,tablet");
                cells[9].Attributes.Add("data-hide", "phone,tablet");
                cells[10].Attributes.Add("data-hide", "phone,tablet");
                cells[11].Attributes.Add("data-hide", "phone");
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            }
        }

        protected void UpdateGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = UpdateGrid.SelectedRow;
            Int64 id = Convert.ToInt64(row.Cells[0].Text);
            try
            {
                staticbill = BillFactory.CreateBill(id);
                IBillManager billManagerObj = BillManagerFactory.CreateBillManager();
                IBill ibill = billManagerObj.ViewUpdateBill(staticbill);
                double returnNewBill = billManagerObj.GetAmount(ibill);
                IBill oldBill = BillFactory.CreateBill(id);
                IBill returnOldBill = billManagerObj.ViewUpdateBill(oldBill);
                returnOldBill.AdvancedPayment = returnOldBill.AdvancedPayment + (returnOldBill.Amount - returnNewBill);
                returnOldBill.Amount = returnNewBill;
                int result = billManagerObj.UpdateBill(returnOldBill);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Your Data is Updated'); </script>", false);
                    fill();
                    row.Enabled = false;
                   
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            }
        }

        protected void UpdateGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UpdateGrid.PageIndex = e.NewPageIndex;
            fill();
        }
        //protected void BtnUpdatedView_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        IBillManager billManagerObj = BillManagerFactory.CreateBillManager();
        //        IBill showbill = billManagerObj.ViewBill(staticbill);
        //        List<IBill> billList = new List<IBill>();
        //        billList.Add(showbill);
        //        UpdatedGrid.DataSource = billList;
        //        UpdatedGrid.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
        //    }
        //}
    }
}