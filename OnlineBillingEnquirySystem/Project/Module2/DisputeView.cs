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
    public class DisputeView
    {
        [TestMethod]
        public void view()
        {
            IDispute disview = new Dispute();
            string cusid = "kumar";
            long disid = 1;
            disview.Customer_id = cusid;
            disview.Dispute_Id = disid;
            IDisputeDB objPay = DisputeDBFactory.CreateDisputeDB();
            IDispute view=objPay.View(



        }
    }
}
