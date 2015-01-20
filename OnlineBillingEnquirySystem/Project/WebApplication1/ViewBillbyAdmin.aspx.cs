///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the events regarding the ViewBillbyAdmin.aspx page>
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
    public partial class WebForm1 : System.Web.UI.Page
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

                        vanish.Visible = false;
                        IBill bill = null;
                        try
                        {
                            Int64 billId = Convert.ToInt64(Session["editUser"].ToString());
                            IBillManager billManagerObj = BillManagerFactory.CreateBillManager();
                            IBill billobj = BillFactory.CreateBill(billId);
                            bill = billManagerObj.ViewBill(billobj);
                            Session["connection"] = bill.ConnectionId;
                            Session["month"] = bill.Month;
                            Session["year"] = bill.Year;
                            billid.Text = (bill.BillId).ToString();
                            customerid.Text = (bill.CustomerId).ToString();
                            connectionid.Text = (bill.ConnectionId).ToString();
                            generatedate.Text = (bill.GenerateDate).ToShortDateString().ToString();
                            amount.Text = (bill.Amount).ToString() + "  INR";
                            yearr.Text = (bill.Year).ToString();
                            monthh.Text = (bill.Month).ToString();
                            arrears.Text = (bill.Arrears).ToString() + "  INR";
                            advancepayment.Text = (bill.AdvancedPayment).ToString() + "  INR";
                            discount.Text = (bill.Discount).ToString() + "  INR";
                            totalamount.Text = (bill.Total).ToString() + "  INR";
                        }
                        catch (Exception ex)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
                        }
                        vanish.Visible = true;
                    }
                    else 
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);
                   
                    }
            }}
        }

        protected void BtnDetail_Click(object sender, EventArgs e)
        {
            string day = "1";
            string year = Session["year"].ToString();
            string month = Session["month"].ToString();
            DateTime date = DateTime.Parse(month + "/" + day + "/" + year);
            Session["date"] = date;
            Response.Redirect("ViewBillItembyAdmin.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            if (Session["Add"] == "true")
            {
                Response.Redirect("AddBill.aspx");
            }
            else
            {
                Response.Redirect("ViewAllandSearchBill.aspx");
            }
        }
    }
}