///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for DisputeManager Class>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Jayram,Shekhar>, Tata Consultancy Services
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
using System.Threading.Tasks;
using BEP.TYPES;
using BEP.BLL;

namespace BEP.BLL_FACTORY
{
    public class DisputeManagerFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateDisputeManager>
        // Summary  : <To Create object of DisputeManager>
        // Input Parameters : <null>
        // Output Parameters : <object of DisputeManager>
        // Return Value  : <Return object of DisputeManager>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public static IDisputeManager CreateDisputeManager()
        {
            IDisputeManager objdisputemanager = new DisputeManager();
            return objdisputemanager;
        }
    }
}