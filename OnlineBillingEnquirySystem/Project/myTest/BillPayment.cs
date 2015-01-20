///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the operations by calling the DB Functions and implementing logic as required for testing>
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BEP.TYPES;
using BEP.BLL_FACTORY;
using BEP.BLL;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.DAL_FACTORY;
using BEP.DAL;
using System.Collections;
using System.Collections.Generic;
namespace myTest
{
    [TestClass]
    public class BillPayment
    {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckGetConnectionNo1>
        // Summary  : <To view connection number by id>
        // Input Parameters : <customer id>
        // Output Parameters :<True>
        // Return Value  : <null>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]

      public void CheckGetConnectionNo1()
         {

             IPayment objPayment = new Payment();
             double connNo = 9897033914;
             string id = "C1234567";
             bool b = true;
             objPayment.Connection_Id = connNo;
             objPayment.Customer_Id = id;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             List<double> objp = objPay.GetConnectionNo(id);
             bool count = objp.Contains(9897033914);
             Assert.AreEqual(b,count);
                      
                     
              
         }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckGetConnectionNo2>
        // Summary  : <To view connection number by id>
        // Input Parameters : <customer id>
        // Output Parameters :<False>
        // Return Value  : <null>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
       [TestMethod]
        
         public void CheckGetConnectionNo2()
         {

             IPayment objPayment = new Payment();
             double connNo = 9897033110;
             string id = "C1234567";
             bool b = true;
             objPayment.Connection_Id = connNo;
             objPayment.Customer_Id = id;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             List<double> objp = objPay.GetConnectionNo(id);
             bool count = objp.Contains(98970331104);
             Assert.AreEqual(b, count);

         }


       ///////////////////////////////////////////////////////////////////////////////////////////////
       //
       // Function Name  : <CheckViewAll1>
       // Summary  : <Count no of payment details match>
       // Input Parameters : <null>
       // Output Parameters :<True>
       // Return Value  : <null>
       //
       ///////////////////////////////////////////////////////////////////////////////////////////////
        
         [TestMethod]
        public void CheckViewAll1()
         {

             int count = 1;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             List<IPayment> objp = objPay.ViewAllPayment();
             int i = objp.Count;
             Assert.AreEqual(count,i);
         }

         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckViewAll2>
         // Summary  : <Count no of payment details not match>
         // Input Parameters : <null>
         // Output Parameters :<False>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
        
       [TestMethod]
        
          public void CheckViewAll2()
         {
             int count = 3;
             
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             List<IPayment> objp = objPay.ViewAllPayment();
             int i = objp.Count;
             Assert.AreEqual(count, i);
         }

       ///////////////////////////////////////////////////////////////////////////////////////////////
       //
       // Function Name  : <CheckSearchAllPayment1>
       // Summary  : <Count no of payment details by customer id>
       // Input Parameters : <customer id>
       // Output Parameters :<True>
       // Return Value  : <null>
       //
       ///////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void CheckSearchAllPayment1()
         {
 
             string id = "C1234567";
             int count = 1;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             List<IPayment> objp = objPay.SearchPayment(id);
           
             int i = objp.Count;
             Assert.AreEqual(count, i);
         }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckSearchAllPayment2>
        // Summary  : <Count no of payment details by customer id>
        // Input Parameters : <customer id>
        // Output Parameters :<False>
        // Return Value  : <null>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
        //test fail
       public void CheckSearchAllPayment2()
         {

             
             string id = "C1234567";
             int count = 2;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             List<IPayment> objp = objPay.SearchPayment(id);
             int i = objp.Count;
             Assert.AreEqual(count, i);
         }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckViewSinglePayment1>
        // Summary  : <Count no of payment details by customer id and connection number>
        // Input Parameters : <customer id>
        // Output Parameters :<True>
        // Return Value  : <null>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
     
