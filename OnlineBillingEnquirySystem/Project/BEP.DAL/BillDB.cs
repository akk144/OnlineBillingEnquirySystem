﻿///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Database operations for billing processes by calling the DB Procedures>
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
    public class BillDB : IBillDB
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        ///////
        // Function Name  : <AddBill>
        // Summary  : <To add a generated bill to the database by calling the corresponding DB Stored Procedure>
        // Input Parameters : <Object of bill class>
        // Output Parameters :<Integer value billId>
        // Return Value  : <Unique value of autogenerated bill id>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public int AddBill(IBill obj)
        {
            int rows, billId;
            SqlConnection connect = null;
            try
            {
                connect = DBUTILITY.getConnection();
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "insertbill_TeamE_TMS65";
                comm.Connection = connect;
                connect.Open();
                comm.Parameters.AddWithValue("@Customer_id", obj.CustomerId);
                comm.Parameters.AddWithValue("@Connection_id", obj.ConnectionId);
                comm.Parameters.AddWithValue("@amount", obj.Amount);
                comm.Parameters.AddWithValue("@generatedate", obj.GenerateDate);
                comm.Parameters.AddWithValue("@year", obj.Year);
                comm.Parameters.AddWithValue("@month", obj.Month);
                comm.Parameters.AddWithValue("@arrears", obj.Arrears);
                comm.Parameters.AddWithValue("@advanced_payment", obj.AdvancedPayment);
                comm.Parameters.AddWithValue("@Discount_Amount", obj.Discount);
                comm.Parameters.AddWithValue("@total_amount", obj.Total);
                comm.Parameters.AddWithValue("@Bill_Id", 0);
                comm.Parameters["@Bill_Id"].Direction = ParameterDirection.Output;
                rows = comm.ExecuteNonQuery();
                billId = Convert.ToInt32(comm.Parameters["@Bill_Id"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }

            if (rows == 0)
                return rows;
            else
                return billId;

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <UpdateBill>
        // Summary  : <To update the bill amount of a bill by calling the corresponding DB Stored Procedure >
        // Input Parameters : <Object of bill class>
        // Output Parameters <integer value rowsupdated>
        // Return Value  : < number of rows updated >
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public int UpdateBill(IBill obj)
        {
            int rows;
            SqlConnection connect = null;
            try
            {

                connect = DBUTILITY.getConnection();
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "update_bill_TeamE_TMS65";
                comm.Connection = connect;
                connect.Open();
                comm.Parameters.AddWithValue("@bill_id", obj.BillId);
                comm.Parameters.AddWithValue("@Customer_id", obj.CustomerId);
                comm.Parameters.AddWithValue("@Connection_id", obj.ConnectionId);
                comm.Parameters.AddWithValue("@amount", obj.Amount);
                comm.Parameters.AddWithValue("@generatedate", obj.GenerateDate);
                comm.Parameters.AddWithValue("@year", obj.Year);
                comm.Parameters.AddWithValue("@month", obj.Month);
                comm.Parameters.AddWithValue("@arrears", obj.Arrears);
                comm.Parameters.AddWithValue("@advanced_payment", obj.AdvancedPayment);
                comm.Parameters.AddWithValue("@Discount_Amount", obj.Discount);
                comm.Parameters.AddWithValue("@total_amount", obj.Total);
                rows = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }

            return rows;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewBill>
        // Summary  : <To view a particular bill by its billid by calling the corresponding DB Stored Procedure>
        // Input Parameters : <Object of bill class containing bill id>
        // Output Parameters <Object of the bill class>
        // Return Value  : < Entire Bill details >
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public IBill ViewBill(IBill obj)
        {
            IBill bill = null;
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "view_bill_teamE_TMS_65";
                conn.Open();
                cmd.Parameters.AddWithValue("@bill_id", obj.BillId);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Int64 billId = Convert.ToInt64(sdr["Bill_Id"]);
                    string customerId = sdr["CustomerId"].ToString();
                    Int64 connectionId = Convert.ToInt64(sdr["ConnectionNo"]);
                    double amount = Convert.ToDouble(sdr["Amount"]);
                    DateTime generationDate = Convert.ToDateTime(sdr["GenerationDate"]);
                    int year = Convert.ToInt32(sdr["_year"]);
                    string month = sdr["_month"].ToString();
                    double arrears = Convert.ToDouble(sdr["Arrears"]);
                    double advance = Convert.ToDouble(sdr["Advanced_Payment"]);
                    double discount = Convert.ToDouble(sdr["Discount_Amount"]);
                    double totalAmount = Convert.ToDouble(sdr["Total_Amount"]);
                    bill = BillFactory.CreateBill(billId, customerId, connectionId, amount, generationDate, year, month, arrears, advance, discount, totalAmount);
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
            return bill;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckForUpdate>
        // Summary  : <To check the number of bills that needs to be updated by calling the corresponding DB Stored Procedure>
        // Input Parameters : N/A
        // Output Parameters :<List of all the bills that needs to be updated>
        // Return Value  : <List of bills with details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<IBill> CheckForUpdate()
        {
            List<IBill> billList = new List<IBill>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "check_for_updatebill_teamE_TMS_65";
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Int64 billId = Convert.ToInt64(sdr["Bill_Id"]);
                    string customerId = sdr["CustomerId"].ToString();
                    Int64 connectionId = Convert.ToInt64(sdr["ConnectionNo"]);
                    Double amount = Convert.ToDouble(sdr["Amount"]);
                    DateTime dateOfCall = Convert.ToDateTime(sdr["GenerationDate"]);
                    int year = Convert.ToInt32(sdr["_year"]);
                    string month = sdr["_month"].ToString();
                    double arrears = Convert.ToDouble(sdr["Arrears"]);
                    double advancedPayment = Convert.ToDouble(sdr["Advanced_Payment"]);
                    double discount = Convert.ToDouble(sdr["Discount_Amount"]);
                    double total = Convert.ToDouble(sdr["Total_Amount"]);
                    IBill bill = BillFactory.CreateBill(billId, customerId, connectionId, amount, dateOfCall, year, month, arrears, advancedPayment, discount, total);
                    billList.Add(bill);
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
            return billList;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewBillByConnection>
        // Summary  : <To view a particular bill based on connection number and year/month by calling the corresponding DB Stored Procedure>
        // Input Parameters : <Object of bill class containing connection number,year,month>
        // Output Parameters <Object of the bill class>
        // Return Value  : < Entire Bill details >
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public IBill ViewBillByConnection(IBill obj)
        {
            IBill bill = null;
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "viewAll_bill_by_connection_teamE_TMS_65";
                conn.Open();
                cmd.Parameters.AddWithValue("@connectionNo", obj.ConnectionId);
                cmd.Parameters.AddWithValue("@month", obj.Month.ToString());
                cmd.Parameters.AddWithValue("@year", obj.Year.ToString());
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Int64 billId = Convert.ToInt64(sdr["Bill_Id"]);
                    string customerId = sdr["CustomerId"].ToString();
                    Int64 connectionId = Convert.ToInt64(sdr["ConnectionNo"]);
                    double amount = Convert.ToDouble(sdr["Amount"]);
                    DateTime generationDate = Convert.ToDateTime(sdr["GenerationDate"]);
                    int year = Convert.ToInt32(sdr["_year"]);
                    string month = sdr["_month"].ToString();
                    double arrears = Convert.ToDouble(sdr["Arrears"]);
                    double advance = Convert.ToDouble(sdr["Advanced_Payment"]);
                    double discount = Convert.ToDouble(sdr["Discount_Amount"]);
                    double totalAmount = Convert.ToDouble(sdr["Total_Amount"]);
                    bill = BillFactory.CreateBill(billId, customerId, connectionId, amount, generationDate, year, month, arrears, advance, discount, totalAmount);
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
            return bill;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckConnection>
        // Summary  : <To check if a particular connection number exists and is active by calling the corresponding DBFunction>
        // Input Parameters : <Object of bill class containing connection number>
        // Output Parameters <integer value flag>
        // Return Value  : < 0/1 >
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public int CheckConnection(IBill obj)
        {
            int isValid = 0;
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "check_connection_teamE_TMS_65";
                conn.Open();
                cmd.Parameters.AddWithValue("@connection_id", obj.ConnectionId);
                isValid = Convert.ToInt32(cmd.ExecuteNonQuery());

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
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewAllBill>
        // Summary  : <To view all the generated bills from the database by calling the corresponding DB Stored Procedure>
        // Input Parameters : None
        // Output Parameters <List of all the bills>
        // Return Value  : <List of all Bills with details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<IBill> ViewAllBill()
        {
            List<IBill> billList = new List<IBill>();
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "viewAll_bill_teamE_TMS_65";
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Int64 billId = Convert.ToInt64(sdr["Bill_Id"]);
                    string customerId = sdr["CustomerId"].ToString();
                    Int64 connectionId = Convert.ToInt64(sdr["ConnectionNo"]);
                    double amount = Convert.ToDouble(sdr["Amount"]);
                    DateTime generationDate = Convert.ToDateTime(sdr["GenerationDate"]);
                    int year = Convert.ToInt32(sdr["_year"]);
                    string month = sdr["_month"].ToString();
                    double arrears = Convert.ToDouble(sdr["Arrears"]);
                    double advance = Convert.ToDouble(sdr["Advanced_Payment"]);
                    double discount = Convert.ToDouble(sdr["Discount_Amount"]);
                    double totalAmount = Convert.ToDouble(sdr["Total_Amount"]);
                    IBill bill = BillFactory.CreateBill(billId, customerId, connectionId, amount, generationDate, year, month, arrears, advance, discount, totalAmount);
                    billList.Add(bill);
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
            return billList;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <GetTotal>
        // Summary  : <To get the amount of the bill by making the sum of all the bill items respective to that bill by calling the respective DB Procedure>
        // Input Parameters : <Object of bill class containing customer id,connection Number,year,month and generation date>
        // Output Parameters <Double value amount>
        // Return Value  : <Total amount of the bill which is the sum of all call costs>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public double GetTotal(IBill obj)
        {
            double total;
            SqlConnection connect = null;
            try
            {

                connect = DBUTILITY.getConnection();
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "get_amt_teamE_TMS_65";
                comm.Connection = connect;
                connect.Open();
                comm.Parameters.AddWithValue("@connectionNo", obj.ConnectionId);
                comm.Parameters.AddWithValue("@year", obj.Year.ToString());
                comm.Parameters.AddWithValue("@month", obj.Month.ToString());
                total = Convert.ToDouble(comm.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
            return total;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckDiscount>
        // Summary  : <To find the mode of payment by calling the DB Procedure>
        // Input Parameters : <Object of bill class containing customer id,connection Number,year,month and generation date>
        // Output Parameters <String value paymode>
        // Return Value  : <Payment mode value>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public string CheckDiscount(IBill obj)
        {
            string paymode;
            SqlConnection connect = null;
            try
            {

                connect = DBUTILITY.getConnection();
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "check_ebill_teamE_TMS_65";
                comm.Connection = connect;
                connect.Open();
                comm.Parameters.AddWithValue("@customerid", obj.CustomerId);
                comm.Parameters.AddWithValue("@connectionNo", obj.ConnectionId);
                paymode = (comm.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }

            return paymode;

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <GetAdjustment>
        // Summary  : <To get the arrears and advance payments of the bill>
        // Input Parameters : <Object of bill class containing customer id,connection Number,year,month and generation date>
        // Output Parameters <Object of bill class containing arrears and advance payments>
        // Return Value  : <Arrears and advance payments value>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public IBill GetAdjustment(IBill obj)
        {
            IBill bill = null;
            SqlConnection conn = null;
            try
            {
                conn = DBUTILITY.getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "get_asjustment_teamE_TMS_65";
                conn.Open();
                cmd.Parameters.AddWithValue("@customerid", obj.CustomerId);
                cmd.Parameters.AddWithValue("@connectionNo", obj.ConnectionId);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    double arrears = Convert.ToDouble(sdr["Arrears"]);
                    double advance = Convert.ToDouble(sdr["Advanced_Payment"]);
                    bill = BillFactory.CreateBill(arrears, advance);
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
            return bill;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewConnection1>
        // Summary  : <To populate the list of connections for a customer>
        // Input Parameters : <Customer Id>
        // Output Parameters <List of all the connections of the customer>
        // Return Value  : <List connection>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<long> ViewConnection1(string custId)
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




    }

}