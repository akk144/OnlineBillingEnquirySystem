///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Declare fields,Constructor,Properties>
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



namespace BEP.BO
{
    public class Payment : IPayment
    {
        public int payment_id;
        public string customer_id;
        public string customer_name;
        public double connection_id;
        public double bill_id;
        public double bill_amount;
        public double payable_amount;
        public double advance_amount;
        public double arrears;
        public string mode_of_payment;
        public DateTime date;
        public string bank_name;
        public string card_type;
        public double card_number;
        public DateTime expire_date;
        public double cvv_number;
        public string name_on_card;
        public string viewdate;




         public Payment() { }
        public Payment(int payment_id, string customer_id, string customer_name, double connection_id, double bill_id, double bill_amount, double payable_amount, double advance_amount, double arrears, string mode_of_payment, DateTime date, string bank_name, string card_type, double card_number, DateTime expire_date, double cvv_number, string name_on_card)
        {
            this.payment_id = payment_id;
            this.customer_id = customer_id;
            this.connection_id = connection_id;
            this.customer_name = customer_name;
            this.bill_id = bill_id;
            this.bill_amount = bill_amount;
            this.payable_amount = payable_amount;
            this.advance_amount = advance_amount;
            this.arrears = arrears;
            this.date = date;
            this.mode_of_payment = mode_of_payment;
            this.bank_name = bank_name;
            this.card_type = card_type;
            this.card_number = card_number;
            this.expire_date = expire_date;
            this.cvv_number = cvv_number;
            this.name_on_card = name_on_card;
        }
        public Payment(int payment_id, string customer_id, string customer_name, double connection_id, double bill_id, double bill_amount, double payable_amount, double advance_amount, double arrears, DateTime date)
        {
            this.payment_id = payment_id;
            this.customer_id = customer_id;
            this.customer_name = customer_name;
            this.connection_id = connection_id;
            this.customer_name = customer_name;
            this.bill_id = bill_id;
            this.bill_amount = bill_amount;
            this.payable_amount = payable_amount;
            this.advance_amount = advance_amount;
            this.arrears = arrears;
            this.date = date;

        }

        public Payment(string customer_id, double connection_id, double bill_id,double payable_amount, DateTime date, string mode_of_payment,string bank_name,double card_number,string name_on_card,string card_type,DateTime expire_date,double cvv_number)
        {
            this.customer_id = customer_id;
            this.connection_id = connection_id;
            this.bill_id = bill_id;
            this.payable_amount = payable_amount;
            this.date = date;
            this.mode_of_payment=mode_of_payment ;
            this.bank_name=bank_name ;
            this.card_number=card_number;
            this.name_on_card=name_on_card;
            this.card_type=card_type;
            this.expire_date=expire_date;
            this.cvv_number=cvv_number;
        }

  

      public string ViewDate
        {
            get{return viewdate;}
            set{viewdate=value;}
        }

        public int Payment_Id
        {
            get { return payment_id; }
            set { payment_id = value; }
        }
        public string Customer_Id
        {
            get { return customer_id; }
            set { customer_id = value; }
        }
        public string Customer_Name
        {
            get { return customer_name; }
            set { customer_name = value; }
        }
        public double Connection_Id
        {
            get { return connection_id; }
            set { connection_id = value; }
        }
        public double Bill_Id
        {
            get { return bill_id; }
            set { bill_id = value; }
        }
        public double Bill_Amount
        {
            get { return bill_amount; }
            set { bill_amount = value; }
        }
        public double Payable_Amount
        {
            get { return payable_amount; }
            set { payable_amount = value; }
        }
        public double Advance_Amount
        {
            get { return advance_amount; }
            set { advance_amount = value; }
        }
        public double Arrears
        {
            get { return arrears; }
            set { arrears = value; }
        }
        public string Mode_Of_Payment
        {
            get { return mode_of_payment; }
            set { mode_of_payment = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Bank_Name
        {
            get { return bank_name; }
            set { bank_name = value; }

        }
        public string Card_Type
        {
            get { return card_type; }
            set { card_type = value; }
        }
        public double Card_Number
        {
            get { return card_number; }
            set { card_number = value; }
        }
        public DateTime Expire_Date
        {
            get { return expire_date; }
            set { expire_date = value; }
        }
        public double Cvv_Number
        {
            get { return cvv_number; }
            set { cvv_number = value; }
        }
        public string Name_On_Card
        {
            get { return name_on_card; }
            set { name_on_card = value; }
        }

    
}
}