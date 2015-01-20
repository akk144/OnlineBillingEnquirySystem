///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by PaymentManager Class>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Subnum,Snehal> Tata Consultancy Services
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
using System.Collections;


namespace BEP.TYPES
{
    public interface IPaymentManager
    {
        List<IPayment> ViewAllPayment();
        List<IPayment> SearchAllPayment(string cus_id);
        List<IPayment> ViewSinglePayment(string cus_id,double con_id);
        bool ValidCustomer(string id);
        bool ValidConnection(string id, double con_id);
        IBill ValidBillDetails(string id, double con_id);
        bool CheckPayment(string id, double con_id);
        bool Payment(IPayment obj);
        List<double> GetConnectionNo(string cust_id);
        List<IPayment> SearchPaymentCon(double conid);
        string GetName(string cust_id);
    }
}
