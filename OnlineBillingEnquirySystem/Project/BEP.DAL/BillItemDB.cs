///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Database operations for bill item processes by calling the DB Procedures>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Saikat,Akansh> Tata Consultancy Services
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
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BEP.TYPES;
using BEP.BO;
using BEP.BO_FACTORY;


namespace BEP.DAL
{
    public class BillItemDB : IBillItemDB
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewBillItem>
        // Summary  : <To view a particular bill item by its id by caliing its cooresponding DB Store Procedure>
        // Input Parameters : <Object of billItem class containing id>
        // Output Parameters :<Object of billItem class>
        // Return Value  : <The entire details of the particular bill item>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public IBillItem ViewBillItem(IBillItem obj)
        {
            IBillItem billItem = null;
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "view_billitem_teamE_TMS_65";
                conn.Open();
                cmd.Parameters.AddWithValue("@billitem_id", obj.BillItemId);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Int64 connectionId = Convert.ToInt64(sdr["ConnectionNo"]);
                    DateTime dateOfCall = Convert.ToDateTime(sdr["DateofCall"]);
                    string duration = sdr["Duration"].ToString();
                    Int64 numberCalled = Convert.ToInt64(sdr["Number_called"]);
                    CallType type = (CallType)Enum.Parse(typeof(CallType), (sdr["TypeofCall"].ToString()), true);
                    double pulseRate = Convert.ToDouble(sdr["Pulse_Rate"]);
                    int pulse = Convert.ToInt16(sdr["Pulse"]);
                    double amount = Convert.ToDouble(sdr["CostofCall"]);
                    billItem = BillItemFactory.CreateBillItem(obj.BillItemId, connectionId, dateOfCall, duration, numberCalled, type, pulse, pulseRate, amount);
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
            return billItem;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewAllBillItemByConnection>
        // Summary  : <To view all the bill items of a particular connection in a particular month by caliing its cooresponding DB Stored Procedure>
        // Input Parameters : <Object of billItem class containing id and dateofcall>
        // Output Parameters : <Object of billItem class>
        // Return Value  : <Entire details of the bill items of the connection in a month>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<IBillItem> ViewAllBillItemByConnection(IBillItem obj)
        {
            List<IBillItem> billItemList = new List<IBillItem>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "viewAll_billitem_byconnection_teamE_TMS_65";
                conn.Open();
                cmd.Parameters.AddWithValue("@connectionNo", obj.ConnectionId);
                string month = (obj.DateOfCall.Month).ToString();
                string year = (obj.DateOfCall.Year).ToString();
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Int64 billItemId = Convert.ToInt64(sdr["BillItem_Id"]);
                    Int64 connectionId = Convert.ToInt64(sdr["ConnectionNo"]);
                    DateTime dateOfCall = Convert.ToDateTime(sdr["DateofCall"]);
                    string duration = sdr["Duration"].ToString();
                    Int64 numberCalled = Convert.ToInt64(sdr["Number_called"]);
                    CallType type = (CallType)Enum.Parse(typeof(CallType), (sdr["TypeofCall"].ToString()), true);
                    double pulseRate = Convert.ToDouble(sdr["Pulse_Rate"]);
                    int pulse = Convert.ToInt16(sdr["Pulse"]);
                    double amount = Convert.ToDouble(sdr["CostofCall"]);
                    IBillItem billItem = BillItemFactory.CreateBillItem(billItemId, connectionId, dateOfCall, duration, numberCalled, type, pulse, pulseRate, amount);
                    billItemList.Add(billItem);
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
            return billItemList;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckBillItem>
        // Summary  : <To check if a particular bill item exist in the database or not by caliing its cooresponding DB Stored Procedure>
        // Input Parameters : <Object of billItem class containing id>
        // Output Parameters : <Integer value isvalid>
        // Return Value  : <0 or 1>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public int CheckBillItem(IBillItem obj)
        {
            int isValid = 0;
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "check_billitem_teamE_TMS_65";
                conn.Open();
                cmd.Parameters.AddWithValue("@BillItem_id", obj.BillItemId);
                isValid=Convert.ToInt32(cmd.ExecuteNonQuery());
                
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
            return isValid;
        }
    }
}

