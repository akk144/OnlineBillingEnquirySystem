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

namespace Module2
{
    [TestClass]
    public class DisputeAdd
    {
        //Add Dispute
        //[TestMethod]
        //public void TestAdd()
        //{
        //    IDispute objDispute = new Dispute();
        //    long billid = 1;
        //    string customerid = "kumar";
        //    long connectionNo = 9897033110;
        //    string status = "open";
        //    string problem = "hygfytgfypfyjhgy";
        //    string dateofraise = "10-25-2014";

        //    IDisputeDB objPay = DisputeDBFactory.CreateDisputeDB();
        //    long disid = objPay.Add(billid, customerid, connectionNo, status, problem, dateofraise);

        //    Assert.AreEqual(17, disid);
        //}

        //View Dispute by customer
        //[TestMethod]
        //public void TestView()
        //{
        //    int count = 1;

        //    string cusid = "kumar";
        //    long disid = 3;
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    //disview.Customer_id = cusid;
        //    //disview.Dispute_Id = disid;
        //    List<IDispute> objd = disview.View(cusid, disid);
        //    int i = objd.Count;
        //    Assert.AreEqual(count, i);
        //}

        // view all by admin
        //[TestMethod]
        //public void TestViewAll()
        //{
        //    int count =3 ;

        //    //string cusid = "kumar";
        //    //long disid = 1;
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    List<IDispute> objd = disview.ViewAll();
        //    int i = objd.Count;
        //    Assert.AreEqual(count, i);
        //}


//        //search by customer id
        //[TestMethod]
        //public void TestView()
        //{
        //    int count = 1;

        //    string cusid = "kumar";
        //    //long disid = 1;
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();

        //    List<IDispute> objd = disview.SearchByCustomerId(cusid);
        //    int i = objd.Count;
        //    Assert.AreEqual(count, i);
        //}


        ////search by dispute id
        //[TestMethod]
        //public void TestView()
        //{
        //    string custid ="jayram";

        //    //string cusid = "kumar";
        //    long disid = 7;
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    //disview.Customer_id = cusid;
        //    //disview.Dispute_Id = disid;
        //    IDispute objd = disview.SearchByDisputeId(disid);
        //    string i = objd.Customer_id;
        //    Assert.AreEqual(custid, i);
        //}

//        //Validate the dispute id 
        //[TestMethod]
        //public void TestValidate1()
        //{
        //    long count = 1;

        //    string cusid = "kumar";
        //    long billid = 1;
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    //disview.Customer_id = cusid;
        //    //disview.Dispute_Id = disid;
        //    long objd = disview.Validate(billid, cusid);

        //    Assert.AreEqual(count, objd);
        //}

//        //Check Status by admin
        //[TestMethod]
        //public void TestCheck()
        //{
        //    long disid = 3;
        //    bool b = true;
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    bool a = disview.CheckStatus(disid);
        //    Assert.AreEqual(b, a);
        //}

       
//        //DeleteDispute by customer
        //[TestMethod]
        //public void TestDelete()
        //{
        //    int count = 1;
        //    string cusid = "kumar";
        //    long disid = 3;
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    //disview.Customer_id = cusid;
        //    //disview.Dispute_Id = disid;
        //    int x = disview.Delete(cusid, disid);

        //    Assert.AreEqual(count, x);
        //}

        //UpdateDispute by customer
        //[TestMethod]
        //public void TestUpdate1()
        //{
        //    int count = 1;
        //    string cusid = "shekhar";
        //    long disid = 2;
        //    string cancel = "abcd";
        //    string date = "10-20-2014";
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    //disview.Customer_id = cusid;
        //    //disview.Dispute_Id = disid;
        //    int x = disview.UpdateDisputebycustomer(cusid, disid, cancel, date);

        //    Assert.AreEqual(count, x);
        //}

        //UpdateDispute by admin
        //[TestMethod]
        //public void TestUpdatebyAdmin()
        //{
        //    int count = 1;
        //    string cusid = "teamE";
        //    long disid = 8;
        //    string status = "resolve";
        //    string comment = "zxcv";
        //    string date = "10-20-2014";
        //    IDisputeDB disview = DisputeDBFactory.CreateDisputeDB();
        //    //disview.Customer_id = cusid;
        //    //disview.Dispute_Id = disid;
        //    int x = disview.UpdateDispute(cusid, disid, status, comment, date);

        //    Assert.AreEqual(count, x);
        //}



    }
}
