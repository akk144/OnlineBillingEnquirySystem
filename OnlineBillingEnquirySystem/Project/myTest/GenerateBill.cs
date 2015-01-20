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
        /*testing addbill*/
      
        [TestMethod]
        public void Test1()
        {
            string cus_id = "C1234567";
            Int64 connection = 9897033350;
            double amount = 500;
            DateTime generatedate = System.DateTime.Now;
            int year = 2014;
            string month = "3";
            double arrears=30;
            double advance=10;
            double discount=10;
            double totalamount=510;
            IBill bil = BillFactory.CreateBill(0,cus_id,connection,amount,generatedate,year,month,arrears,advance,discount,totalamount);
            Int64 bill_id = 11;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            Int64 new1 = billdb.AddBill(bil);
            Assert.AreEqual(bill_id, new1);

        }

        /*testing addbill with invalid input */

        [TestMethod]
        public void Test1Invalid()
        {
            string cus_id = "1";
            Int64 connection = 9897033350;
            double amount = 500;
            DateTime generatedate = System.DateTime.Now;
            int year = 2014;
            string month = "3";
            double arrears = 30;
            double advance = 10;
            double discount = 10;
            double totalamount = 510;
            IBill bil = BillFactory.CreateBill(0, cus_id, connection, amount, generatedate, year, month, arrears, advance, discount, totalamount);
            Int64 bill_id = 7;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            Int64 new1 = billdb.AddBill(bil);
            Assert.AreEqual(bill_id, new1);

        }


        /*testing updatebill*/

        [TestMethod]
        public void Test2()
        {
            Int64 bill_id = 1;
            string cus_id = "C1234567";
            Int64 connection = 9897033110;
            double amount = 234.00;
            DateTime generatedate = System.DateTime.Now;
            int year = 2014;
            string month = "11";
            double arrears = 0;
            double advance = 60;
            double discount = 0;
            double totalamount = 234.00;
            IBill bil = BillFactory.CreateBill(bill_id, cus_id, connection, amount, generatedate, year, month, arrears, advance, discount, totalamount);
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            Int64 new1 = billdb.UpdateBill(bil);
            Assert.AreEqual(1, new1);

        }

        /*testing updatebill with invalid input*/

        [TestMethod]
        public void Test2Invalid()
        {
            Int64 bill_id = 1;
            string cus_id = "C12345";
            Int64 connection = 9897033110;
            double amount = 234.00;
            DateTime generatedate = System.DateTime.Now;
            int year = 2014;
            string month = "11";
            double arrears = 0;
            double advance = 60;
            double discount = 0;
            double totalamount = 234.00;
            IBill bil = BillFactory.CreateBill(bill_id, cus_id, connection, amount, generatedate, year, month, arrears, advance, discount, totalamount);
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            Int64 new1 = billdb.UpdateBill(bil);
            Assert.AreEqual(1, new1);

        }



        /*Testing view bill*/
        [TestMethod]
        public void Test3()    
        {
            Int64 billid = 1;
            IBill bil = BillFactory.CreateBill(billid);
            int total = 1;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            IBill newbill = billdb.ViewBill(bil);
            Assert.AreEqual(total, newbill.BillId);
        }

        /*Testing view bill with invalid input*/
        [TestMethod]
        public void Test3Invalid()
        {
            Int64 billid = 1;
            IBill bil = BillFactory.CreateBill(billid);
            int total = 2;
            IBillDB billdb = BillDBFactory.CreateBillDB();
            IBill newbill = billdb.ViewBill(bil);
            Assert.AreEqual(total, newbill.BillId);
        }

        /*testing viewbillby connection*/
        [TestMethod]
        public void Test4()
        {
            Int64 connection = 9897033110;
            string month = "11";
            int year = 2014;
            IBill bil = BillFactory.CreateBill(connection,year,month);
            IBill bi = BillFactory.CreateBill();
            bi.BillId = 1;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            IBill newbill = billdb.ViewBillByConnection(bil);
            Assert.AreEqual(bi.BillId, newbill.BillId);
        }

        /*testing viewbillby connection with invalid input*/
        [TestMethod]
        public void Test4Invalid()
        {
            Int64 connection = 9897033110;
            string month = "11";
            int year = 2014;
            IBill bil = BillFactory.CreateBill(connection, year, month);
            IBill bi = BillFactory.CreateBill();
            bi.BillId = 1;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            IBill newbill = billdb.ViewBillByConnection(bil);
            Assert.AreEqual(bi.BillId, newbill.BillId);
        }

        /*testing viewallbill connection*/

        [TestMethod]
        public void Test5()
        {
            int count = 9;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            List<IBill> newbill = billdb.ViewAllBill();
            int actual = newbill.Count;
            Assert.AreEqual(count, actual);
        }

        /*testing viewallbill connection with invalid input*/

        [TestMethod]
        public void Test5Invalid()
        {
            int count = 6;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            List<IBill> newbill = billdb.ViewAllBill();
            int actual = newbill.Count;
            Assert.AreEqual(count, actual);
        }
      
        /*testing gettotal*/

        [TestMethod]
        public void Test6()
        {
            Int64 connection = 9897033350;
            string month = "3";
            int year = 2014;
            IBill bil = BillFactory.CreateBill(connection, year, month);
            IBill bi = BillFactory.CreateBill();
            double Total = 650629.2092;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            double newtotal = billdb.GetAmount(bil);
            Assert.AreEqual(Total, newtotal);

        }

        /*testing gettotal with invalid input*/

        [TestMethod]
        public void Test6Invalid()
        {
            Int64 connection = 9897033350;
            string month = "4";
            int year = 2014;
            IBill bil = BillFactory.CreateBill(connection, year, month);
            IBill bi = BillFactory.CreateBill();
            double Total = 183510.8026;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            double newtotal = billdb.GetAmount(bil);
            Assert.AreEqual(Total, newtotal);

        }

        /*testing getadjustments*/

        [TestMethod]
        public void Test7()
        {
            string cus_id = "1";
            Int64 connection = 9897033110;
            IBill bil = BillFactory.CreateBill(cus_id, connection, System.DateTime.Now, 2014, "11");
            IBill bi = BillFactory.CreateBill();
            bi.Arrears = 25.5000;
            bi.AdvancedPayment = 100.00;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            IBill newbill = billdb.GetAdjustment(bil);
            Assert.AreEqual(bi.Arrears, newbill.Arrears);
            Assert.AreEqual(bi.AdvancedPayment, newbill.AdvancedPayment);

        }

        /*testing getadjustments with invalid input*/

        [TestMethod]
        public void Test7Invalid()
        {
            string cus_id = "1";
            Int64 connection = 9897033110;
            IBill bil = BillFactory.CreateBill(cus_id, connection, System.DateTime.Now, 2014, "11");
            IBill bi = BillFactory.CreateBill();
            bi.Arrears = 20.5000;
            bi.AdvancedPayment = 100.00;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            IBill newbill = billdb.GetAdjustment(bil);
            Assert.AreEqual(bi.Arrears, newbill.Arrears);
            Assert.AreEqual(bi.AdvancedPayment, newbill.AdvancedPayment);
        }

        /*testing checkpaymode*/

        [TestMethod]
        public void Test8()
        {
            string cus_id = "1234567";
            Int64 connection = 9897033902;

            IBill bil = BillFactory.CreateBill(cus_id, connection, System.DateTime.Now, 2014, "11");
            IBill bi = BillFactory.CreateBill();
            string old = "ebill";
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            string new1 = billdb.CheckDiscount(bil);
            Assert.AreEqual(old, new1);

        }

        /*testing checkpaymode with invalid input*/

        [TestMethod]
        public void Test8Invalid()
        {
            string cus_id = "1234567";
            Int64 connection = 9897033902;

            IBill bil = BillFactory.CreateBill(cus_id, connection, System.DateTime.Now, 2014, "11");
            IBill bi = BillFactory.CreateBill();
            string old = "";
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            string new1 = billdb.CheckDiscount(bil);
            Assert.AreEqual(old, new1);

        }

        /*testing getTotalAmount*/

        [TestMethod]
        public void Test9()
        {
            double arrears = 20;
            double advance = 60;
            double discount = 10;
            double amount = 500;
            double total_amount_old = 450;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            double new1 = billdb.GetTotalAmount(amount, arrears, advance, discount);
            Assert.AreEqual(total_amount_old, new1);

        }
        /*testing getTotalAmount with invalid inputs*/

        [TestMethod]
        public void Test9Invalid()
        {
            double arrears = 20;
            double advance = 60;
            double discount = 10;
            double amount = 500;
            double total_amount_old = 500;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            double new1 = billdb.GetTotalAmount(amount, arrears, advance, discount);
            Assert.AreEqual(total_amount_old, new1);

        }

        /*testing checkpaymode*/

        [TestMethod]
        public void Test10()
        {
            Int64 connection = 9897033110;
            IBill bil = BillFactory.CreateBill(connection,2014, "11");
            int old = -1;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            int new1 = billdb.CheckConnection(bil);
            Assert.AreEqual(old, new1);

        }

        [TestMethod]
        public void Test10Invalid()
        {
            Int64 connection = 989703311246;
            IBill bil = BillFactory.CreateBill(connection, 2014, "11");
            int old = -1;
            IBillManager billdb = BillManagerFactory.CreateBillManager();
            int new1 = billdb.CheckConnection(bil);
            Assert.AreEqual(old, new1);

        }



        /*testing updateBillItem with valid inputs*/

        [TestMethod]
        public void CheckUpdateBill()
        {
            Int64 billid = 3;
            IBill bill = BillFactory.CreateBill(billid);
            int total = 1;
            IBillManager billitemdb = BillManagerFactory.CreateBillManager();
            int result = billitemdb.UpdateBill(bill);
            Assert.AreEqual(total, result);
        }


        ///*testing updateBillItem with invalid inputs*/


        [TestMethod]
        public void CheckUpdateBillItemInvalid()
        {
            Int64 billid = 3;
            IBill bill = BillFactory.CreateBill(billid);
            int total = 3;
            IBillManager billitemdb = BillManagerFactory.CreateBillManager();
            int result = billitemdb.UpdateBill(bill);
            Assert.AreEqual(total, result);
        }

        /*testing viewBillItem with valid inputs*/

        [TestMethod]
        public void CheckViewBillItem()
        {
            Int64 billitemid = 3;
            IBillItem billitem = BillItemFactory.CreateBillItem(billitemid);
            Int64 connection = 9897033110;
            IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            IBillItem result = billitemmanager.ViewBillItem(billitem);
            Assert.AreEqual(connection, result.ConnectionId);
        }

        /*testing viewBillItem with invalid inputs*/

        [TestMethod]
        public void CheckViewBillItemInvalid()
        {
            Int64 billitemid = 3;
            IBillItem billitem = BillItemFactory.CreateBillItem(billitemid);
            Int64 connection = 9897033112;
            IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            IBillItem result = billitemmanager.ViewBillItem(billitem);
            Assert.AreEqual(connection, result.ConnectionId);
        }

        /*testing viewAllBillItemByconnection with valid inputs*/

        [TestMethod]
        public void CheckViewAllBillItemByConnection()
        {
            Int64 connection = 9897033110;
            DateTime date = DateTime.Parse("02/02/2014");
            IBillItem billitem = BillItemFactory.CreateBillItem(connection, date);
            int total = 1;
            List<IBillItem> billitemlist = new List<IBillItem>();
            IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            billitemlist = billitemmanager.ViewAllBillItemByConnection(billitem);
            Assert.AreEqual(total, billitemlist.Count);
        }


        /*testing viewAllBillItemByconnection with invalid inputs*/

        [TestMethod]
        public void CheckViewAllBillItemByConnectionInvalid()
        {
            Int64 connection = 9897033110;
            DateTime date = DateTime.Parse("02/01/2014");
            IBillItem billitem = BillItemFactory.CreateBillItem(connection, date);
            int total = 1;
            List<IBillItem> billitemlist = new List<IBillItem>();
            IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            billitemlist = billitemmanager.ViewAllBillItemByConnection(billitem);
            Assert.AreEqual(total, billitemlist.Count);
        }

        /*testing checkforUpdate with valid inputs*/

        [TestMethod]
        public void CheckForUpdate()
        {
            Int64 billid = 17;
            IBill bill = BillFactory.CreateBill(billid);
            int total = 1;
            List<IBill> billitemlist = new List<IBill>();
            IBillManager billmanager = BillManagerFactory.CreateBillManager();
            billitemlist = billmanager.CheckForUpdate();
            Assert.AreEqual(total, billitemlist.Count);
        }

        /*testing checkforUpdate with invalid inputs*/

        [TestMethod]
        public void CheckForUpdateInvalid()
        {
            Int64 billid = 17;
            IBill bill = BillFactory.CreateBill(billid);
            int total = 12;
            List<IBill> billitemlist = new List<IBill>();
            IBillManager billmanager = BillManagerFactory.CreateBillManager();
            billitemlist = billmanager.CheckForUpdate();
            Assert.AreEqual(total, billitemlist.Count);
        }
        /*testing viewAllBillItem with valid inputs*/

        [TestMethod]
        public void CheckViewAllBillItem()
        {
            int total = 7;
            List<IBill> billlist = new List<IBill>();
            IBillManager billmanager = BillManagerFactory.CreateBillManager();
            billlist = billmanager.ViewAllBill();
            Assert.AreEqual(total, billlist.Count);
        }

        /*testing viewAllBillItem with invalid inputs*/

        [TestMethod]
        public void CheckViewAllBillIteminvalid()
        {
            int total = 2;
            List<IBill> billlist = new List<IBill>();
            IBillManager billmanager = BillManagerFactory.CreateBillManager();
            billlist = billmanager.ViewAllBill();
            Assert.AreEqual(total, billlist.Count);
        }
    }
}
