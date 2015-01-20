///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Create PaymentManager Object by calling Constructor>
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
using BEP.DAL;
using BEP.BLL;


namespace BEP.BLL_FACTORY
{
    public class PaymentManagerFactory

    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreatePaymentManager>
        // Summary  : <To create the object of payment manager>
        // Input Parameters : <null>
        // Output Parameters :<object of payment manager>
        // Return Value  : <Return object of payment manager>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IPaymentManager CreatePaymentManager()
        {
            IPaymentManager objBranchManager = new PaymentManager();
            return objBranchManager;
        }
    }
}