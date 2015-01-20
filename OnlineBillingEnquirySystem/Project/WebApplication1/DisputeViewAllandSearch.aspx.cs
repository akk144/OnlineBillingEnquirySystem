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
using BEP.BO_FACTORY;
using BEP.BLL_FACTORY;
using System.Drawing;

namespace WebApplication1
{
    public partial class DisputeViewAllandSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userid"] != null)
                {
                    if (Session["userid"].Equals("admin"))
                    {
                        FillGridview1();
                        GridView1.Visible = true;
                        RadioButtonList1.Visible = true;
                        sa.Visible = false;
                        RadioButtonList1.SelectedIndex = 0;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr71", "<script type='text/javascript'>alert('Page cannot be loaded');</script>", false);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr72", "<script type='text/javascript'>window.location.href='Loginres.aspx'</script>", false);

                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dtis = txtDisputeId.Text;
            string cid = txtCustomerId.Text;
            try
            {
                if (dtis == "")
                {
                    IDisputeManager disputeManager = DisputeManagerFactory.CreateDisputeManager();
                    List<IDispute> disputelist = disputeManager.SearchByCustomerId(cid);
                    if (disputelist.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView1.DataSource = disputelist;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        TableCellCollection cells = GridView1.HeaderRow.Cells;
                        cells[0].Attributes.Add("data-class", "expand");
                        cells[1].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[2].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[3].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[4].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[5].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[6].Attributes.Add("data-hide", "phone,tablet");
                        cells[7].Attributes.Add("data-hide", "phone,tablet");
                        //cells[8].Attributes.Add("data-hide", "phone,tablet");
                        cells[8].Attributes.Add("data-hide", "phone");
                    }
                    else if (disputelist.Count == 0)
                    {
                        GridView1.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('No record found')</script>", false);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                    }
                }
                else if (cid == "")
                {
                    long d = Convert.ToInt64(dtis);
                    IDisputeManager disputeManager = DisputeManagerFactory.CreateDisputeManager();
                    List<IDispute> disputelist = disputeManager.SearchByDisputeId(d);
                    if (disputelist.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView1.DataSource = disputelist;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        TableCellCollection cells = GridView1.HeaderRow.Cells;
                        cells[0].Attributes.Add("data-class", "expand");
                        cells[1].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[2].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[3].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[4].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[5].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[6].Attributes.Add("data-hide", "phone,tablet");
                        cells[7].Attributes.Add("data-hide", "phone,tablet");
                        //cells[8].Attributes.Add("data-hide", "phone,tablet");
                        cells[8].Attributes.Add("data-hide", "phone");
                    }
                    else if (disputelist.Count == 0)
                    {
                        GridView1.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('No record found')</script>", false);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                    }

                }
                else
                {
                    long d = Convert.ToInt64(dtis);
                    IDisputeManager disputeManager = DisputeManagerFactory.CreateDisputeManager();
                    List<IDispute> disputelist = disputeManager.SearchByBoth(cid, d);
                    if (disputelist.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView1.DataSource = disputelist;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        TableCellCollection cells = GridView1.HeaderRow.Cells;
                        cells[0].Attributes.Add("data-class", "expand");
                        cells[1].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[2].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[3].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[4].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[5].Attributes.Add("data-hide", "phone,tablet,screen");
                        cells[6].Attributes.Add("data-hide", "phone,tablet");
                        cells[7].Attributes.Add("data-hide", "phone,tablet");
                        //cells[8].Attributes.Add("data-hide", "phone,tablet");
                        cells[8].Attributes.Add("data-hide", "phone");
                    }
                    else if (disputelist.Count == 0)
                    {
                        GridView1.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('No record found')</script>", false);
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>", false);
            }
        }
        public void FillGridview1()
        {
            IDisputeManager disputeManager = DisputeManagerFactory.CreateDisputeManager();

            List<IDispute> DisputeList = null;
            try
            {
                DisputeList = disputeManager.ViewAll();
                if (DisputeList.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = DisputeList;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    TableCellCollection cells = GridView1.HeaderRow.Cells;
                    cells[0].Attributes.Add("data-class", "expand");
                    cells[1].Attributes.Add("data-hide", "phone,tablet,screen");
                    cells[2].Attributes.Add("data-hide", "phone,tablet,screen");
                    cells[3].Attributes.Add("data-hide", "phone,tablet,screen");
                    cells[4].Attributes.Add("data-hide", "phone,tablet,screen");
                    cells[5].Attributes.Add("data-hide", "phone,tablet,screen");
                    cells[6].Attributes.Add("data-hide", "phone,tablet");
                    cells[7].Attributes.Add("data-hide", "phone,tablet");
                    //cells[8].Attributes.Add("data-hide", "phone,tablet");
                    cells[8].Attributes.Add("data-hide", "phone");
                }
                else if (DisputeList.Count == 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('No record found')</script>");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>", false);
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            }

        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime sDate = Convert.ToDateTime(e.Row.Cells[7].Text);
                DateTime rDate = System.DateTime.Now;
                string st = Convert.ToString(e.Row.Cells[4].Text);
                int s1 = rDate.Day - sDate.Day;
                //DateTime s = Convert.ToDateTime(rdate - sdate);
                if (s1 > 6)
                {
                    if (st.ToUpper() == "OPEN")
                    {
                        e.Row.BackColor = Color.LightBlue;
                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('Resolve status of the highlighted dispute ')</script>");
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtDisputeId.Text = null;
            txtCustomerId.Text = null;
            GridView1.Visible = false;
        }

     
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList1.SelectedIndex == 0)
                {
                    FillGridview1();
                    GridView1.Visible = true;
                    sa.Visible = false;
                }
                if (RadioButtonList1.SelectedIndex == 1)
                {
                    GridView1.Visible = false;
                    sa.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>", false);
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            FillGridview1();
        }
    }
}