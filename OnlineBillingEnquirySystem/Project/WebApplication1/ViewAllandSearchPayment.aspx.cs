///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <View all the Payment details by calling the Manager's Functions>
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
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.TYPES;
using BEP.BLL;
using BEP.BLL_FACTORY;

namespace WebApplication1
{
    public partial class ViewAllandSearchPayment : System.Web.UI.Page
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
                        tab1.Visible = false;
                        GridView1.Visible = true;
                        FillGridViewAdminViewAll();
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        Button1.Visible = false;
                        Label4.Visible = false;
                        Label2.Visible = true;
                        Label1.Visible = false;
                        Label3.Visible = false;
                        RadioButtonList1.SelectedIndex = 0;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr17", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr18", "<script type='text/javascript'>window.location.href='Loginres.aspx';</script>", false);

                    }
                }
                //GridView1.UseAccessibleHeader = true;
                //TableCellCollection cells = GridView1.HeaderRow.Cells;
                //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                
                //cells[0].Attributes.Add("data-class", "expand");
                ////cells[1].Attributes.Add("data-hide", "phone,tablet");
                ////cells[2].Attributes.Add("data-hide", "phone,tablet");
                //cells[3].Attributes.Add("data-hide", "phone,tablet");
                //cells[4].Attributes.Add("data-hide", "phone,tablet");
                //cells[5].Attributes.Add("data-hide", "phone,tablet");
                //cells[6].Attributes.Add("data-hide", "phone,tablet");
                //cells[7].Attributes.Add("data-hide", "phone,tablet");
                //cells[8].Attributes.Add("data-hide", "phone,tablet");
                //cells[9].Attributes.Add("data-hide", "phone,tablet");

                //cells[10].Attributes.Add("data-hide", "phone");    
                //GridView1.Visible = false;
               
               // ModalPopupExtender1.Show();
            }
        }
          
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                tab1.Visible = false;
                FillGridViewAdminViewAll();
               // ModalPopupExtender1.Show();
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button1.Visible = false;
                Label4.Visible = false;
                Label2.Visible = false;
                Label1.Visible = false;
                Label3.Visible = false;
             
               // Label2.Visible = true;
                //GridView1.Visible = true;
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                tab1.Visible = true;
                Label2.Visible = false;
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                Button1.Visible = true;
                Label4.Visible = true;
                Label1.Visible = true;
                Label3.Visible = true;
                GridView1.Visible = false;

               
            }
        }

        public void FillGridViewAdminViewAll()
        {
            IPaymentManager paymentManager = PaymentManagerFactory.CreatePaymentManager();
            List<IPayment> PaymentList = null;
            try
            {
                PaymentList = paymentManager.ViewAllPayment();
                if (PaymentList.Count > 0)
                {
                    GridView1.DataSource = PaymentList;
                    GridView1.DataBind();
                    //GridView1.UseAccessibleHeader = true;
                    //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //TableCellCollection cells = GridView1.HeaderRow.Cells;
                    //cells[0].Attributes.Add("data-class", "expand");
                    //cells[1].Attributes.Add("data-hide", "phone,tablet");
                    //cells[2].Attributes.Add("data-hide", "phone,tablet");
                    //cells[3].Attributes.Add("data-hide", "phone,tablet");
                    //cells[4].Attributes.Add("data-hide", "phone,tablet");
                    //cells[5].Attributes.Add("data-hide", "phone");
                    //cells[6].Attributes.Add("data-hide", "phone,tablet");
                    //cells[7].Attributes.Add("data-hide", "phone,tablet");
                    //cells[8].Attributes.Add("data-hide", "phone");
                    //cells[9].Attributes.Add("data-hide", "phone,tablet");
                    //cells[10].Attributes.Add("data-hide", "phone");
                    GridView1.Visible = true;
                    Label2.Visible = true;
                    //ModalPopupExtender1.Show();
                }
                else if (PaymentList.Count == 0)
                {
                    Label1.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('No record found'); </script>", false);
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('No Record Found')</script>");
                    Label2.Visible = false;
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;
                    Button1.Visible = false;
                    Label4.Visible = false;
                    Label2.Visible = false;
                    Label1.Visible = false;
                    Label3.Visible = false;
                    GridView1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            double num = Convert.ToDouble(row.Cells[3].Text);
            Session["singleUser"] = id;
            Session["connectionno"] = num;
            Response.Redirect("ViewSinglePaymentAdmin.aspx");
            //Response.Redirect("ViewSinglePayment.aspx");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            // try{
            string id = TextBox1.Text;
            FillGridViewAdminSearch();
            
           // GridView1.Visible = true;
            // }
            /*catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            }*/

        }
        public void FillGridViewAdminSearch()
        {
            //take session id form customer
            // string cust_id =id;
            string id = TextBox1.Text;


            if (id == "")
            {
                double conn_no = Convert.ToDouble(TextBox2.Text);
                IPaymentManager paymentManager = PaymentManagerFactory.CreatePaymentManager();
                List<IPayment> PaymentList = null;
                PaymentList = paymentManager.SearchPaymentCon(conn_no);
                if (PaymentList.Count > 0)
                {
                    GridView1.DataSource = PaymentList;
                    GridView1.DataBind();
                    Label2.Visible = true;
                    GridView1.Visible = true;
                    //ModalPopupExtender1.Show();
                }
                else if (PaymentList.Count == 0)
                {
                    Label2.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('No record found'); </script>", false);
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                    Label2.Visible = false;
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;
                    Button1.Visible = false;
                    Label4.Visible = false;
                    Label2.Visible = false;
                    Label1.Visible = false;
                    Label3.Visible = false;
                    GridView1.Visible = false;
                }
            }
            else if (TextBox2.Text == "")
            {
             
                // double conn_no = Convert.ToDouble(TextBox2.Text);
                IPaymentManager paymentManager = PaymentManagerFactory.CreatePaymentManager();
                bool b = paymentManager.ValidCustomer(id);
                if (!b)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr10", "<script type='text/javascript'>alert('Invalid Customer id'); </script>", false);
                    TextBox1.Text = null;
                    TextBox2.Text = null; 
                    tab1.Visible = true;
                    
               
                }
                else
                {
                    List<IPayment> PaymentList = null;
                    PaymentList = paymentManager.SearchAllPayment(id);
                    if (PaymentList.Count > 0)
                    {
                        GridView1.DataSource = PaymentList;
                        GridView1.DataBind();
                        
                        GridView1.Visible = true;
                        //ModalPopupExtender1.Show();
                        Label2.Visible = true;
                    }
                    else if (PaymentList.Count == 0)
                    {
                        Label2.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('No Record Found'); </script>", false);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                        Label2.Visible = false;
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        Button1.Visible = false;
                        Label4.Visible = false;
                        Label2.Visible = false;
                        Label1.Visible = false;
                        Label3.Visible = false;
                        GridView1.Visible = false;
                    }
                }
            }
            else
            {
                double conn_no = Convert.ToDouble(TextBox2.Text);
                IPaymentManager paymentManager = PaymentManagerFactory.CreatePaymentManager();
                bool b = paymentManager.ValidConnection(id,conn_no);
                if (!b)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr10", "<script type='text/javascript'>alert('Please enter a valid Customer id/Connection number'); </script>", false);
                    //Label2.Visible = false;
                    //TextBox1.Visible = false;
                    //TextBox2.Visible = false;
                    //Button1.Visible = false;
                   // Label4.Visible = false;
                   // Label2.Visible = false;
                   // Label1.Visible = false;
                    //Label3.Visible = false;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    GridView1.Visible = false;
                    tab1.Visible = true;
                
                }
                else
                {
                    List<IPayment> PaymentList = null;
                    PaymentList = paymentManager.ViewSinglePayment(id, conn_no);
                    if (PaymentList.Count > 0)
                    {
                        GridView1.DataSource = PaymentList;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                       //ModalPopupExtender1.Show();
                        Label2.Visible = true;
                    }
                    else if (PaymentList.Count == 0)
                    {
                       
                       // Label2.Visible = true;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr2", "<script type='text/javascript'>alert('No Record Found'); </script>", false);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                        Label2.Visible = false;
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        Button1.Visible = false;
                        Label4.Visible = false;
                        Label2.Visible = false;
                        Label1.Visible = false;
                        Label3.Visible = false;
                        GridView1.Visible = false;
                    }
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = null;
            TextBox2.Text = null;
            GridView1.Visible = false;
            Label2.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            FillGridViewAdminViewAll();
        }
    }
}