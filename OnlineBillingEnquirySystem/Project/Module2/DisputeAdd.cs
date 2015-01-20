using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BEP.TYPES;
using BEP.BLL_FACTORY;
using BEP.BLL;
using BEP.BO;
using BEP.BO_FACTORY;
using BEP.DAL_FACTORY;
using BEP.DAL;

namespace Module2
{
    [TestClass]
    public class DisputeAdd
    {[TestMethod]
        public void add()
        {
            IDispute objDispute = new Dispute();
            long billid = 1;
            string customerid = "kumar";
            long connectionNo = 9897033110;
            long billItemid = 3;
            string status = "open";
            string problem = "hygfytgfypfyjhgy";
            string dateofraise = "10-25-2014";
            
            IDisputeDB objPay = DisputeDBFactory.CreateDisputeDB();
            long disid = objPay.add(billid, customerid, connectionNo, billItemid, status, problem, dateofraise);

            Assert.AreEqual(35,disid);
        }
    }
}
