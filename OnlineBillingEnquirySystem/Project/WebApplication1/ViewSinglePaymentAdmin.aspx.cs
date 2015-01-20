///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <View Payment Details of Perticular Customer and Connection number operations by calling the Manager's Functions>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Subnum,Snehal>, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :N/A
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
using BEP.BLL;
using BEP.BLL_FACTORY;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.DAL;
using BEP.DAL_FACTORY;
namespace WebApplication1
{
    public partial class ViewSinglePaymentAdminaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                            string id = Session["singleUser"].ToString();
                            double num = Convert.ToDouble(Session["connectionno"]);
                            IPaymentManager paymanager = PaymentManagerFactory.CreatePaymentManager();
                            List<IPayment> payment = paymanager.ViewSinglePayment(id, num);
                            foreach (IPayment pay in payment)
                            {
                                Paymentid.Text = pay.Payment_Id.ToString();
                                CustomerId.Text = pay.Customer_Id.ToString();
                                CustomerName.Text = pay.Customer_Name;
                                ConnectionNumber.Text = pay.Connection_Id.ToString();
                                BillId.Text = pay.Bill_Id.ToString();
                                BillAmount.Text = pay.Bill_Amount.ToString() + "  INR";
                                AmountPaid.Text = pay.Payable_Amount.ToString() + "  INR";
                                AdvanceAmount.Text = pay.Advance_Amount.ToString() + "  INR";
                                Arrears.Text = "0" + "  INR";
                                ModeOfPayment.Text = pay.Mode_Of_Payment;
                                PaymentDate.Text = pay.Date.ToShortDateString();
                                BankName.Text = pay.Bank_Name;
                                CardType.Text = pay.Card_Type;

                            }
                        }


                        catch (Exception ex)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr61", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr62", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                    }

                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllandSearchPayment.aspx");
        }
    }
}