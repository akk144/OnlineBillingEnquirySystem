///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Create PaymentDB Object by calling Constructor>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Subnum,Snehal>, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :N/A
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
using BEP.TYPES;
using BEP.DAL_FACTORY;
using BEP.DAL;


namespace BEP.DAL_FACTORY
{
    public class PaymentDBFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreatePaymentDB>
        // Summary  : <To create the object of PaymentDB >
        // Input Parameters : <null>
        // Output Parameters :<object of payment>
        // Return Value  : <Return object of payment>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IPaymentDB CreatePaymentDB()
        {
            IPaymentDB objPaymentDB = new PaymentDB();
            return objPaymentDB;
        }
    }
}