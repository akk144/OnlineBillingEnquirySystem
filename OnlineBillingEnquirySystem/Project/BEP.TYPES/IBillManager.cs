///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by BillManager Class>
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

namespace BEP.TYPES
{
    public interface IBillManager
    {
        Int64 AddBill(IBill obj);
        List<IBill> ViewAllBill();
        IBill ViewBill(IBill obj);
        int UpdateBill(IBill obj);
        Int64 GenerateBill(IBill bill);
        IBill ViewBillByConnection(IBill obj);
        double GetTotalAmount(double amount, double arrear, double advance, double discount);
        string CheckDiscount(IBill bill);
        IBill GetAdjustment(IBill bill);
        double GetAmount(IBill bill);
        int CheckConnection(IBill obj);
        List<IBill> CheckForUpdate();
        List<long> ViewConnection1(string custId);
        IBill ViewUpdateBill(IBill obj);
    }
}
