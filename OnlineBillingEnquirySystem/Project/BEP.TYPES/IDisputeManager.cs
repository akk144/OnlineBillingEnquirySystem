///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by DisputeManager Class>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Jayram,Shekhar> Tata Consultancy Services
// ---------------------------------------------------------------------------------
//  Change History :N/A
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

namespace BEP.TYPES
{
    public interface IDisputeManager
    {
        long Add(long billId, string customerId, long connectionNo, string status, string problem, string dateOfRaise);
        long Validate(long billId, string custId);
        List<IDispute> View(string custId, long connId);
        List<IDispute> ViewAllDispute(string custId);
        List<long> ViewConnectionAdd(string custId);
        List<long> GetBillId(string custId, long connid);
        List<long> ViewConnection(string custId);
        int Delete(string customerId, long disputeId);
        List<IDispute> ViewAll();
        List<IDispute> ViewAllOpen();
        int UpdateDispute(string cust_Id, long disp_Id, string status, string comment, string dateOfResolve);
        List<IDispute> SearchByDisputeId(long disp_Id);
        List<IDispute> SearchByCustomerId(string cust_Id);
        List<IDispute> SearchByBoth(string cust_Id, long disp_Id);
        //List<IDispute> ViewAllDelete();
        bool CheckStatus(long disp_Id);
        long CheckUpdate(long billId, string custId);
    }
}