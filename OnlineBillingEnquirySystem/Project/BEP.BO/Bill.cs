///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Business object class of Bill containg private fields,public properties and constructors>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Saikat,Akansh>, Tata Consultancy Services
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
using BEP.TYPES;

namespace BEP.BO
{
    public class Bill : IBill
    {
        Int64 billId;
        string customerId;
        Int64 connectionId;
        double amount;
        DateTime generateDate;
        int year;
        string month;
        double arrears;
        double advancedPayment;
        double discount;
        double total;

        public Int64 BillId
        {
            get
            {
                return billId;
            }
            set
            {
                billId = value;
            }
        }
        public string CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }
        public Int64 ConnectionId
        {
            get
            {
                return connectionId;
            }
            set
            {
                connectionId = value;
            }
        }
        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
        public DateTime GenerateDate
        {
            get
            {
                return generateDate;
            }
            set
            {
                generateDate = value;
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public string Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }
        public double Arrears
        {
            get
            {
                return arrears;
            }
            set
            {
                arrears = value;
            }
        }
        public double AdvancedPayment
        {
            get
            {
                return advancedPayment;
            }
            set
            {
                advancedPayment = value;
            }
        }
        public double Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
            }
        }
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }
        public Bill(Int64 billId, string customerId, Int64 connectionId, double amount, DateTime generateDate, int year, string month, double arrears, double advancedPayment, double discount, double total)
        {
            this.billId = billId;
            this.customerId = customerId;
            this.connectionId = connectionId;
            this.amount = amount;
            this.generateDate = generateDate;
            this.year = year;
            this.month = month;
            this.arrears = arrears;
            this.advancedPayment = advancedPayment;
            this.discount = discount;
            this.total = total;
        }
        public Bill(Int64 connectionId, int year, string month)
        {
            this.connectionId = connectionId;
            this.year = year;
            this.month = month;
        }


        public Bill(Int64 billId, double amount)
        {
            this.billId = billId;
            this.amount = amount;
        }
        public Bill(double arrears, double advance)
        {
            this.arrears = arrears;
            this.advancedPayment = advance;
        }

        public Bill(string customerId, long connectionId, DateTime generateDate, int year, string month)
        {
            this.customerId = customerId;
            this.connectionId = connectionId;
            this.generateDate = generateDate;
            this.year = year;
            this.month = month;
        }
        public Bill(Int64 billId)
        {
            this.billId = billId;
        }
        public Bill()
        { }
    }
}
