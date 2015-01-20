///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Dispute related operations by calling the Manager's Functions and implementing logic as required>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Jayram,Shekhar>, Tata Consultancy Services
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

namespace WebApplication1
{
    public partial class DisputeViewCustomer : System.Web.UI.Page
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
                        submit.Visible = false;
                        ConnectionnumList1.Visible = false;
                        string custid = Convert.ToString(Session["userid"]);
                    }
                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                if (Session["userid"] != null)
                {
                    submit.Visible = false;
                    ConnectionnumList1.Visible = false;
                    string custid = Convert.ToString(Session["userid"]);
                    long Connectionid = Convert.ToInt64(Session["connection"]);
                    GridView1.Visible = true;
                    FillGridview1(custid);
                }
            }
            else
            {
                if (RadioButtonList1.SelectedIndex == 1)
                {
                    if (Session["userid"] != null)
                    {
                        submit.Visible = true;
                        IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
                        List<long> list1 = disputemanager.ViewConnection(Session["userid"].ToString());
                        ConnectionnumList1.DataSource = list1;
                        ConnectionnumList1.DataBind();
                        ConnectionnumList1.Items.Insert(0, new ListItem("Select", "0"));
                        ConnectionnumList1.SelectedIndex = 0;
                        ConnectionnumList1.Visible = true;
                        GridView1.Visible = false;
                    }
                }
            }
        }
        public void FillGridview1(string y)
        {
            IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
            List<IDispute> DisputeList = null;
            //try
            //{
            DisputeList = disputemanager.ViewAllDispute(y);
            if (DisputeList.Count > 0)
            {
                GridView1.Visible = true;
                GridView1.DataSource = DisputeList;
                GridView1.DataBind();
            }
            else if (DisputeList.Count == 0)
            {
                GridView1.Visible = true;
                GridView1.DataSource = DisputeList;
                GridView1.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('No Record Found')</script>", false);
            }
            //}
            //catch (Exception ex)
            //{
            //    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('" + ex.Message + "')</script>", false);

            //}
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            long Disputeid = Convert.ToInt64(row.Cells[0].Text);
            string Customerid = Convert.ToString(row.Cells[1].Text);
            string _status = Convert.ToString(row.Cells[7].Text);
            if (_status == "Open")
            {
                    IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
                    int x = disputemanager.Delete(Customerid, Disputeid);
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('Your Dispute has been successfully Deleted.')</script>");
                    if (RadioButtonList1.SelectedIndex == 0)
                    {
                        string custid = Convert.ToString(Session["userid"]);
                        FillGridview1(custid);
                        GridView1.Visible = true;
                    }
                    else if (RadioButtonList1.SelectedIndex == 1)
                    {
                        ConnectionnumList1.SelectedIndex = 0;
                        ConnectionnumList1.Visible = true;
                        submit.Visible = true;
                        GridView1.Visible = false;
                    }         
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('Status should be open for deleting a dispute.')</script>", false);
            }
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string custid = Convert.ToString(Session["userid"]);
            long connection = Convert.ToInt64(ConnectionnumList1.SelectedValue);
            FillGridview2(custid, connection);

        }
        public void FillGridview2(string y, long x)
        {
            IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();

            List<IDispute> DisputeList = null;
            try
            {
                DisputeList = disputemanager.View(y, x);
                if (DisputeList.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = DisputeList;
                    GridView1.DataBind();
                    ConnectionnumList1.Visible = true;
                    submit.Visible = true;
                }
                else if (DisputeList.Count == 0)
                {
                    GridView1.Visible = false;
                    //ConnectionnumList1.Visible = true;
                    //submit.Visible = true;
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('Sorry........ You have no dispute on this bill.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('" + ex.Message + "')</script>", false);
                ConnectionnumList1.Visible = true;
                submit.Visible = true;
                GridView1.Visible = false;
            }
        }
    }
}