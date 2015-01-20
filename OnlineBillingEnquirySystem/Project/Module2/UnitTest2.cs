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
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Module2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void checkupdateBillItem()
        {
            Int64 billitemid = 1;
            IBillItem billitem = BillItemFactory.createBillItem(billitemid);
            int total = 2;
            IBillItemManager billitemdb = BillItemManagerFactory.CreateBillItemManager();
            int result = billitemdb.updateBillItem(billitem);
            Assert.AreEqual(total, result);
        }

        [TestMethod]
        public void checkviewBillItem()
        {
            Int64 billitemid = 1;
            IBillItem billitem = BillItemFactory.createBillItem(billitemid);
            int total = 2;
             IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            IBillItem result = billitemmanager.viewBillItem(billitem);
            Assert.AreEqual(total, result);
        }

        [TestMethod]
        public void checkviewAllBillItemByconnection()
        {
            Int64 billitemid = 1;
            IBillItem billitem = BillItemFactory.createBillItem(billitemid);
            int total = 2;
            List<IBillItem> billitemlist = new List<IBillItem>();
           IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            billitemlist = billitemmanager.viewAllBillItembyconnection(billitem);
            Assert.AreEqual(total,billitemlist.Count);
        }

        [TestMethod]
        public void checkforUpdate()
        {
            Int64 billitemid = 1;
            IBillItem billitem = BillItemFactory.createBillItem(billitemid);
            int total = 2;
            List<IBillItem> billitemlist = new List<IBillItem>();
            IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            billitemlist = billitemmanager.checkforUpdate();
            Assert.AreEqual(total, billitemlist.Count);
        }

         [TestMethod]
        public void checkviewAllBillItem()
        {
            int total = 2;
            List<IBillItem> billitemlist = new List<IBillItem>();
            IBillItemManager billitemmanager = BillItemManagerFactory.CreateBillItemManager();
            billitemlist = billitemmanager.viewAllBillItem();
            Assert.AreEqual(total, billitemlist.Count);
        }

    }
}