            //test pass
        public void CheckViewSinglePayment1()
        {
            double connNo = 9897033914;
            string id = "C1234567";
            int count = 1;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            List<IPayment> objp = objPay.ViewPayment(id,connNo);
            int i = objp.Count;
            Assert.AreEqual(count, i);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckViewSinglePayment2>
        // Summary  : <Count no of payment details by customer id and connection number>
        // Input Parameters : <customer id>
        // Output Parameters :<False>
        // Return Value  : <null>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
       
        
         [TestMethod]
        //test fail
         public void CheckViewSinglePayment2()
         {
           
             double connNo = 9897033110;
             string id = "12345";
             int count = 1;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             List<IPayment> objp = objPay.ViewPayment(id, connNo);
             int i = objp.Count;
             Assert.AreEqual(count, i);
         }


         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckCustId1>
         // Summary  : <Check customer id is exists>
         // Input Parameters : <customer id>
         // Output Parameters :<True>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
       [TestMethod]
        public void CheckCustId1()
        {
            IPayment objPayment = new Payment();
            string id = "C1234567";
            bool b = true;
            objPayment.Customer_Id = id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.IsValidCustomerId(id);

            Assert.AreEqual(b, objp);
        }


       ///////////////////////////////////////////////////////////////////////////////////////////////
       //
       // Function Name  : <CheckCustId2>
       // Summary  : <Check customer id is not exists>
       // Input Parameters : <customer id>
       // Output Parameters :<False>
       // Return Value  : <null>
       //
       ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
           public void CheckCustId2()
                {
                    IPayment objPayment = new Payment();
                    string id = "g1234567";
                    bool b = true;
                    objPayment.Customer_Id = id;
                    IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
                    bool objp = objPay.IsValidCustomerId(id);
                     Assert.AreEqual(b, objp);
                }


         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckConnectionId1>
         // Summary  : <Check connection id is exists>
         // Input Parameters : <customer id,connection id>
         // Output Parameters :<True>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
       
        public void CheckConnectionId1()
         {
             IPayment objPayment = new Payment();
             double connNo = 9897033914;
             string id = "C1234567";
             bool b = true;
             objPayment.Connection_Id = connNo;
             objPayment.Customer_Id = id;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             bool objp = objPay.IsValidConnectionId(id, connNo);

             Assert.AreEqual(b, objp);
         }

         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckConnectionId2>
         // Summary  : <Check connection id is not exists>
         // Input Parameters : <customer id,connection id>
         // Output Parameters :<False>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
        
         public void CheckConnectionId2()
         {
             IPayment objPayment = new Payment();
             double connNo = 989703311012;
             string id = "C1234567";
             bool b = true;
             objPayment.Connection_Id = connNo;
             objPayment.Customer_Id = id;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             bool objp = objPay.IsValidConnectionId(id, connNo);

             Assert.AreEqual(b, objp);
         }

         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckBillDetails1>
         // Summary  : <Check bill id is exists>
         // Input Parameters : <customer id,connection id>
         // Output Parameters :<True>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
        
        public void CheckBillDetails1()
        {
            IPayment objPayment = new Payment();
            double connNo = 9897033110;
            string id = "C1234567";
            long bill_id = 1;
            
            objPayment.Connection_Id = connNo;
            objPayment.Customer_Id = id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            IBill objp = objPay.GetBillDetails(id, connNo);

            Assert.AreEqual(bill_id, objp.BillId);
        }
         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckBillDetails2>
         // Summary  : <Check bill id is not exists>
         // Input Parameters : <customer id,connection id>
         // Output Parameters :<False>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
        public void CheckBillDetails2()
         {
             IPayment objPayment = new Payment();
             double connNo = 989703311012;
             string id = "C1234567";
             long bill_id = 1;

             objPayment.Connection_Id = connNo;
             objPayment.Customer_Id = id;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             IBill objp = objPay.GetBillDetails(id, connNo);

             Assert.AreEqual(bill_id, objp.BillId);
         }


         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckPayment1>
         // Summary  : <Check payment id is exists>
         // Input Parameters : <customer id,connection id>
         // Output Parameters :<True>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////

       [TestMethod]
     
    public void CheckPayment1()
    {
        IPayment objPayment = new Payment();
        double connNo = 9897033110;
        string id = "C1234567";
        bool b = true;
        objPayment.Connection_Id = connNo;
        objPayment.Customer_Id = id;
        IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
        bool objp = objPay.CheckPayment(id, connNo);
            
            Assert.AreEqual(b, objp);
                       
    }

       ///////////////////////////////////////////////////////////////////////////////////////////////
       //
       // Function Name  : <CheckPayment2>
       // Summary  : <Check payment id is not exists>
       // Input Parameters : <customer id,connection id>
       // Output Parameters :<True>
       // Return Value  : <null>
       //
       ///////////////////////////////////////////////////////////////////////////////////////////////
        
         [TestMethod]
       
         public void CheckPayment2()
         {
             IPayment objPayment = new Payment();
             double connNo = 9897033113;
             string id = "C123456";
             bool b = true;
             objPayment.Connection_Id = connNo;
             objPayment.Customer_Id = id;
             IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
             bool objp = objPay.CheckPayment(id, connNo);

             Assert.AreEqual(b, objp);
         }



         ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckMakePayment1>
         // Summary  : <Check payment is done successfully>
         // Input Parameters : <payment details/payment object>
         // Output Parameters :<True>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
               
       public void CheckMakePayment1()
       {

           DateTime dt =System.DateTime.Now;
           IPayment objPayment = new Payment();
           objPayment.Customer_Id = "123456";
           objPayment.Connection_Id = 9897022110;
           objPayment.Bill_Id = 1;
           objPayment.Payable_Amount = 234;
           objPayment.Date = dt;
           objPayment.Mode_Of_Payment = "Credit Card";
           objPayment.Bank_Name = "SBI";
           objPayment.Card_Number = 0;
           objPayment.Name_On_Card = "";
           objPayment.Card_Type = "";
           objPayment.Expire_Date =DateTime.Parse("01/01/2001");
           objPayment.Cvv_Number = 0;
            bool b = true;
            //IPaymentManager payment = PaymentManagerFactory.CreatePaymentManager();
             IPaymentDB objp1 = PaymentDBFactory.CreatePaymentDB();
           bool objp = objp1.MakePayment(objPayment);

           Assert.AreEqual(b, objp);
       }
        ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckLogin1>
         // Summary  : <Check id and password is correct>
         // Input Parameters : <customer id and password>
         // Output Parameters :<True>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
        public void CheckLogin1()
        {
         
            string id = "12346011";
            bool b = true;
            string password = "Shivam@011193";
        
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.LoginCust(id,password);
            Assert.AreEqual(b,objp);
        }
        
          ///////////////////////////////////////////////////////////////////////////////////////////////
         //
         // Function Name  : <CheckLogin1>
         // Summary  : <Check id and password is incorrect>
         // Input Parameters : <customer id and password>
         // Output Parameters :<False>
         // Return Value  : <null>
         //
         ///////////////////////////////////////////////////////////////////////////////////////////////
         [TestMethod]
       
        public void CheckLogin2()
        {

            string id = "C1234567";
            bool b = true;
            string password = "pinky@1/1/1993";

            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.LoginCust(id, password);
            Assert.AreEqual(b, objp);
        }
   
    }
}
