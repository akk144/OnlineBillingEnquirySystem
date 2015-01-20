///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for BillItemManager Class>
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
    public class BillItemManagerFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBillItemManager>
        // Summary  : <To create object of BillItemManager class>
        // Input Parameters : None
        // Output Parameters :<Object of BillItemManager class>
        // Return Value  : <BillItemManager object>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBillItemManager CreateBillItemManager()
        {
            IBillItemManager objBillItemManager = new BillItemManager();
            return objBillItemManager;
        }
    }
}
