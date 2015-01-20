using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BEP.TYPES;
using BEP.DAL_FACTORY;
using BEP.BO_FACTORY;
using BEP.BO;


namespace Dispute
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            IDispute d = DisputeFactory.CreateDispute(123456, "asd", 12, 154, "dsfsd", "dsfsd", "sdfd");
            IDisputeDB dispDB = DisputeDBFactory.CreateDisputeDB();
            
        }    
    }
}
