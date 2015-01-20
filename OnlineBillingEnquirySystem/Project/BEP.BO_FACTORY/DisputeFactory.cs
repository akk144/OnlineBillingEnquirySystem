///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for Dispute Class>
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
using BEP.BO;
using BEP.TYPES;


namespace BEP.BO_FACTORY
{
    public class DisputeFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute()
        {
            IDispute objDispute = new Dispute();
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(long disputeId,long billId, string customerId, long connectionId, string status, string comment, string problem, string dateOfRaise, string dateOfResolve, string cancellation, string dateOfCancellation)
        {
            IDispute objDispute = new Dispute(disputeId,billId,customerId,connectionId,status,comment,problem,dateOfRaise,dateOfResolve,cancellation,dateOfCancellation);
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(long disputeId, long billId, string customerId, long connectionId, string status, string comment, string problem, string dateOFRaise)
        {
            IDispute objDispute = new Dispute(disputeId, billId, customerId, connectionId, status, comment, problem, dateOFRaise);
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(long billId, string customerId, long connectionNo, string status, string problem, string dateofraise) 
        {
            IDispute objDispute = new Dispute(billId, customerId,connectionNo, status, problem, dateofraise);
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(long callId,string custId)
        {
            IDispute objDispute = new Dispute(callId,custId);
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(string cusId, long disId)
        {
            IDispute objDispute = new Dispute(cusId,disId);
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(string customerId, long disputeId, string cancelComment, string cancelDate)
        {
            IDispute objDispute = new Dispute(customerId,disputeId,cancelComment,cancelDate);
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(string custId, long dispId, string status, string comment, string dateOfResolve)
        {
            IDispute objDispute = new Dispute(custId,dispId,status,comment,dateOfResolve);
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(long dispId)
        {
            IDispute objDispute = new Dispute();
            return objDispute;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDispute>
        // Summary  : <To create the object of Dispute >
        // Input Parameters : <null>
        // Output Parameters :<object of Dispute>
        // Return Value  : <Return object of Dispute>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IDispute CreateDispute(string custId)
        {
            IDispute objDispute = new Dispute(custId);
            return objDispute;
        }
    }
}