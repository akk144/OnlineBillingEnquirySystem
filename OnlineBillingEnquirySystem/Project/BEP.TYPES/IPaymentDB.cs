
///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by PaymentDB Class>
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
    public interface IPaymentDB
    {
        bool MakePayment(IPayment obj);
        bool IsValidCustomerId(string id);
        bool IsValidConnectionId(string cust_id,double conn_id);
        IBill GetBillDetails(string id,double conid);
        List<IPayment> ViewPayment(string id,double conid);
        List<IPayment> ViewAllPayment();
        List<IPayment> SearchPayment(string id);
        bool LoginCust(string cust_id, string password);
        bool CheckPayment(string cust_id, double conn_id);
        List<double> GetConnectionNo(string cust_id);
        List<IPayment> SearchPaymentByCon(double conid);
        string GetName(string cust_id);

    }
}
