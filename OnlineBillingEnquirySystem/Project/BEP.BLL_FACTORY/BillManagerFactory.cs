///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for BillManager Class>
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
using BEP.TYPES;
using BEP.BLL;

namespace BEP.BLL_FACTORY
{
    public class BillManagerFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBillManager>
        // Summary  : <To create object of BillManager class>
        // Input Parameters : None
        // Output Parameters :<Object of BillManager class>
        // Return Value  : <BillManager object>
        //
        public static IBillManager CreateBillManager()
        {
            IBillManager objBillManager = new BillManager();
            return objBillManager;
        }
    }
}
