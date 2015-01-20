///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the Payment related operations by calling the DB Functions and implementing logic as required>
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using BEP.TYPES;
using BEP.BLL;
using BEP.DAL_FACTORY;
using BEP.DAL;
using BEP.BO_FACTORY;
using BEP.BO;


namespace BEP.BLL
{
    public class PaymentManager:IPaymentManager
    {
        

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <getConnectionNo>
        // Summary  : <To view connection number by id>
        // Input Parameters : <customer id>
        // Output Parameters :<List of connection numbers of perticular customer>
        // Return Value  : <Return List of connection number>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<double> GetConnectionNo(string customerid)
        {
            List<double> list = new List<double>();
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
           
            try
            {

                list = paymentDB.GetConnectionNo(customerid);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
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
            List<IPayment> PaymentList = null; ;
            //Calling the method from DB object
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            try
            {
                PaymentList = new List<IPayment>();
                PaymentList = paymentDB.ViewAllPayment();
            }
            catch (Exception ex)
             {
                throw ex;
            }

            return PaymentList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <searchAllPayment>
        // Summary  : <To view all payment details by customer id>
        // Input Parameters : <customer id>
        // Output Parameters :<All payment details of perticular customer id>
        // Return Value  : <Return List of payment details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public List<IPayment> SearchAllPayment(string cus_id)
        {
            List<IPayment> PaymentList = null; ;
            //Calling the method from DB object
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            try
            {
                PaymentList = new List<IPayment>();
                PaymentList = paymentDB.SearchPayment(cus_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PaymentList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <searchPaymentCon>
        // Summary  : <To view all payment details by connection id>
        // Input Parameters : <connection id>
        // Output Parameters :<All payment details of perticular connection id>
        // Return Value  : <Return List of payment details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IPayment> SearchPaymentCon(double conid)
        {
            List<IPayment> PaymentList = null; ;
            //Calling the method from DB object
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            try
            {
                PaymentList = new List<IPayment>();
                PaymentList = paymentDB.SearchPaymentByCon(conid);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PaymentList;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <viewSinglePayment>
        // Summary  : <To view all payment details by customer id and connection id>
        // Input Parameters : <customer id and connection id>
        // Output Parameters :<All payment details of perticular customer id and connection id>
        // Return Value  : <Return List of payment details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IPayment> ViewSinglePayment(string cus_id,double conid)
        {
            List<IPayment> PaymentList = null; ;
            //Calling the method from DB object
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            try
            {
                PaymentList = new List<IPayment>();
                PaymentList = paymentDB.ViewPayment(cus_id,conid);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PaymentList;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <validCustomer>
        // Summary  : <Check customer id exists or not>
        // Input Parameters : <customer id>
        // Output Parameters :<True/Flase>
        // Return Value  : <Return flag>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public bool ValidCustomer(string id)
        {
            //calling the method from 
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            bool b = paymentDB.IsValidCustomerId(id);
            return b;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <validConnection>
        // Summary  : <Check connection id exists or not>
        // Input Parameters : <customer id,connection id>
        // Output Parameters :<True/Flase>
        // Return Value  : <Return flag>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public bool ValidConnection(string id,double con_id)
        {
            //calling the method from 
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            bool b = paymentDB.IsValidConnectionId(id,con_id);
            return b;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <validBillDetails>
        // Summary  : <To view bill amount of perticular customer id and connection number>
        // Input Parameters : <customer id,connection id>
        // Output Parameters :<Bill details of perticular customer id and connection number>
        // Return Value  : <Return bill details>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public IBill ValidBillDetails(string id, double con_id)
        {
            //calling the method from 
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            IBill bill = null;
            bill = paymentDB.GetBillDetails(id,con_id);
            return bill;
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
        public bool CheckPayment(string id, double con_id)
        {
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            bool b=paymentDB.CheckPayment(id,con_id);
            return b;        
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <payment>
        // Summary  : <To make payment by perticular customer id and connection number>
        // Input Parameters : <payment details/payment object>
        // Output Parameters :<True/False>
        // Return Value  : <Return flag>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public bool Payment(IPayment obj)
        {
            //calling the method from 
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            bool b = paymentDB.MakePayment(obj);
            return b;
        }
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
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            string b = paymentDB.GetName(cust_id);
            return b;
        }
        public PaymentManager() { }
    }
    
}