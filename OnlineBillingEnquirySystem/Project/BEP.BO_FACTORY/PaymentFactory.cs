///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Create Payment Object by calling Constructor>
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
using BEP.BO;
using BEP.TYPES;

namespace BEP.BO_FACTORY
{
    public class PaymentFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreatePayment>
        // Summary  : <To create the object of payment >
        // Input Parameters : <null>
        // Output Parameters :<object of payment>
        // Return Value  : <Return object of payment>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public static IPayment CreatePayment(int payment_id, string customer_id, string customer_name, double connection_id, int bill_id, double bill_amount, double payable_amount, double advance_amount, double arrears, DateTime date2)
        {
            IPayment paymentobj = new Payment(payment_id, customer_id, customer_name, connection_id, bill_id, bill_amount, payable_amount, advance_amount, arrears, date2);
            return paymentobj;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreatePayment>
        // Summary  : <To create the object of payment >
        // Input Parameters : <null>
        // Output Parameters :<object of payment>
        // Return Value  : <Return object of payment>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public static IPayment CreatePayment(string customer_id, double connection_id, double bill_id,double payable_amount, DateTime date, string mode_of_payment, string bank_name, double card_number, string name_on_card, string card_type, DateTime expire_date, double cvv_number)
        {
            IPayment paymentobj = new Payment(customer_id, connection_id, bill_id,payable_amount, date, mode_of_payment,bank_name,card_number, name_on_card, card_type, expire_date, cvv_number);
             return paymentobj;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreatePayment>
        // Summary  : <To create the object of payment >
        // Input Parameters : <null>
        // Output Parameters :<object of payment>
        // Return Value  : <Return object of payment>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public static IPayment CreatePayment(int payment_id, string customer_id, string customer_name, double connection_id, double bill_id, double bill_amount, double payable_amount, double advance_amount, double arrears, string mode_of_payment, DateTime date, string bank_name, string card_type, double card_number, DateTime expire_date, double cvv_number, string name_on_card)
        {
            IPayment paymentobj = new Payment(payment_id, customer_id, customer_name, connection_id, bill_id, bill_amount, payable_amount, advance_amount, arrears, mode_of_payment, date, bank_name, card_type, card_number, expire_date, cvv_number, name_on_card);
            return paymentobj;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CreatePayment>
        // Summary  : <To create the object of payment >
        // Input Parameters : <null>
        // Output Parameters :<object of payment>
        // Return Value  : <Return object of payment>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public static IPayment CreatePayment()
        {
            IPayment paymentobj = new Payment();
            return paymentobj;
        }
    }
}