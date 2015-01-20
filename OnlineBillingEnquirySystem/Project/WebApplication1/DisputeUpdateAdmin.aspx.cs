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
using System.Drawing;
using BEP.TYPES;
using BEP.BLL_FACTORY;
using BEP.BO_FACTORY;

namespace WebApplication1
{
    public partial class DisputeUpdateAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack)
                    {
                     if (Session["userid"] != null)
                      {
                         if(Session["userid"].Equals("admin"))
                         {
                  
                            FillGridview1();
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
        public void FillGridview1()
        {
            IDisputeManager disputeManager = DisputeManagerFactory.CreateDisputeManager();

            List<IDispute> DisputeList = null;
            try
            {
                DisputeList = disputeManager.ViewAllOpen();
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
                    cells[8].Attributes.Add("data-hide", "phone,tablet");
                    cells[9].Attributes.Add("data-hide", "phone");
                }
                else if (DisputeList.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('No record found for updation')</script>", false);
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('no Record Found')</script>");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>", false);
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>");
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGridview1();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label Dispute_Id = (Label)GridView1.Rows[e.RowIndex].FindControl("lDisputeId");
                Label Customer_Id = (Label)GridView1.Rows[e.RowIndex].FindControl("lCustomerId");
                Label BillId = (Label)GridView1.Rows[e.RowIndex].FindControl("lBillId");
                DropDownList Status = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
                TextBox Comment = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtComment");
                TextBox DateofResolve = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDateOfResolve");
                long dispute_Id = Convert.ToInt64(Dispute_Id.Text);
                string custId = Convert.ToString(Customer_Id.Text);
                long billId = Convert.ToInt64(BillId.Text);
                string status = Status.SelectedValue.ToString();
                string comment = Comment.Text.ToString();
                string dateOfResolve = DateofResolve.Text.ToString();
                //bool flag = false;
                IDisputeManager disputeManager = DisputeManagerFactory.CreateDisputeManager();
                //long res = disputeManager.CheckUpdate(billId, custId);
                //if (res > 0)
                //{
                   
                        if (status == "0")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Dispute status should be resolved for update'); </script>", false);
                        }
                        else
                        {
                            int result = disputeManager.UpdateDispute(custId, dispute_Id, status, comment, dateOfResolve);
                            if (result > 0)
                            {
                                //flag = true;
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Dispute status is updated'); </script>", false);
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('Dispute id is updated')</script>");
                                FillGridview1();
                            }

                            //Response.Redirect("DisputeUpdateAdmin.aspx");
                        }
                    
                   
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "<script type='text/javascript'>alert('Call Cost of this billid is not yet updated'); </script>", false);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "<script type='text/javascript'> alert('" + ex.Message + "')</script>", false);
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGridview1();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            FillGridview1();
        }
        //protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DateTime sDate = Convert.ToDateTime(e.Row.Cells[7].Text);
        //        DateTime rDate = System.DateTime.Now;
        //        string st = Convert.ToString(e.Row.Cells[4].Text);
        //        int s1 = rDate.Day - sDate.Day;
        //        //DateTime s = Convert.ToDateTime(rdate - sdate);
        //        if (s1 > 6)
        //        {
        //            if (st.ToUpper() == "OPEN")
        //            {
        //                e.Row.BackColor = Color.LightBlue;
        //                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script type='text/javascript'> alert('Resolve status of the highlighted dispute ')</script>");
        //            }
        //        }
        //    }
      

        //}
       
      
    }
}