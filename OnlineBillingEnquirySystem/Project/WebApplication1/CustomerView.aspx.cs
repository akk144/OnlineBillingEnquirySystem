///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <View all the Payment details by calling the Manager's Function>
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
using System.Collections;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.TYPES;
using BEP.BLL;
using BEP.BLL_FACTORY;

namespace WebApplication1
{
    public partial class CustomerView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                        GridViewPaymentDetails1.Visible = false;
                        custid.Text = Session["userid"].ToString();
                        custid.Enabled = false;
                        fillDropDown();
                        connectionList1.Items.Insert(0, new ListItem("Please Select Number", "0"));
                        connectionList1.SelectedIndex = 0;
                    }
                }
               
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <fillDropDown>
        // Summary  : <To view connection number of perticular customer>
        // Input Parameters : <customer id>
        // Output Parameters :<customer name>
        // Return Value  : <Return connection numbers of perticular id>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        protected void fillDropDown()
        {
          
            
            string customerid = Session["userid"].ToString();
         
            IPaymentManager paymentmanager = PaymentManagerFactory.CreatePaymentManager();
            List<double> list = paymentmanager.GetConnectionNo(customerid);
            connectionList1.DataSource = list;
            connectionList1.DataBind();
            
           
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <FillGridViewCustomer>
        // Summary  : <To view payment details of perticular customer>
        // Input Parameters : <customer id,connection number>
        // Output Parameters :<List of payment details>
        // Return Value  : <Return List of payment details of perticular id and connection number>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public void FillGridViewCustomer(string id, double conid)
        {
            
            string cust_id = id;
            double con_id = conid;
            IPaymentManager paymentManager = PaymentManagerFactory.CreatePaymentManager();
            List<IPayment> PaymentList = null;
            PaymentList = paymentManager.ViewSinglePayment(cust_id, con_id);
            if (PaymentList.Count > 0)
            {
                GridViewPaymentDetails1.DataSource = PaymentList;
                GridViewPaymentDetails1.DataBind();
                GridViewPaymentDetails1.HeaderRow.TableSection = TableRowSection.TableHeader;

                TableCellCollection cells = GridViewPaymentDetails1.HeaderRow.Cells;
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
                cells[10].Attributes.Add("data-hide", "phone");
                GridViewPaymentDetails1.Visible = true;

                
            }
            else if (PaymentList.Count == 0)
            {
                GridViewPaymentDetails1.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('No record found'); </script>", false);
                 }

           
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <Button1_Click>
        // Summary  : <To view payment details of perticular customer and connection number>
        // Input Parameters : <customer id,connection number>
        // Output Parameters :<List of payment details>
        // Return Value  : <null>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (connectionList1.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr21", "<script type='text/javascript'>alert('Please select connection number'); </script>", false);


            }
            else
            {
                string id = custid.Text;
                double conid = Convert.ToDouble(connectionList1.SelectedValue);
                GridViewPaymentDetails1.Visible = true;
                FillGridViewCustomer(id, conid);
            }
           

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <GridViewPaymentDetails1_SelectedIndexChanged>
        // Summary  : <To view payment details of perticular customer and connection number>
        // Input Parameters : <customer id,connection number>
        // Output Parameters :<List of payment details>
        // Return Value  : <null>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewPaymentDetails1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewPaymentDetails1.SelectedRow;
            string id = row.Cells[1].Text;
            double num = Convert.ToDouble(row.Cells[3].Text);
            Session["singleUser"] = id;
            Session["connectionno"] = num;
            Response.Redirect("ViewSinglePayment.aspx");
             }
       
    }
}