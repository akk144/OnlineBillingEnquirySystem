using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BEP.TYPES;
using BEP.BLL_FACTORY;
using BEP.BO_FACTORY;
using BEP.DAL_FACTORY;
using BEP.BLL;
using BEP.DAL;
using BEP.BO;
using System.Collections.Generic;

namespace Module2
{
    [TestClass]
    public class GenerateBill
    {
        /*Testing view bill*/
        [TestMethod]
        public void test1()    
        {
            Int64 billid = 1;
            IBill bil = BillFactory.createBill(billid);
            int total = 1;
            IBillDB billdb = BillDBFactory.CreateBillDB();
            IBill newbill = billdb.viewBill(bil);
            Assert.AreEqual(total, newbill.Bill_ID);
        }


        /*testing viewbillby connection*/
        [TestMethod]
        public void test2()
        {
            Int64 connection = 9897033110;
            string month = "11";
            int year = 2014;
            IBill bil = BillFactory.createBill(connection,year,month);
            IBill bi = BillFactory.createBill();
            bi.Bill_ID = 1;
            IBillDB billdb = BillDBFactory.CreateBillDB();
            IBill newbill = billdb.viewBillbyconnection(bil);
            Assert.AreEqual(bi.Bill_ID, newbill.Bill_ID);
        }

        /*testing viewallbill connection*/

        [TestMethod]
        public void test3()
        {
            int count = 3;
            IBillDB billdb = BillDBFactory.CreateBillDB();
            List<IBill> newbill = billdb.viewAllBill();
            int actual = newbill.Count;
            Assert.AreEqual(count, actual);
        }

        /*testing gettotal*/

        //[TestMethod]
        //public void test4()
        //{
        //    Int64 connection = 9897033110;
        //    string month = "11";
        //    int year = 2014;
        //    IBill bil = BillFactory.createBill(connection, year, month);
        //    IBill bi = BillFactory.createBill();
        //    double Total = 234.00;
        //    IBillDB billdb = BillDBFactory.CreateBillDB();
        //    double newtotal = billdb.gettotal(bil);
        //    Assert.AreEqual(Total, newtotal);

        //}

        /*testing getadjustments*/

        //[TestMethod]
        //public void test5()
        //{
        //    string cus_id = "123456";
        //    Int64 connection = 9897033110;

        //    IBill bil = BillFactory.createBill(cus_id,connection,System.DateTime.Now,2014,"11");
        //    IBill bi = BillFactory.createBill();
        //    double Total = 234.00;
        //    IBillDB billdb = BillDBFactory.CreateBillDB();
        //    double newtotal = billdb.gettotal(bil);
        //    Assert.AreEqual(Total, newtotal);

        //}

        /*testing checkpaymode*/

        [TestMethod]
        public void test6()
        {
            string cus_id = "123456";
            Int64 connection = 9897033110;

            IBill bil = BillFactory.createBill(cus_id, connection, System.DateTime.Now, 2014, "11");
            IBill bi = BillFactory.createBill();
            string old = "cxghsfdg";
            IBillDB billdb = BillDBFactory.CreateBillDB();
            string new1 = billdb.checkdiscount(bil);
            Assert.AreEqual(old, new1);

        }


    }
}
