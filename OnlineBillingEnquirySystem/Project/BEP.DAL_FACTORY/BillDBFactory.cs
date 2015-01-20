///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for BillDB Class>
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
    public class BillDBFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBillDB>
        // Summary  : <To create object of BillDB class>
        // Input Parameters : None
        // Output Parameters :<Object of BillDB class>
        // Return Value  : <BillDB object>
        //
        public static IBillDB CreateBillDB()
        {
            IBillDB objBillDB = new BillDB();
            return objBillDB;
        }
    }
}

