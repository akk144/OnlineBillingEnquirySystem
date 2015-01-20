using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BEP.TYPES;
using BEP.BLL_FACTORY;
using BEP.BLL;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.DAL_FACTORY;
using BEP.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Module2
{
    class BillPayment
    {

        //check connection id
         [TestMethod]
        public void checkConnectionId()
        {
            IPayment objPayment = new Payment();
            double connNo = 9897033110;
            string id = "123456";
            bool b=true;
            objPayment.Connection_Id = connNo;
            objPayment.Customer_Id=id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.isValidConnectionId(id,connNo);

            Assert.AreEqual(b, objp);
        } //test pass


      /* public void checkConnectionId()
        {
            IPayment objPayment = new Payment();
            double connNo = 989703311012;
            string id = "123456";
            bool b = true;
            objPayment.Connection_Id = connNo;
            objPayment.Customer_Id = id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.isValidConnectionId(id, connNo);

            Assert.AreEqual(b, objp);
        } //test fail



        //check customer id
        public void checkCustId()
        {
            IPayment objPayment = new Payment();
            string id = "123456";
            bool b = true;
            objPayment.Customer_Id = id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.isValidCustomerId(id);

            Assert.AreEqual(b, objp);
        }//pass

        public void checkCustId()
        {
            IPayment objPayment = new Payment();
            string id = "1234567";
            bool b = true;
            objPayment.Customer_Id = id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.isValidCustomerId(id);

            Assert.AreEqual(b, objp);
        }//test fail

        //check payment
        public void checkPayment()
        {
            IPayment objPayment = new Payment();
            double connNo = 9897033110;
            string id = "123456";
            bool b = true;
            objPayment.Connection_Id = connNo;
            objPayment.Customer_Id = id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.checkPayment(id, connNo);

            Assert.AreEqual(b, objp);
        } //test pass

        public void checkPayment()
        {
            IPayment objPayment = new Payment();
            double connNo = 98970331102;
            string id = "123456";
            bool b = true;
            objPayment.Connection_Id = connNo;
            objPayment.Customer_Id = id;
            IPaymentDB objPay = PaymentDBFactory.CreatePaymentDB();
            bool objp = objPay.checkPayment(id, connNo);

            Assert.AreEqual(b, objp);
        } //test fail*/

    }
}
