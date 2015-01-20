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
using BEP.BLL;
using BEP.BLL_FACTORY;
using BEP.TYPES;

namespace WebApplication1
{
    public partial class DisputeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    if (!IsPostBack)
                    {
                            customerId.Text = Session["userid"].ToString();
                            IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
                            List<long> list1 = disputemanager.ViewConnectionAdd(Session["userid"].ToString());
                            connectionId.DataSource = list1;
                            connectionId.DataBind();
                            connectionId.Items.Insert(0, new ListItem("Select", "0"));
                            connectionId.SelectedIndex = 0;   
                            long connection = Convert.ToInt64(connectionId.SelectedValue);
                            disputeDate.Text = System.DateTime.Now.ToShortDateString();
                            stats.Text = "Open";
                            stats.Enabled = false;
                            customerId.Enabled = false;
                            disputeDate.Enabled = false;
                        }
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                long bill = Convert.ToInt64(billId.SelectedValue);
                string customerId = Session["userid"].ToString();
                IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
                long callId = disputemanager.Validate(bill, customerId);
                if (callId == 0)
                {
                    long billi = Convert.ToInt64(billId.SelectedValue);
                    string CustomerId = Session["userid"].ToString();
                    long ConnectionId = Convert.ToInt64(connectionId.SelectedValue);
                    string ProblemDetails = Convert.ToString(problem.Text);
                    string dateRaise = System.DateTime.Now.ToShortDateString();
                    IDisputeManager dis = DisputeManagerFactory.CreateDisputeManager();
                    long x = dis.Add(billi, CustomerId, ConnectionId, "Open", ProblemDetails, dateRaise);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('Your dispute is successfully raised.')</script>", false);
                    if (x != -1)
                    {
                        ldispute.Visible = true;
                        ldisputeId.Visible = true;
                        ldisputeId.Text = x.ToString();
                        problem.Text = "";
                        connectionId.SelectedIndex = 0;




                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('You have already raised a dispute.')</script>", false);
                }
            }   
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            problem.Text = "";
            connectionId.SelectedIndex = 0;
            //billId.SelectedIndex = 0;
        }

        protected void connectionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
            long connection = Convert.ToInt64(connectionId.SelectedValue);
            string custid = customerId.Text;
            List<long> list2 = disputemanager.GetBillId(custid, connection);
            billId.DataSource = list2;
            billId.DataBind();
            billId.Items.Insert(0, new ListItem("Select", "0"));

            billId.SelectedIndex = 0;
        }

        protected void billId_SelectedIndexChanged(object sender, EventArgs e)
        {
            long bill = Convert.ToInt64(billId.SelectedValue);
            string customerId = Session["userid"].ToString();
            IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
            long callId = disputemanager.Validate(bill, customerId);
            if (callId != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('You have already raise a dispute')</script>", false);
                submit.Enabled = false;
            }
            else { submit.Enabled = true; }
        }
    }
}