///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Creates object for Bill Class>
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
using BEP.BO;
using BEP.TYPES;

namespace BEP.BO_FACTORY
{
    public class BillFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBill>
        // Summary  : <To create object of Bill class>
        // Input Parameters : Int64 bill_id, string customer_id, Int64 connection_id, double amount, DateTime generatedate, int year, string month, double arrears, double advanced_payment, double discount, double total
        // Output Parameters :<Object of Bill class>
        // Return Value  : <Bill object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBill CreateBill(Int64 billId, string customerId, Int64 connectionId, double amount, DateTime generateDate, int year, string month, double arrears, double advancedPayment, double discount, double total)
        {
            IBill billObj = new Bill(billId, customerId, connectionId, amount, generateDate, year, month, arrears, advancedPayment, discount, total);
            return billObj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBill>
        // Summary  : <To create object of Bill class>
        // Input Parameters : Int64 billId, double amount
        // Output Parameters :<Object of Bill class>
        // Return Value  : <Bill object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBill CreateBill(Int64 billId, double amount)
        {
            IBill billobj = new Bill(billId, amount);
            return billobj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBill>
        // Summary  : <To create object of Bill class>
        // Input Parameters : Int64 billId
        // Output Parameters :<Object of Bill class>
        // Return Value  : <Bill object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBill CreateBill(Int64 billId)
        {
            IBill billobj = new Bill(billId);
            return billobj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBill>
        // Summary  : <To create object of Bill class>
        // Input Parameters : double arrears, double advance
        // Output Parameters :<Object of Bill class>
        // Return Value  : <Bill object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBill CreateBill(double arrears, double advance)
        {
            IBill billobj = new Bill(arrears, advance);
            return billobj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBill>
        // Summary  : <To create object of Bill class>
        // Input Parameters : Int64 customerId, int year, string month
        // Output Parameters :<Object of Bill class>
        // Return Value  : <Bill object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBill CreateBill(Int64 customerId, int year, string month)
        {
            IBill billobj = new Bill(customerId, year, month);
            return billobj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBill>
        // Summary  : <To create object of Bill class>
        // Input Parameters : string cus_id, long connectionId, DateTime generatedate, int year, string month
        // Output Parameters :<Object of Bill class>
        // Return Value  : <Bill object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBill CreateBill(string customerId, long connectionId, DateTime generateDate, int year, string month)
        {
            IBill billobj = new Bill(customerId, connectionId, generateDate, year, month);
            return billobj;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreateBill>
        // Summary  : <To create object of Bill class>
        // Input Parameters : None
        // Output Parameters :<Object of Bill class>
        // Return Value  : <Bill object>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static IBill CreateBill()
        {
            IBill billobj = new Bill();
            return billobj;
        }
    }
}
