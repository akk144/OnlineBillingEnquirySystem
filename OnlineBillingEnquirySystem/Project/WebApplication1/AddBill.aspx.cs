///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the events regarding the AddBill.aspx page>
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
using System.Web.Services;

namespace WebApplication1
{
    public partial class AddBill : System.Web.UI.Page
    {
        public static DropDownList dropList = null;
        public static TextBox textBox = null;
        protected void Page_Load(object sender, EventArgs e)
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
                    LabelSuccess.Visible = false;
                    LabelBillId.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);


                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (System.DateTime.Now.Day < 24)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Bill generation must be done after 23rd of the month'); </script>", false);
            }
            else
            {
                string cusId = TextCustomer.Text;
                Int64 connectionId = Convert.ToInt64(TextBox1.Text);
                DateTime generateDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());

                string month = (generateDate.Month - 1).ToString();
                Int32 year = (generateDate.Year);
                try
                {

                    IBill billObj1 = BillFactory.CreateBill(connectionId, year, month);
                    IBillManager billManagerObj1 = BillManagerFactory.CreateBillManager();
                    int x = billManagerObj1.CheckConnection(billObj1);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Connection number does not exist'); </script>", false);
                    TextBox1.Text = "";
                    TextBox1.Focus();
                    return;
                }
                IPaymentManager payManagerObj1 = PaymentManagerFactory.CreatePaymentManager();
                bool isValid = payManagerObj1.ValidCustomer(cusId);
                if (isValid != true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Customer id is invalid'); </script>", false);
                    TextBox1.Text = "";
                    TextBox1.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        IBill billObj2 = BillFactory.CreateBill(cusId, connectionId, generateDate, year, month);
                        IBillManager billmanagerobj = BillManagerFactory.CreateBillManager();
                        Int64 billId = billmanagerobj.GenerateBill(billObj2);
                        LabelBillId.Text = billId.ToString();
                        LabelSuccess.Visible = true;
                        LabelBillId.Visible = true;
                        Session["editUser"] = billId;
                        Session["Add"] = "true";
                        Response.Redirect("ViewBillbyAdmin.aspx");
                    }
                    catch (Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
                    }
                }
            }
        }
    }
      
    }
