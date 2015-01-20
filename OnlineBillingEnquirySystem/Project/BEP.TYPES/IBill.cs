///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by Bill Class>
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
    public interface IBill
    {
        Int64 BillId
        {
            get;
            set;

        }
        string CustomerId
        {
            get;
            set;
        }
        Int64 ConnectionId
        {
            get;
            set;
        }
        double Amount
        {
            get;
            set;
        }
        DateTime GenerateDate
        {
            get;
            set;
        }
        int Year
        {
            get;
            set;
        }
        string Month
        {
            get;
            set;
        }
        double Arrears
        {
            get;
            set;
        }
        double AdvancedPayment
        {
            get;
            set;
        }
        double Discount
        {
            get;
            set;
        }
        double Total
        {
            get;
            set;
        }
    }
}
