///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for DisputeDB Class>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Shekhar,Jayram> Tata Consultancy Services
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
using BEP.DAL;
using BEP.TYPES;

namespace BEP.DAL_FACTORY
{
    public class DisputeDBFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDisputeDB>
        // Summary  : <To create the object of DisputeDB >
        // Input Parameters : <null>
        // Output Parameters :<object of DisputeDB>
        // Return Value  : <Return object of DisputeDB>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        public static IDisputeDB CreateDisputeDB()
        {
            IDisputeDB objDisputeDB = new DisputeDB();
            return objDisputeDB;
        }
    }
}