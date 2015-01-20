
///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the login related operations by calling the DB Functions and implementing logic as required>
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
using System.Text;
using System.Threading.Tasks;

using BEP.TYPES;
using BEP.BLL;
using BEP.DAL_FACTORY;
using BEP.DAL;
using BEP.BO_FACTORY;
using BEP.BO;

namespace BEP.BLL
{
    public class CustomerManager :ICustomerManager
    {

        public CustomerManager()
        {
        }
        //check login
        public bool LoginCust(string id ,string password)
        {
            //calling the method from 
            IPaymentDB paymentDB = PaymentDBFactory.CreatePaymentDB();
            bool b = paymentDB.LoginCust(id,password);
            return b;
        }
    }
}
