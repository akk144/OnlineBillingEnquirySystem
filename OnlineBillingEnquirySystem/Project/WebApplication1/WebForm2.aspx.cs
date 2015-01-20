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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {

                if (Session["billid"] != null)
                {

                    billId.Text = Convert.ToString(Session["billid"]);
                    customerId.Text = Session["userid"].ToString();
                    connectionId.Text = Convert.ToString(Session["connection"]);
                    disputeDate.Text = System.DateTime.Now.ToShortDateString();
                    stats.Text = "Open";
                    stats.Enabled = false;
                    billId.Enabled = false;
                    customerId.Enabled = false;
                    connectionId.Enabled = false;
                    disputeDate.Enabled = false;
                    ldispute.Visible = false;
                    ldisputeId.Visible = false;


                }
                else
                {
                    disputeDate.Enabled = false;
                    disputeDate.Text = System.DateTime.Now.ToShortDateString();
                    customerId.Enabled = false;
                    customerId.Text = Session["userid"].ToString();
                    connectionId.Enabled = true;
                    billId.Enabled = true;
                    stats.Text = "Open";
                    stats.Enabled = false;

                }
            }
        }

       

        protected void clear_Click(object sender, EventArgs e)
        {
            problem.Text = "";
        }

        protected void submit1_Click1(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                if (Page.IsValid)
                {
                    long billId = Convert.ToInt64(Session["billid"].ToString());
                    string customerId = Session["userid"].ToString();
                    IDisputeManager disputemanager = DisputeManagerFactory.CreateDisputeManager();
                    long callId = disputemanager.Validate(billId, customerId);
                    if (callId == 0)
                    {

                        long BillId = Convert.ToInt64(Session["billid"]);
                        string CustomerId = Session["userid"].ToString();
                        long ConnectionId = Convert.ToInt64(Session["connection"]);
                        string ProblemDetails = Convert.ToString(problem.Text);
                        string dateRaise = System.DateTime.Now.ToShortDateString();
                        IDisputeManager dis = DisputeManagerFactory.CreateDisputeManager();
                        long x = dis.Add(BillId, CustomerId, ConnectionId, "Open", ProblemDetails, dateRaise);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('Your dispute is successfully raised.')</script>", false);
                        if (x != -1)
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('Dispute added successfully.')</script>");
                            //Panel1.Visible = false;



                            ldispute.Visible = true;
                            ldisputeId.Visible = true;
                            ldisputeId.Text = x.ToString();
                            problem.Text = "";

                            ////bill.Visible = false;
                            //billid.Text = "";
                            ////cusid.Visible = false;
                            //customerid.Text = "";
                            //connectionid.Text = "";
                            ////connid.Visible = false;
                            ////stat.Visible = false;
                            //stats.Text = "";
                            ////prob.Visible = false;
                            //problemdetails.Text = "";
                            ////date.Visible = false;
                            //disputedate.Text = "";
                            ////submit.Visible = false;
                            ////clear.Visible = false;


                        }

                    }
                    else
                    { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'>alert('You have already raise a dispute')</script>", false); }

                }
            }
        }

        


    }
}