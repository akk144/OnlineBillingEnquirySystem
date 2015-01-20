///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Dispute operations by calling the DB Functions and implementing logic as required>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Jayram,Shekhar>, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History : N/A
// Change Description# : N/A
// Changed By  :N/A
// Date Modified  : N/A
// Change Description# : N/A
// Changed By  :N/A
// Date Modified  :N/A
//
///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BEP.TYPES;
using BEP.DAL_FACTORY;

namespace BEP.BLL
{
    public class DisputeManager:IDisputeManager
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
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                long x = dispDB.Add(billId, customerId, connectionNo, status, problem, dateOfRaise);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
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
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            long n = dispDB.Validate(billId, custId);
            return n;
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
            List<IDispute> DisputeList = null; ;
            //Calling the method from DB object
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                DisputeList = new List<IDispute>();
                DisputeList = dispDB.View(custId, connId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DisputeList;
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
            List<long> connection;// = null; 
            //Calling the method from DB object
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                //connection = new List<IDispute>();
                connection = dispDB.ViewConnection(custId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return connection;
        }



        public List<long> ViewConnectionAdd(string custId)
        {
            List<long> connection;
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                connection = dispDB.ViewConnectionAdd(custId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return connection;
        }

        public List<long> GetBillId(string custId,long connid)
        {
            List<long> connection;
             IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                connection = dispDB.GetBillId(custId, connid);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return connection;
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
            List<IDispute> DisputeList = null; ;
            //Calling the method from DB object
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                DisputeList = new List<IDispute>();
                DisputeList = dispDB.ViewAllDispute(custId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DisputeList;
        }

        //public int UpdateDisputebyCustomer(string customer_Id, long dispute_Id, string Cancel_Comment, string Cancel_Date)
        //{
        //    try
        //    {
        //        IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
        //       int n= dispDB.UpdateDisputebyCustomer(customer_Id, dispute_Id, Cancel_Comment, Cancel_Date);
        //       return n;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
 
        //    }
            
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <Delete>
        // Summary  : <To delete particular Dispute>
        // Input Parameters : <string Customer Id,long Dispute Id>
        // Output Parameters : <Null>
        // Return Value  : <Integer>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public int Delete(string customer_Id, long dispute_Id)
        {
            try
            {
                IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
                int x=dispDB.Delete(customer_Id, dispute_Id);
                return x;

            }
            catch (Exception ex)
            {
                throw ex;
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
            List<IDispute> DisputeList = null; 
            //Calling the method from DB object
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                DisputeList = new List<IDispute>();
                DisputeList = dispDB.ViewAll();
            }
            catch (Exception ex)
            {
                throw ex;
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
            List<IDispute> DisputeList = null;
            //Calling the method from DB object
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                DisputeList = new List<IDispute>();
                DisputeList = dispDB.ViewAllOpen();
            }
            catch (Exception ex)
            {
                throw ex;
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
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
           int n= dispDB.UpdateDispute(cust_Id,disp_Id,status,comment,dateOfResolve);
           return n;
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
            List<IDispute> DisputeList = null; 

            //Calling the method from DB object
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                DisputeList = new List<IDispute>();
                DisputeList = dispDB.SearchByDisputeId(disp_Id);
             
            }
            catch (Exception ex)
            {
                throw ex;
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
            List<IDispute> DisputeList = null; 
            //Calling the method from DB object
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                DisputeList = new List<IDispute>();
                DisputeList = dispDB.SearchByCustomerId(cust_Id);
            }
            catch (Exception ex)
            {
                throw ex;
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
            List<IDispute> DisputeList = null;

            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            try
            {
                DisputeList = new List<IDispute>();
                DisputeList = dispDB.SearchByBoth(cust_Id,disp_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DisputeList;
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
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            bool p = dispDB.CheckStatus(disp_Id);
            return p;
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
        
        public long CheckUpdate(long callId, string custId)
        {
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            long n = dispDB.CheckUpdate(callId, custId);
            return n;
        }
    }
}