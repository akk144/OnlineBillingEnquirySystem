///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for BillItemDB Class>
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
using BEP.DAL;

namespace BEP.DAL_FACTORY
{
    public class BillItemDBFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBillItemDB>
        // Summary  : <To create object of BillItemDB class>
        // Input Parameters : None
        // Output Parameters :<Object of BillItemDB class>
        // Return Value  : <BillItemDB object>
        //
        public static IBillItemDB CreateBillItemDB()
        {
            IBillItemDB objBillItemDB = new BillItemDB();
            return objBillItemDB;
        }
    }
}
