///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Dispute related operations by calling the store procedures and implementing logic as required>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Shekhar,Jayram>, Tata Consultancy Services
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
using System.Data;
using System.Data.SqlClient;
using BEP.TYPES;
using BEP.BO_FACTORY;

namespace BEP.DAL
{
    public class DisputeDB : IDisputeDB
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <Add>
        // Summary  : <To raise a dispute over a bill of a particular connection id.>
        // Input Parameters : < long Bill_Id,string Customer_Id, long ConnectionNo,string Status,string Problem,string Dateofraise>
        // Output Parameters : <Null>
        // Return Value  : <Dispute Id>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public long Add(long billId, string customerId, long connectionNo, string status, string problem, string dateOfRaise)
        {
            long x;

            SqlConnection conn = null;

            try
            {
                conn = DBUTILITY.getConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_AddDispute";
                conn.Open();
                cmd.Parameters.AddWithValue("@Bill_Id", billId);
                cmd.Parameters.AddWithValue("@Customer_Id", customerId);
                cmd.Parameters.AddWithValue("@ConnectionNo", connectionNo);
                cmd.Parameters.AddWithValue("@_Status", status);
                cmd.Parameters.AddWithValue("@Problem", problem);
                cmd.Parameters.AddWithValue("@Dateofraise", dateOfRaise);
                cmd.Parameters.AddWithValue("@Dispute_Id", 0);
                cmd.Parameters["@Dispute_Id"].Direction = ParameterDirection.Output;
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    x = Convert.ToInt64(cmd.Parameters["@Dispute_Id"].Value);
                    return x;
                }
                else
                {
                    return rows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <Validate>
        // Summary  : <To validate the dispute raised on a paticular bill.>
        // Input Parameters : <long Bill_Id,string Customer_Id>
        // Output Parameters : <Null>
        // Return Value  : <Bill Id>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public long Validate(long billId, string custId)
        {
            SqlConnection conn = null;

            try
            {
                conn = DBUTILITY.getConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_check_TeamE65";
                conn.Open();
                cmd.Parameters.AddWithValue("@Bill_Id", billId);
                cmd.Parameters.AddWithValue("@Customer_Id", custId);
                long bill_Id = Convert.ToInt64(cmd.ExecuteScalar());
                if (billId == bill_Id)
                {
                    return bill_Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return 0;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <View>
        // Summary  : <To view the dispute raised by a customer over a particular connection number.>
        // Input Parameters : <string Customer_Id, long Connection_Id>
        // Output Parameters : <Null>
        // Return Value  : <Return the Dispute List>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDispute> View(string custId, long connId)
        {
            List<IDispute> DisputeList1 = new List<IDispute>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ViewDispute";
                conn.Open();
                cmd.Parameters.AddWithValue("@Customer_Id", custId);
                cmd.Parameters.AddWithValue("@ConnectionNo", connId);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    long dispute_Id = Convert.ToInt64(sdr["Dispute_Id"]);
                    string customer_Id = sdr["Customer_Id"].ToString();
                    long connection_Id = Convert.ToInt64(sdr["ConnectionNo"]);
                    long bill_Id = Convert.ToInt64(sdr["Bill_Id"]);
                    string dateOFRaise = ((Convert.ToDateTime(sdr["Dateofraise"].ToString())).ToShortDateString()).ToString();
                    string problem = sdr["Problem"].ToString();
                    string comment = sdr["Comment"].ToString();
                    string status = sdr["_Status"].ToString();
                    IDispute dis = DisputeFactory.CreateDispute(dispute_Id, bill_Id, customer_Id, connection_Id, status, comment, problem, dateOFRaise);
                    DisputeList1.Add(dis);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return DisputeList1;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewAllDispute>
        // Summary  : <To view all dispute raised by a customer.>
        // Input Parameters : <string Customer_Id>
        // Output Parameters : <Null>
        // Return Value  : <Retuen List of Disputes raised over a Customer Id. >
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDispute> ViewAllDispute(string custId)
        {
            List<IDispute> DisputeList1 = new List<IDispute>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ViewallDispute";
                conn.Open();
                cmd.Parameters.AddWithValue("@Customer_Id", custId);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    long dispute_Id = Convert.ToInt64(sdr["Dispute_Id"]);
                    string customer_Id = sdr["Customer_Id"].ToString();
                    long connection_Id = Convert.ToInt64(sdr["ConnectionNo"]);
                    long bill_Id = Convert.ToInt64(sdr["Bill_Id"]);
                    string dateOFRaise = ((Convert.ToDateTime(sdr["Dateofraise"].ToString())).ToShortDateString()).ToString();
                    string problem = sdr["Problem"].ToString();
                    string comment = sdr["Comment"].ToString();
                    string status = sdr["_Status"].ToString();
                    IDispute dis = DisputeFactory.CreateDispute(dispute_Id, bill_Id, customer_Id, connection_Id, status, comment, problem, dateOFRaise);
                    DisputeList1.Add(dis);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return DisputeList1;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewConnection>
        // Summary  : <To get all the connection no pertaining with a Customer Id>
        // Input Parameters : <string Customer_Id>
        // Output Parameters : <Null>
        // Return Value  : <Retuen List of Connection numbers. >
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        public List<long> ViewConnection(string custId)
        {
            List<long> connection = new List<long>();           
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_checkconnectionno_TeamE65";
                conn.Open();
                cmd.Parameters.AddWithValue("@Customer_Id", custId);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    //long connection_id = Convert.ToInt64(sdr["ConnectionNo"]);
                    //IDispute dis = DisputeFactory.CreateDispute(connection_id);
                    connection.Add(Convert.ToInt64(sdr["ConnectionNo"]));
                }
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return connection;
        }




        //get all the connection no
        public List<long> ViewConnectionAdd(string custId)
        {
            List<long> connection = new List<long>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_checkconnectionno1_TeamE65";
                conn.Open();
                cmd.Parameters.AddWithValue("@CustomerId", custId);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    connection.Add(Convert.ToInt64(sdr["ConnectionNo"]));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return connection;
        }
        //get bill Id from customer id and connection id

        public List<long> GetBillId(string custId,long connid)
        {
            List<long> connection1 = new List<long>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_checkbillId_TeamE65";
                conn.Open();
                cmd.Parameters.AddWithValue("@CustomerId", custId);
                cmd.Parameters.AddWithValue("@ConnectionNo", connid);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    connection1.Add(Convert.ToInt64(sdr["Bill_Id"]));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return connection1;
        }








        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <Delete>
        // Summary  : <To delete particular Dispute>
        // Input Parameters : <string Customer Id,long Dispute Id>
        // Output Parameters : <Null>
        // Return Value  : <Integer>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public int Delete(string customerId, long disputeId)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteDispute";

                conn.Open();
                cmd.Parameters.AddWithValue("@Customer_Id", customerId);
                cmd.Parameters.AddWithValue("@Dispute_Id", disputeId);
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewAll>
        // Summary  : <To view all dispute raised by customers.>
        // Input Parameters : <Null>
        // Output Parameters : <Null>
        // Return Value  : <List of Disputes.>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDispute> ViewAll()
        {
            List<IDispute> DisputeList = new List<IDispute>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_viewallAdmin_TeamE65";
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    long dispute_Id = Convert.ToInt64(sdr["Dispute_Id"]);
                    long bill_Id = Convert.ToInt64(sdr["Bill_Id"]);
                    string customer_Id = sdr["Customer_Id"].ToString();
                    long connection_No = Convert.ToInt64(sdr["ConnectionNo"]);
                    string status = sdr["_Status"].ToString();
                    string problem = sdr["Problem"].ToString();
                    string comment = sdr["Comment"].ToString();
                    string dateOFRaise = ((Convert.ToDateTime(sdr["Dateofraise"])).ToShortDateString()).ToString();
                    string dateOfResolve = (sdr["Dateofresolve"].ToString());
                    string cancellation = sdr["Cancel_Comment"].ToString();
                    string dateOfCancellation = sdr["Cancel_Date"].ToString();
                    string dateofresolve1 = string.Empty;
                    if (dateOfResolve == "")
                    {
                        dateofresolve1 = dateOfResolve;
                    }
                    else
                    {
                        dateofresolve1 = (Convert.ToDateTime(dateOfResolve).ToShortDateString()).ToString();
                    }
                    IDispute dis = DisputeFactory.CreateDispute(dispute_Id, bill_Id, customer_Id, connection_No, status, comment, problem, dateOFRaise, dateofresolve1, cancellation, dateOfCancellation);
                    DisputeList.Add(dis);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return DisputeList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewAllOpen>
        // Summary  : <To view all Open status Disputes.>
        // Input Parameters : <Null>
        // Output Parameters : <Null>
        // Return Value  : <List of Disputes having Open status.>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDispute> ViewAllOpen()
        {
            List<IDispute> DisputeList = new List<IDispute>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Viewopenstatus_teamE65";
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    long dispute_Id = Convert.ToInt64(sdr["Dispute_Id"]);
                    long bill_Id = Convert.ToInt64(sdr["Bill_Id"]);
                    string customer_Id = sdr["Customer_Id"].ToString();
                    long connection_No = Convert.ToInt64(sdr["ConnectionNo"]);
                    string status = sdr["_Status"].ToString();
                    string problem = sdr["Problem"].ToString();
                    string comment = sdr["Comment"].ToString();
                    string dateOFRaise = ((Convert.ToDateTime(sdr["Dateofraise"])).ToShortDateString()).ToString();
                    string dateOfResolve = (sdr["Dateofresolve"].ToString());
                    string cancellation = sdr["Cancel_Comment"].ToString();
                    string dateOfCancellation = sdr["Cancel_Date"].ToString();
                    string dateofresolve1 = string.Empty;
                    if (dateOfResolve == "")
                    {
                        dateofresolve1 = dateOfResolve;
                    }
                    else
                    {
                        dateofresolve1 = (Convert.ToDateTime(dateOfResolve).ToShortDateString()).ToString();
                    }
                    IDispute dis = DisputeFactory.CreateDispute(dispute_Id, bill_Id, customer_Id, connection_No, status, comment, problem, dateOFRaise, dateofresolve1, cancellation, dateOfCancellation);
                    DisputeList.Add(dis);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return DisputeList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <UpdateDispute>
        // Summary  : <To update the status of a dispute.>
        // Input Parameters : <string Customer_Id,long Dispute_Id,string Status,string Comment,string Date of Resolve>
        // Output Parameters : <Null>
        // Return Value  : <Integer>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public int UpdateDispute(string cust_Id, long disp_Id, string status, string comment, string dateOfResolve)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateDispute";
                conn.Open();
                cmd.Parameters.AddWithValue("@Customer_Id", cust_Id);
                cmd.Parameters.AddWithValue("@Dispute_Id", disp_Id);
                cmd.Parameters.AddWithValue("@_Status", status);
                cmd.Parameters.AddWithValue("@Comment", comment);
                cmd.Parameters.AddWithValue("@Dateofresolve", dateOfResolve);
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    //ClientScript.RegisterStartupScript(GetType(), "javascript1", "<script> alert('dispute id " + dispute_Id + "is updated');</script>");
                }
                return n;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <SearchByDisputeId>
        // Summary  : <To view a particular Dispute>
        // Input Parameters : <long Dispute_Id>
        // Output Parameters : <Null>
        // Return Value  : <List of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDispute> SearchByDisputeId(long disp_Id)
        {
            SqlConnection conn = null;
            List<IDispute> DisputeList = new List<IDispute>();
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SearchByDisputeId_TeamE65";
                conn.Open();
                cmd.Parameters.AddWithValue("Dispute_Id", disp_Id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    long dispute_Id = Convert.ToInt64(sdr["Dispute_Id"]);
                    long bill_Id = Convert.ToInt64(sdr["Bill_Id"]);
                    string customer_Id = sdr["Customer_Id"].ToString();
                    long connection_No = Convert.ToInt64(sdr["ConnectionNo"]);
                    string status = sdr["_Status"].ToString();
                    string problem = sdr["Problem"].ToString();
                    string comment = sdr["Comment"].ToString();
                    string dateOFRaise = ((Convert.ToDateTime(sdr["Dateofraise"])).ToShortDateString()).ToString();
                    string dateOfResolve = sdr["Dateofresolve"].ToString();
                    string cancellation = sdr["Cancel_Comment"].ToString();
                    string dateOfCancellation = sdr["Cancel_Date"].ToString();
                    string dateofresolve1 = string.Empty;
                    if (dateOfResolve == "")
                    {
                        dateofresolve1 = dateOfResolve;
                    }
                    else
                    {
                        dateofresolve1 = (Convert.ToDateTime(dateOfResolve).ToShortDateString()).ToString();
                    }
                    IDispute dis = DisputeFactory.CreateDispute(dispute_Id, bill_Id, customer_Id, connection_No, status, comment, problem, dateOFRaise, dateOfResolve, cancellation, dateOfCancellation);
                    DisputeList.Add(dis);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
            return DisputeList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <SearchByCustomerId>
        // Summary  : <To view particular customer's disputes.>
        // Input Parameters : <string Customer Id>
        // Output Parameters : <Null>
        // Return Value  : <List of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDispute> SearchByCustomerId(string cust_Id)
        {
            List<IDispute> DisputeList = new List<IDispute>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_searchbyid_TeamE65";
                conn.Open();
                cmd.Parameters.AddWithValue("Customer_Id", cust_Id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    long dispute_Id = Convert.ToInt64(sdr["Dispute_Id"]);
                    long bill_Id = Convert.ToInt64(sdr["Bill_Id"]);
                    string customer_Id = sdr["Customer_Id"].ToString();
                    long connection_Id = Convert.ToInt64(sdr["ConnectionNo"]);
                    string status = sdr["_Status"].ToString();
                    string problem = sdr["Problem"].ToString();
                    string comment = sdr["Comment"].ToString();
                    string dateOFRaise = ((Convert.ToDateTime(sdr["Dateofraise"])).ToShortDateString()).ToString();
                    string dateOfResolve = sdr["Dateofresolve"].ToString();
                    string cancellation = sdr["Cancel_Comment"].ToString();
                    string dateOfCancellation = sdr["Cancel_Date"].ToString();
                    string dateofresolve1 = string.Empty;
                    if (dateOfResolve == "")
                    {
                        dateofresolve1 = dateOfResolve;
                    }
                    else
                    {
                        dateofresolve1 = (Convert.ToDateTime(dateOfResolve).ToShortDateString()).ToString();
                    }
                    IDispute dis = DisputeFactory.CreateDispute(dispute_Id, bill_Id, customer_Id, connection_Id, status, comment, problem, dateOFRaise, dateOfResolve, cancellation, dateOfCancellation);
                    DisputeList.Add(dis);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return DisputeList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <SearchByBoth>
        // Summary  : <To search Dispute by customer_Id and dispute_Id>
        // Input Parameters : <string Customer_id,long Dispute Id>
        // Output Parameters : <Null>
        // Return Value  : <List of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDispute> SearchByBoth(string cust_Id, long disp_Id)
        {
            List<IDispute> DisputeList = new List<IDispute>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_searchbyboth_TeamE";
                conn.Open();
                cmd.Parameters.AddWithValue("Customer_Id", cust_Id);
                cmd.Parameters.AddWithValue("Dispute_Id", disp_Id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    long dispute_Id = Convert.ToInt64(sdr["Dispute_Id"]);
                    long bill_Id = Convert.ToInt64(sdr["Bill_Id"]);
                    string customer_Id = sdr["Customer_Id"].ToString();
                    long connection_Id = Convert.ToInt64(sdr["ConnectionNo"]);
                    string status = sdr["_Status"].ToString();
                    string problem = sdr["Problem"].ToString();
                    string comment = sdr["Comment"].ToString();
                    string dateOFRaise = ((Convert.ToDateTime(sdr["Dateofraise"])).ToShortDateString()).ToString();
                    string dateOfResolve = sdr["Dateofresolve"].ToString();
                    string cancellation = sdr["Cancel_Comment"].ToString();
                    string dateOfCancellation = sdr["Cancel_Date"].ToString();
                    string dateofresolve1 = string.Empty;
                    if (dateOfResolve == "")
                    {
                        dateofresolve1 = dateOfResolve;
                    }
                    else
                    {
                        dateofresolve1 = (Convert.ToDateTime(dateOfResolve).ToShortDateString()).ToString();
                    }
                    IDispute dis = DisputeFactory.CreateDispute(dispute_Id, bill_Id, customer_Id, connection_Id, status, comment, problem, dateOFRaise, dateOfResolve, cancellation, dateOfCancellation);
                    DisputeList.Add(dis);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return DisputeList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckUpdate>
        // Summary  : <To check cost in bill is updated or nor>
        // Input Parameters : <long Bill_id,string Customer_Id>
        // Output Parameters : <Null>
        // Return Value  : <Bill id>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public long CheckUpdate(long billId, string custId)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "checkupdate_teame65";
                conn.Open();
                cmd.Parameters.AddWithValue("@Bill_Id", billId);
                cmd.Parameters.AddWithValue("@Customer_Id", custId);
                long bill_id = Convert.ToInt64(cmd.ExecuteScalar());
                if (billId == bill_id)
                {
                    return bill_id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return 0;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckStatus>
        // Summary  : <To check status of dispute>
        // Input Parameters : <long Dispute_Id>
        // Output Parameters : <Null>
        // Return Value  : <Boolean>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        public bool CheckStatus(long disp_Id)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CheckStatus_TeamE65";
                conn.Open();
                cmd.Parameters.AddWithValue("Dispute_Id", disp_Id);
                string status = Convert.ToString(cmd.ExecuteScalar());
                if (status.ToUpper() == "OPEN")
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}