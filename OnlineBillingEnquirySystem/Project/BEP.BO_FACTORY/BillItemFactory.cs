///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for BillItem Class>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Saikat,Akansh> Tata Consultancy Services
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
using System.Text;
using System.Threading.Tasks;
using BEP.BO;
using BEP.TYPES;

namespace BEP.BO_FACTORY
{
    public class BillItemFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBillItem>
        // Summary  : <To create object of BillItem class>
        // Input Parameters : Int64 billItemId, Int64 connectionId, DateTime dateOfCall, string duration, Int64 numberCalled, CallType callType,int pulse, double pulseRate, double callCost
        // Output Parameters :<Object of BillItem class>
        // Return Value  : <BillItem object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBillItem CreateBillItem(Int64 billItemId, Int64 connectionId, DateTime dateOfCall, string duration, Int64 numberCalled, CallType callType,int pulse, double pulseRate, double callCost)
        {
            IBillItem billitemobj = new BillItem(billItemId, connectionId, dateOfCall, duration, numberCalled, callType, pulse, pulseRate, callCost);
            return billitemobj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBillItem>
        // Summary  : <To create object of BillItem class>
        // Input Parameters : Int64 connectionId, DateTime dateOfCall
        // Output Parameters :<Object of BillItem class>
        // Return Value  : <BillItem object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBillItem CreateBillItem(Int64 connectionId, DateTime dateOfCall)
        {
            IBillItem billitemobj = new BillItem(connectionId, dateOfCall);
            return billitemobj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBillItem>
        // Summary  : <To create object of BillItem class>
        // Input Parameters : Int64 billItemId
        // Output Parameters :<Object of BillItem class>
        // Return Value  : <BillItem object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBillItem CreateBillItem(Int64 billItemId)
        {
            IBillItem billitemobj = new BillItem(billItemId);
            return billitemobj;
        }

    }
}
