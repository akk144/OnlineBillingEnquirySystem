///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Payment related operations by calling the store procedures and implementing logic as required>
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BEP.TYPES;
using BEP.BO;
using BEP.BO_FACTORY;

namespace BEP.DAL
{
    public class PaymentDB:IPaymentDB
    {
        public PaymentDB() { }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <getName>
        // Summary  : <To view customer name of perticular customer id>
        // Input Parameters : <customer id>
        // Output Parameters :<customer name>
        // Return Value  : <Return customer name>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public string GetName(string cust_id)
        {
            SqlConnection connect = DBUTILITY.getConnection();
            connect.Open();
            string value="";
            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "getname";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId", cust_id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    value = reader["Name"].ToString();
                   return value;
                }
            

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
          
            return value;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <getConnectionNo>
        // Summary  : <To view connection number by id>
        // Input Parameters : <customer id>
        // Output Parameters :<List of connection numbers of perticular customer>
        // Return Value  : <Return List of connection number>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<double> GetConnectionNo(string custid)
        {
            double checkid;
            List<double> list = null; 
              SqlConnection connect = DBUTILITY.getConnection();    
                connect.Open();
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "checkconnectionid_teamE65";
                    command.Connection = connect;
                    command.Parameters.AddWithValue("@CustomerId",custid);
                    SqlDataReader reader = command.ExecuteReader();
                    list = new List<double>();
                    while (reader.Read())
                    {
                        checkid = Convert.ToDouble(reader[0]);
                        list.Add(checkid);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in getconnection number" + e);

                }
                finally
                {
                    connect.Close();
                }
                return list;
        
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <checkPayment>
        // Summary  : <To check payment done by perticular customer id and connection number>
        // Input Parameters : <customer id,connection id>
        // Output Parameters :<True/False>
        // Return Value  : <Return flag>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public bool CheckPayment(string cust_id, double con_id)
        {
            SqlConnection connect = DBUTILITY.getConnection();
            connect.Open();
            bool value=false;
            int paymentid=0;
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_checkPayment_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId",cust_id);
                command.Parameters.AddWithValue("@ConnectionNo",con_id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    value = true;
                    paymentid = Convert.ToInt32(reader["Payment_Id"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error in check payment" + e);
            }
            finally 
            {
                connect.Close(); 
            }
            return value;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <makePayment>
        // Summary  : <To make payment by perticular customer id and connection number>
        // Input Parameters : <payment details/payment object>
        // Output Parameters :<True/False>
        // Return Value  : <Return flag>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
      public bool MakePayment(IPayment obj)
        {
            bool val = false;
            SqlConnection connect = DBUTILITY.getConnection();
                connect.Open();
           try
            {
             
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "insertpaymentdetails_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@Customer_Id", obj.Customer_Id);
                command.Parameters.AddWithValue("@Connection_Id", obj.Connection_Id);
                command.Parameters.AddWithValue("@Bill_Id", obj.Bill_Id);
                command.Parameters.AddWithValue("@Payment_amount", obj.Payable_Amount);
                command.Parameters.AddWithValue("@Payment_date", obj.Date);
                command.Parameters.AddWithValue("@Mode_of_payment", obj.Mode_Of_Payment);
                command.Parameters.AddWithValue("@Bank_name ", obj.Bank_Name);
                command.Parameters.AddWithValue("@Card_number ",obj.Card_Number);
                command.Parameters.AddWithValue("@Name_on_card",obj.Name_On_Card);
                command.Parameters.AddWithValue("@card_type",obj.Card_Type);
                command.Parameters.AddWithValue("@Expiry_date1",obj.Expire_Date);
                command.Parameters.AddWithValue("@Cvv_number",obj.Cvv_Number);
                command.Parameters.AddWithValue("@Payment_Id", 0);
               
                int a = command.ExecuteNonQuery();
                if(a>0)
                {
                    val = true;
                    return val;
                }
                else
                {
                    return val;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();

            }
          return val;
        
        }



      ///////////////////////////////////////////////////////////////////////////////////////////////
      //
      // Function Name  : <isValidCustomerId>
      // Summary  : <Check customer id exists or not>
      // Input Parameters : <customer id>
      // Output Parameters :<True/Flase>
      // Return Value  : <Return flag>
      //
      ///////////////////////////////////////////////////////////////////////////////////////////////
        public  bool IsValidCustomerId(string id)
        {
           
                //string checkid;
                bool value=false;
                 SqlConnection connect = DBUTILITY.getConnection();    
            connect.Open();
             try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "checkcustomerid_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId", id);
                 SqlDataReader reader= command.ExecuteReader();
                while(reader.Read())
                {
                   if(id.Equals(reader[0]))
                    {
                     value=true;
                     return value;
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
            return value;
        
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <isValidConnectionId>
        // Summary  : <Check connection id exists or not>
        // Input Parameters : <customer id,connection id>
        // Output Parameters :<True/Flase>
        // Return Value  : <Return flag>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public  bool IsValidConnectionId(string customerid,double id)
        {
           
                double checkid;
                bool value = false;
                SqlConnection connect = DBUTILITY.getConnection();    
                connect.Open();
             try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "checkconnectionid_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId",customerid);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    checkid = Convert.ToDouble(reader[0]);
                    if (checkid == id)
                    {
                        value = true;
                        return value;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
            return value;
        
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <getBillDetails>
        // Summary  : <To view bill amount of perticular customer id and connection number>
        // Input Parameters : <customer id,connection id>
        // Output Parameters :<Bill details of perticular customer id and connection number>
        // Return Value  : <Return bill details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public  IBill GetBillDetails(string customerid,double connectionid)
        {
              IBill billobj=null;
              SqlConnection connect = DBUTILITY.getConnection();
            connect.Open();
          
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "billdetails_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId",customerid);
                command.Parameters.AddWithValue("@ConnectionNo",connectionid);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int bill_id = Convert.ToInt32(reader["Bill_Id"]);
                    double amount = Convert.ToDouble(reader["Total_Amount"]);
                    billobj = BillFactory.CreateBill(bill_id,amount);
                    
                }
               

                connect.Close();
            
            return billobj;
        }




        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <viewPayment>
        // Summary  : <To view all payment details by customer id and connection id>
        // Input Parameters : <customer id and connection id>
        // Output Parameters :<All payment details of perticular customer id and connection id>
        // Return Value  : <Return List of payment details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<IPayment> ViewPayment(string customerid,double connectionid)
        {

            List<IPayment> paymentlist = null; 
            SqlConnection connect = DBUTILITY.getConnection();
            connect.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ViewsinglePayment_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId",customerid);
                command.Parameters.AddWithValue("@Connectionid", connectionid);
                SqlDataReader reader = command.ExecuteReader();
                paymentlist = new List<IPayment>();
                while (reader.Read())
                {
                    int payment_id = Convert.ToInt32(reader["Payment_Id"]);
                    string customer_id = reader["Customer_Id"].ToString();
                    string customer_name = reader["name"].ToString();
                    double connection_id = Convert.ToDouble(reader["Connection_Id"]);
                    int bill_id = Convert.ToInt32(reader["Bill_Id"]);
                    double bill_amount = Convert.ToDouble(reader["Total_Amount"]);
                    double payable_amount = Convert.ToDouble(reader["Payment_Amount"]);
                    double advance_amount = payable_amount-bill_amount;
                    double arrears = Convert.ToDouble("0");
                    DateTime date1 = DateTime.Parse(reader["Payment_date"].ToString());
                    string mode_of_payment=reader["Mode_of_payment"].ToString();
                    string bank_name = reader["Bank_name"].ToString();
                    string card_type = reader["card_type"].ToString();
                    double card_number = Convert.ToDouble(reader["Card_number"]);
                    DateTime expire_date = DateTime.Parse(reader["Expiry_date1"].ToString()); ;
                    double cvv_number = Convert.ToDouble(reader["Cvv_number"]);
                    string name_on_card = reader["Name_on_card"].ToString();
                    IPayment payment = PaymentFactory.CreatePayment(payment_id, customer_id, customer_name, connection_id, bill_id, bill_amount, payable_amount, advance_amount, arrears, mode_of_payment, date1, bank_name, card_type, card_number, expire_date, cvv_number, name_on_card);
      
                    paymentlist.Add(payment);
                }
                return paymentlist;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
            return paymentlist;
        
        
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <viewAllPayment>
        // Summary  : <To view all payment details>
        // Input Parameters : <null>
        // Output Parameters :<All payment details>
        // Return Value  : <Return List of payment details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<IPayment> ViewAllPayment()
        {
           
                List<IPayment> paymentlist = new List<IPayment>();

                SqlConnection connect = DBUTILITY.getConnection();
                connect.Open();
             try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ViewAllPayment_teamE65";
                command.Connection = connect;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int payment_id=Convert.ToInt32(reader["Payment_Id"]);
                    string customer_id=reader["Customer_Id"].ToString();
                    string customer_name=reader["name"].ToString();
                    double connection_id=Convert.ToDouble(reader["Connection_Id"]);
                    int bill_id=Convert.ToInt32(reader["Bill_Id"]);
                    double bill_amount=Convert.ToDouble(reader["Total_Amount"]);
                    double payable_amount=Convert.ToDouble(reader["Payment_Amount"]);
                    double advance_amount=payable_amount-bill_amount;
                    double arrears=Convert.ToDouble("0");
                    DateTime date1 = DateTime.Parse(reader["Payment_date"].ToString());
                    
                    IPayment payment=PaymentFactory.CreatePayment(payment_id,customer_id,customer_name,connection_id,bill_id,bill_amount,payable_amount,advance_amount,arrears,date1);
                    paymentlist.Add(payment);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
            return  paymentlist;
        
        
        }




        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <searchPayment>
        // Summary  : <To view all payment details by customer id>
        // Input Parameters : <customer id>
        // Output Parameters :<All payment details of perticular customer id>
        // Return Value  : <Return List of payment details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<IPayment> SearchPayment(string customerid)
        {
            List<IPayment> paymentlist = new List<IPayment>();
            SqlConnection connect = DBUTILITY.getConnection();
            connect.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ViewSearchPayment_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId",customerid);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int payment_id = Convert.ToInt32(reader["Payment_Id"]);
                    string customer_id = reader["Customer_Id"].ToString();
                    string customer_name = reader["name"].ToString();
                    double connection_id = Convert.ToDouble(reader["Connection_Id"]);
                    int bill_id = Convert.ToInt32(reader["Bill_Id"]);
                    double bill_amount = Convert.ToDouble(reader["Total_Amount"]);
                    double payable_amount = Convert.ToDouble(reader["Payment_Amount"]);
                    double advance_amount = payable_amount-bill_amount;
                    double arrears = Convert.ToDouble("0");
                    DateTime date1 = DateTime.Parse(reader["Payment_date"].ToString());
                   
                    IPayment payment = PaymentFactory.CreatePayment(payment_id, customer_id, customer_name, connection_id, bill_id, bill_amount, payable_amount, advance_amount, arrears, date1);
                    paymentlist.Add(payment);
                }
               

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
            return paymentlist;
        
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <searchPaymentByCon>
        // Summary  : <To view all payment details by connection id>
        // Input Parameters : <connection id>
        // Output Parameters :<All payment details of perticular connection id>
        // Return Value  : <Return List of payment details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IPayment> SearchPaymentByCon(double conid)
        {
            List<IPayment> paymentlist = new List<IPayment>();
            SqlConnection connect = DBUTILITY.getConnection();
            connect.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ViewSearchPaymentCon_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@Connectionno",conid );
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int payment_id = Convert.ToInt32(reader["Payment_Id"]);
                    string customer_id = reader["Customer_Id"].ToString();
                    string customer_name = reader["name"].ToString();
                    double connection_id = Convert.ToDouble(reader["Connection_Id"]);
                    int bill_id = Convert.ToInt32(reader["Bill_Id"]);
                    double bill_amount = Convert.ToDouble(reader["Total_Amount"]);
                    double payable_amount = Convert.ToDouble(reader["Payment_Amount"]);
                    double advance_amount = payable_amount-bill_amount;
                    double arrears = Convert.ToDouble("0");
                    DateTime date1 = DateTime.Parse(reader["Payment_date"].ToString());
                   
                    IPayment payment = PaymentFactory.CreatePayment(payment_id, customer_id, customer_name, connection_id, bill_id, bill_amount, payable_amount, advance_amount, arrears, date1);
                    paymentlist.Add(payment);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
            return paymentlist;

        }




        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <loginCust>
        // Summary  : <Check connection id and password exists or not>
        // Input Parameters : <customer id,password>
        // Output Parameters :<True/Flase>
        // Return Value  : <Return flag>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////


        public bool LoginCust(string cust_id, string password)
        {

            //string checkid;
            bool value = false;
            SqlConnection connect = DBUTILITY.getConnection();
            connect.Open();
           
                SqlCommand command = new SqlCommand();
                try
                {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "logindetails_teamE65";
                command.Connection = connect;
                command.Parameters.AddWithValue("@CustomerId", cust_id);
                command.Parameters.AddWithValue("@Password", password);
               
               SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (cust_id.Equals(reader[0]) && password.Equals(reader[1]))
                    {
                        value = true;
                        return value;
                    }
                }
             

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                connect.Close();
            }
           
                return value;
        }


    }
}
    
