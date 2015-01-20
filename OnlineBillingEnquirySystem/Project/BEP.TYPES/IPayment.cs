///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by Payment Class>
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

namespace BEP.TYPES
{
    public interface IPayment
    {
        string ViewDate
        {
            get;
            set;
        }
        int Payment_Id
        {
            get;
            set;
        }
        string Customer_Id
        {
            get;
            set;
        }
        string Customer_Name
        {
            get;
            set;
        }
        double Connection_Id
        {
            get;
            set;
        }
        double Bill_Id
        {
            get;
            set;
        }
        double Bill_Amount
        {
            get;
            set;
        }
        double Payable_Amount
        {
            get;
            set;
        }
        double Advance_Amount
        {
            get;
            set;
        }
        double Arrears
        {
            get;
            set;
        }
        string Mode_Of_Payment
        {
            get;
            set;
        }
        DateTime Date
        {
            get;
            set;
        }

        string Bank_Name
        {
            get;
            set;

        }
        string Card_Type
        {
            get;
            set;
        }
        double Card_Number
        {
            get;
            set;
        }
        DateTime Expire_Date
        {
            get;
            set;
        }
        double Cvv_Number
        {
            get;
            set;
        }
        string Name_On_Card
        {
            get;
            set;
        }

    }
}
