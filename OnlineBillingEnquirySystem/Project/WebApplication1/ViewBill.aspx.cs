///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the events regarding the ViewBill.aspx page>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Saikat,Shekhar,Akansh> Tata Consultancy Services
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
using System.Globalization;

namespace WebApplication1
{
    public partial class ViewBill : System.Web.UI.Page
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
                        vanish.Visible = false;
                        BtnViewBillDetails.Visible = false;
                        BtnViewBillDetails.Enabled = false;
                        IBillManager billManagerObj1 = BillManagerFactory.CreateBillManager();
                        List<long> list = billManagerObj1.ViewConnection1(Session["userid"].ToString());
                        List<string> monthList = getmonth();
                        DropDownListMonth.DataSource = monthList;
                        DropDownListMonth.DataBind();
                        DropDownListMonth.Items.Insert(0, new ListItem("Select", "0"));
                        DropDownListMonth.SelectedIndex = 0;
                        DropDownListMonth.Visible = true;
                        DropDownListConnection.DataSource = list;
                        DropDownListConnection.DataBind();
                        DropDownListConnection.Items.Insert(0, new ListItem("Select", "0"));
                        DropDownListConnection.SelectedIndex = 0;
                        DropDownListConnection.Visible = true;
                    }
                }
            }
        }
        protected void BtnViewBill_Click(object sender, EventArgs e)
        {
            vanish.Visible = false;
            BtnViewBillDetails.Visible = false;
            BtnViewBillDetails.Enabled = false;
            if (Page.IsValid)
            {
                try
                {
                    Int32 year = 0;
                    Int64 connectionId = Convert.ToInt64(DropDownListConnection.SelectedValue);
                    string month = string.Empty;
                    try
                    {
                        month = (DateTime.ParseExact((DropDownListMonth.SelectedValue).ToString(), "MMMM", CultureInfo.CurrentCulture).Month).ToString();
                        if (System.DateTime.Now.Month - Convert.ToInt32(month) > 0)
                        {
                            year = System.DateTime.Now.Year;
                        }
                        else
                        {
                            year = System.DateTime.Now.Year - 1;
                        }
                        IBill billObj1 = BillFactory.CreateBill(connectionId, year, month);
                        IBillManager billManagerObj1 = BillManagerFactory.CreateBillManager();
                        int result = billManagerObj1.CheckConnection(billObj1);
                        IBill billObj = BillFactory.CreateBill(connectionId, year, month);
                        IBillManager billManagerObj = BillManagerFactory.CreateBillManager();
                        IBill bill = billManagerObj.ViewBillByConnection(billObj);
                        billid.Text = (bill.BillId).ToString();
                        customerid.Text = (bill.CustomerId).ToString();
                        connectionid.Text = (bill.ConnectionId).ToString();
                        generatedate.Text = (bill.GenerateDate.ToShortDateString()).ToString();
                        amount.Text = (bill.Amount).ToString() + "  INR";
                        yearr.Text = (bill.Year).ToString();
                        monthh.Text = (bill.Month).ToString();
                        arrears.Text = (bill.Arrears).ToString() + "  INR";
                        advancepayment.Text = (bill.AdvancedPayment).ToString() + "  INR";
                        discount.Text = (bill.Discount).ToString() + "  INR";
                        totalamount.Text = (bill.Total).ToString() + "  INR";
                        vanish.Visible = true;
                        BtnViewBillDetails.Visible = true;
                        BtnViewBillDetails.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Your bill for the month you selected is not apllicable'); </script>", false);
                        DropDownListConnection.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
                }
            }
        }
        protected void BtnViewBillDetails_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Session["connection"] = Convert.ToInt64(DropDownListConnection.SelectedValue);
                DateTime d = Convert.ToDateTime(generatedate.Text);
                string day = d.Day.ToString();
                string year = d.Year.ToString();
                string month = DropDownListMonth.SelectedValue;
                DateTime ds = DateTime.Parse(month + "/" + day + "/" + year);
                Session["date"] = ds;
                Response.Redirect("ViewBillItem.aspx");
            }
        }
        public List<string> getmonth()
        {
            List<string> monthList = new List<string>();
            switch (System.DateTime.Now.Month)
            {
                case 1:
                    {
                        monthList.Add("December");
                        monthList.Add("November");
                        monthList.Add("October");
                        break;
                    }
                case 2:
                    {
                        monthList.Add("January");
                        monthList.Add("December");
                        monthList.Add("November");
                        break;
                    }
                case 3:
                    {
                        monthList.Add("February");
                        monthList.Add("January");
                        monthList.Add("December");
                        break;
                    }
                default:
                    {
                        string firstMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(System.DateTime.Now.Month - 1);
                        string secondMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(System.DateTime.Now.Month - 2);
                        string thirdMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(System.DateTime.Now.Month - 3);
                        monthList.Add(firstMonth);
                        monthList.Add(secondMonth);
                        monthList.Add(thirdMonth);
                        break;
                    }
            }
            return monthList;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}