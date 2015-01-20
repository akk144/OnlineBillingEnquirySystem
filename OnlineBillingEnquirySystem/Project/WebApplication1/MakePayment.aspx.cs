///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Payment related operations by calling the Manager's Functions and implementing logic as required>
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


//using ASPSnippets.SmsAPI;
using System;
//using System.Data;
//using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BEP.TYPES;
using BEP.BLL;
using BEP.BLL_FACTORY;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.DAL;
using BEP.DAL_FACTORY;


namespace WebApplication1
{
    public partial class MakePayment : System.Web.UI.Page
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
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr17", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr18", "<script type='text/javascript'>window.location.href='Loginres.aspx';</script>", false);

                    }
                    else
                    {


                        custid.Text = Session["userid"].ToString();
                        custid.Enabled = false;
                        fillDropdown();
                        DropDownList1.Items.Insert(0, new ListItem("Please select number", "0"));
                        DropDownList1.SelectedIndex = 0;
                        billamt.Enabled = false;
                        Lblinr.Visible = false;
                        Lblinr1.Visible = false;
                        billamt.Visible = false;
                        payamt.Visible = false;
                        RadioButtonList1.Visible = false;
                        Lblbillamt.Visible = false;
                        Lblpayamt.Visible = false;
                        Lblpaymode.Visible = false;
                        DropDownList2.Visible = false;
                        RadioButtonList2.Visible = false;
                        namecard.Visible = false;
                        cardnum.Visible = false;
                        expdate.Visible = false;
                        cvvnum.Visible = false;
                        Lblbnkname.Visible = false;
                        Lblcardtype.Visible = false;
                        Lblnamecard.Visible = false;
                        Lblcardnum.Visible = false;
                        Lblexpdate.Visible = false;
                        Lblcvvnum.Visible = false;

                    }
                }
               
            }

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <fillDropdown>
        // Summary  : <To view connection number by id>
        // Input Parameters : <customer id>
        // Output Parameters :<List of connection numbers of perticular customer>
        // Return Value  : <Return List of connection number>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void fillDropdown()
        {
           
                string customerid = Session["userid"].ToString();
                IPaymentManager paymentmanager = PaymentManagerFactory.CreatePaymentManager();
                List<double> list = paymentmanager.GetConnectionNo(customerid);
               
                if(list.Count!=0)
                {
                DropDownList1.DataSource = list;
                DropDownList1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr7", "<script type='text/javascript'>alert('Connection number is not activated yet');</script>", false);
                  
                }
          
        
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <Button1_Click>
        // Summary  : <To make payment by perticular customer id and connection number>
        // Input Parameters : <payment details/payment object>
        // Output Parameters :<True/False>
        // Return Value  : <Return alert message>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string customerid = custid.Text;
            double connectionno = Convert.ToDouble(DropDownList1.SelectedValue);
            double billamount;
            if (billamt.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr2", "<script type='text/javascript'>alert('Please enter bill amount'); </script>", false);
        
            }
            else
            {
                billamount = Convert.ToDouble(billamt.Text);
            }
            double payamount = Convert.ToDouble(payamt.Text);
            string paymentmode = RadioButtonList1.SelectedValue;
            string bankname = DropDownList2.SelectedValue;
           
            string cardtype = "";
            string nameoncard = "";
            double cardnumber = 0;
            DateTime expirydate = DateTime.Parse("01/01/2001");
            double cvvnumber = 0;
            if (paymentmode.Equals("Credit Card") || paymentmode.Equals("Debit Card"))
            {
                bankname = DropDownList2.SelectedValue;
                cardtype = RadioButtonList2.SelectedValue;
                nameoncard = namecard.Text;
                cardnumber = Convert.ToDouble(cardnum.Text);
                string[] exp = expdate.Text.Split('/');
                string expdate1 = exp[0] + "/" + 01 + "/" + exp[1];
                expirydate = DateTime.Parse(expdate1);
                cvvnumber = Convert.ToInt32(cvvnum.Text);
            }
            //check for already payment
            IPaymentManager paymentmanager = PaymentManagerFactory.CreatePaymentManager();
            bool checkpayment=paymentmanager.CheckPayment(customerid,connectionno);

            if (checkpayment)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr2", "<script type='text/javascript'>alert('The payment is already done for'" + connectionno + "  Connection number'); </script>", false);
                //return to make payment    
                custid.Text = Session["userid"].ToString();
                custid.Enabled = false;
                billamt.Text = "";
                billamt.Enabled = false;
                fillDropdown();
                DropDownList1.Items.Insert(0, new ListItem("Please select number", "0"));
                DropDownList1.SelectedIndex = 0;
                DropDownList2.Visible = false;
                Lblinr.Visible = false;
                Lblinr1.Visible = false;
                Lblbillamt.Visible = false;
                Lblpayamt.Visible = false;
                Lblpaymode.Visible = false;
                billamt.Visible = false;
                payamt.Visible = false;
                RadioButtonList1.Visible = false;
                RadioButtonList2.Visible = false;
                namecard.Visible = false;
                cardnum.Visible = false;
                expdate.Visible = false;
                cvvnum.Visible = false;
                Lblbnkname.Visible = false;
                Lblcardtype.Visible = false;
                Lblnamecard.Visible = false;
                Lblcardnum.Visible = false;
                Lblexpdate.Visible = false;
                Lblcvvnum.Visible = false;
                RequiredFieldValidator6.Visible = false;

            }
            else
            {

                //extract billid and amount
                IBill bill = BillFactory.CreateBill();
                bill = paymentmanager.ValidBillDetails(customerid, connectionno);

                //make payment
                DateTime today = System.DateTime.Now;
                IPayment objPayment = new Payment();
                objPayment.Customer_Id = customerid;
                objPayment.Connection_Id = connectionno;
                objPayment.Bill_Id = Convert.ToDouble(bill.BillId);
                objPayment.Payable_Amount = payamount;
                objPayment.Date = today;
                objPayment.Mode_Of_Payment = paymentmode;
                objPayment.Bank_Name = bankname;
                objPayment.Card_Number = cardnumber;
                objPayment.Name_On_Card = nameoncard;
                objPayment.Card_Type = cardtype;
                objPayment.Expire_Date = expirydate;
                objPayment.Cvv_Number = cvvnumber;

                IPaymentDB pay = PaymentDBFactory.CreatePaymentDB();
                bool paymentmake = pay.MakePayment(objPayment);
                
                if (paymentmake)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr4", "<script type='text/javascript'>alert('Thank you. The payment is done for " + connectionno + "  Connection number'); </script>", false);
                   
                    //return to make payment    
                    custid.Text = Session["userid"].ToString();
                    custid.Enabled = false;
                   
                    fillDropdown();
                    DropDownList1.Items.Insert(0, new ListItem("Please select number", "0"));
                    DropDownList1.SelectedIndex = 0;
                    billamt.Text = "";
                    billamt.Enabled = false;
                    billamt.Text = "";
                    payamt.Text = "";
                    Lblbillamt.Visible = false;
                    Lblpayamt.Visible = false;
                    Lblpaymode.Visible = false;
                    Lblinr.Visible = false;
                    Lblinr1.Visible = false;
                    billamt.Visible = false;
                    payamt.Visible = false;
                    RadioButtonList1.Visible = false;
                    RadioButtonList1.SelectedValue = null;
                    DropDownList2.Visible = false;
                    RadioButtonList2.Visible = false;
                    namecard.Visible = false;
                    cardnum.Visible = false;
                    expdate.Visible = false;
                    cvvnum.Visible = false;
                    Lblbnkname.Visible = false;
                    Lblcardtype.Visible = false;
                    Lblnamecard.Visible = false;
                    Lblcardnum.Visible = false;
                    Lblexpdate.Visible = false;
                    Lblcvvnum.Visible = false;
                    RequiredFieldValidator6.Visible = false;

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr5", "<script type='text/javascript'>alert('Payment process is failed'); </script>", false);

                }

            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <RadioButtonList1_SelectedIndexChanged>
        // Summary  : <Make visible true of nardnum,namecard,expdate,cvvnum fields fields depending upon radiobutton >
        // Input Parameters : <radiobutton checked>
        // Output Parameters :<True/False>
        // Return Value  : <Visible true of required fields>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if(RadioButtonList1.SelectedIndex == 0)
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.SelectedValue = null;
                DropDownList2.Visible = true;
                Lblbnkname.Visible = true;
                RadioButtonList2.Visible = false;
                namecard.Visible = false;
                cardnum.Visible = false;
                expdate.Visible = false;
                cvvnum.Visible = false;
                Lblcardtype.Visible = false;
                Lblnamecard.Visible = false;
                Lblcardnum.Visible = false;
                Lblexpdate.Visible = false;
                Lblcvvnum.Visible = false;
                            
            }
            if (RadioButtonList1.SelectedIndex == 1)
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.SelectedValue = null;
                DropDownList2.Visible = true;
                RadioButtonList2.SelectedValue = null;
                RadioButtonList2.Visible = true;
                Lblbnkname.Visible = true;
                Lblcardtype.Visible = true;
                //namecard.Visible = true;
                //cardnum.Visible = true;
                //expdate.Visible = true;
                //cvvnum.Visible = true;
                //Lblnamecard.Visible = true;
                //Lblcardnum.Visible = true;
                //Lblexpdate.Visible = true;
                //Lblcvvnum.Visible = true;
               

            }
            if (RadioButtonList1.SelectedIndex == 2)
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.SelectedValue = null;
                DropDownList2.Visible = true;
                RadioButtonList2.SelectedValue = null;
                RadioButtonList2.Visible = true;
                Lblbnkname.Visible = true;
                Lblcardtype.Visible = true;
                //namecard.Visible = true;
                //cardnum.Visible = true;
                //expdate.Visible = true;
                //cvvnum.Visible = true;
                //Lblnamecard.Visible = true;
                //Lblcardnum.Visible = true;
                //Lblexpdate.Visible = true;
                //Lblcvvnum.Visible = true;
               
            }
           
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <RadioButtonList2_SelectedIndexChanged>
        // Summary  : <Make visible true of nardnum,namecard,expdate,cvvnum fields depending upon radiobutton >
        // Input Parameters : <radiobutton checked>
        // Output Parameters :<True/False>
        // Return Value  : <Visible true of required fields>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {

                namecard.Visible = true;
                cardnum.Visible = true;
                expdate.Visible = true;
                cvvnum.Visible = true;
                Lblnamecard.Visible = true;
                Lblcardnum.Visible = true;
                Lblexpdate.Visible = true;
                Lblcvvnum.Visible = true;
           

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <DropDownList1_SelectedIndexChanged>
        // Summary  : <View check payment and bill amount of perticular customer id and connection number >
        // Input Parameters : <connection number>
        // Output Parameters :<True/False,bill details>
        // Return Value  : <Show alert message>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DropDownList1.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr16", "<script type='text/javascript'>alert('Please select connection number'); </script>", false);
                billamt.Text = "";
                billamt.Enabled = false;
            }
            else
            {
                string customerid = Session["userid"].ToString();//sessionvalue
                double number = Convert.ToDouble(DropDownList1.SelectedValue);
                //payment manager
                IPaymentManager paymentmanager = PaymentManagerFactory.CreatePaymentManager();
                //payment object
                //check for already payment
                
                bool checkpayment = paymentmanager.CheckPayment(customerid, number);

                if (checkpayment)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr2", "<script type='text/javascript'>alert('The payment is already done for " + number + "   Connection number'); </script>", false);
                    custid.Text = Session["userid"].ToString();
                    custid.Enabled = false;
                    fillDropdown();
                    DropDownList1.Items.Insert(0, new ListItem("Please select number", "0"));
                    DropDownList1.SelectedIndex = 0;
                    billamt.Text = "";
                    billamt.Enabled = false;
                    Lblinr.Visible = false;
                    Lblinr1.Visible = false;
                    Lblbillamt.Visible = false;
                    Lblpayamt.Visible = false;
                    Lblpaymode.Visible = false;
                    billamt.Visible = false;
                    payamt.Visible = false;
                    RadioButtonList1.Visible = false;
                    DropDownList2.Visible = false;
                    RadioButtonList2.Visible = false;
                    namecard.Visible = false;
                    cardnum.Visible = false;
                    expdate.Visible = false;
                    cvvnum.Visible = false;
                    Lblbnkname.Visible = false;
                    Lblcardtype.Visible = false;
                    Lblnamecard.Visible = false;
                    Lblcardnum.Visible = false;
                    Lblexpdate.Visible = false;
                    Lblcvvnum.Visible = false;
                   
                }
               
                else
                {
                    IBill bill = null;
                    bill = paymentmanager.ValidBillDetails(customerid, number);
                   
                    if (bill == null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr6", "<script type='text/javascript'>alert('Bill is not generated for " + number + "  Connection number'); </script>", false);
                        billamt.Text = "";
                        billamt.Enabled = false;
                        custid.Text = Session["userid"].ToString();
                        custid.Enabled = false;
                        fillDropdown();
                        DropDownList1.Items.Insert(0, new ListItem("Please select number", "0"));
                        DropDownList1.SelectedIndex = 0;
                        billamt.Text = "";
                        billamt.Enabled = false;
                        Lblinr.Visible = false;
                        Lblinr1.Visible = false;
                        Lblbillamt.Visible = false;
                        Lblpayamt.Visible = false;
                        Lblpaymode.Visible = false;
                        billamt.Visible = false;
                        payamt.Visible = false;
                        RadioButtonList1.Visible = false;
                        DropDownList2.Visible = false;
                        RadioButtonList2.Visible = false;
                        namecard.Visible = false;
                        cardnum.Visible = false;
                        expdate.Visible = false;
                        cvvnum.Visible = false;
                        Lblbnkname.Visible = false;
                        Lblcardtype.Visible = false;
                        Lblnamecard.Visible = false;
                        Lblcardnum.Visible = false;
                        Lblexpdate.Visible = false;
                        Lblcvvnum.Visible = false;

                    }
                    else
                    {
                        billamt.Text = bill.Amount.ToString();
                        billamt.Enabled = false;
                        billamt.Visible =true;
                        payamt.Visible =true ;
                        Lblinr.Visible = true;
                        Lblinr1.Visible = true;
                        RadioButtonList1.Visible = true;
                        Lblbillamt.Visible = true;
                        Lblpayamt.Visible = true;
                        Lblpaymode.Visible = true;
                    }
                    
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : Button2_Click>
        // Summary  : <To cancel the payment process>
        // Input Parameters : <null>
        // Output Parameters :<show alert message>
        // Return Value  : <Return to home page>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>window.location.href='CustomerHome.aspx'; </script>", false);
                  
        }

        }
    }
