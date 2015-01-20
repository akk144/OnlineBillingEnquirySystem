///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the events regarding the ViewAllandSearchBill.aspx page>
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
    public partial class ViewAllandSearchBill : System.Web.UI.Page
    {
        static List<IBill> billList = null;
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
                            bind();
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
        protected void BillsGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = BillsGrid.SelectedRow;
            string id = row.Cells[0].Text;
            Session["editUser"] = id;
            Response.Redirect("ViewBillbyAdmin.aspx");
        }
        protected void BtnSearchItem_Click(object sender, EventArgs e)
        {
            if (TxtBillId.Text.ToString() == "")
            {
                int flag = 0;
                try
                {
                    IBillItemManager item = BillItemManagerFactory.CreateBillItemManager();
                    IBillItem billitem = BillItemFactory.CreateBillItem(Convert.ToInt64(TxtBillItemId.Text));
                    int result = item.CheckBillItem(billitem);
                }
                catch (Exception ex)
                {
                    flag = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('The Bill Item does not exist'); </script>", false);
                    TxtBillItemId.Text = "";
                    TxtBillItemId.Focus();
                }
                if (flag == 0)
                {
                    Session["itemid"] = (TxtBillItemId.Text).ToString();
                    Response.Redirect("ViewOneBillItem.aspx");
                }
            }
            else if (TxtBillItemId.Text.ToString() == "")
            {
                int flag = 0;
                foreach (IBill bill in billList)
                {
                    if (TxtBillId.Text == (bill.BillId).ToString())
                    {
                        Session["editUser"] = (TxtBillId.Text).ToString();
                        flag = 1;
                        Response.Redirect("ViewBillbyAdmin.aspx");
                    }
                }
                if (flag == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Bill does not exist'); </script>", false);
                    TxtBillId.Text = "";
                    TxtBillId.Focus();
                }            
            }
            else if (TxtBillItemId.Text.ToString() != "" && TxtBillId.Text.ToString() != "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Please enter only one search parameter'); </script>", false);
                TxtBillId.Text = "";
                TxtBillItemId.Text = "";
                TxtBillId.Focus();
            }
            
        }

        protected void BillsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BillsGrid.PageIndex = e.NewPageIndex;
            bind();

        }
        public void bind()
        {
            IBillManager billManagerObj = BillManagerFactory.CreateBillManager();
            billList = billManagerObj.ViewAllBill();
            BillsGrid.DataSource = billList;
            BillsGrid.DataBind();
            BillsGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            TableCellCollection cells = BillsGrid.HeaderRow.Cells;
            cells[0].Attributes.Add("data-class", "expand");
            cells[1].Attributes.Add("data-hide", "phone,tablet");
            cells[2].Attributes.Add("data-hide", "phone,tablet");
            cells[3].Attributes.Add("data-hide", "phone,tablet");
            cells[4].Attributes.Add("data-hide", "phone,tablet");
            cells[5].Attributes.Add("data-hide", "phone,tablet");
            cells[6].Attributes.Add("data-hide", "phone,tablet");
            cells[7].Attributes.Add("data-hide", "phone");
            cells[8].Attributes.Add("data-hide", "phone");
            cells[9].Attributes.Add("data-hide", "phone");
            cells[10].Attributes.Add("data-hide", "phone");
            cells[11].Attributes.Add("data-hide", "phone");
         
        }
    }
}