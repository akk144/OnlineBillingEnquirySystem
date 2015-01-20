///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by BillDB Class>
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
    public interface IBillDB
    {
        int AddBill(IBill obj);
        int UpdateBill(IBill obj);
        IBill ViewBill(IBill obj);
        List<IBill> ViewAllBill();
        IBill ViewBillByConnection(IBill obj);
        double GetTotal(IBill obj);
        string CheckDiscount(IBill obj);
        IBill GetAdjustment(IBill obj);
        int CheckConnection(IBill obj);
        List<IBill> CheckForUpdate();
        List<long> ViewConnection1(string custId);
    }
}
