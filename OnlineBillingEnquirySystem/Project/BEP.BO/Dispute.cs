///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Business object class of Dispute containg private fields,public properties and constructors>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Jayram,Shekhar> Tata Consultancy Services
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
using System.Web;
using BEP.TYPES;

namespace BEP.BO
{
    public class Dispute:IDispute
    {
        long disputeId;
        long billId;
        string customerId;
        long connectionNo;
        string status;
        string comment;
        string problem;
        string dateOfRaise;
        string dateOfResolve;
        string cancellation;
        string dateOfCancellation;

        public long Dispute_Id
        {
            get { return disputeId; }
            set { disputeId = value; }
        }
        public long Bill_Id
        {
            get { return billId; }
            set { billId = value; }
        }
        public string Customer_Id
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public long ConnectionNo
        {
            get { return connectionNo; }
            set { connectionNo = value; }
        }     
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public string Problem
        {
            get { return problem; }
            set { problem = value; }
        }
        public string DateOfRaise
        {
            get { return dateOfRaise; }
            set { dateOfRaise = value; }
        }
        public string DateOfResolve
        {
            get { return dateOfResolve; }
            set { dateOfResolve = value; }
        }
        public string Cancellation
        {
            get { return cancellation; }
            set { cancellation = value; }
        }
        public string DateOfCancellation
        {
            get { return dateOfCancellation; }
            set { dateOfCancellation = value; }
        }
        public Dispute()
        { }
        public Dispute(long disputId,long billId, string customerId,long connectionNo,string status, string comment, string problem, string dateOFRaise, string dateOfResolve, string cancellation, string dateOfCancellation)
        {
            this.disputeId = disputId;
            this.billId = billId;
            this.customerId = customerId;
            this.connectionNo = connectionNo;
            this.status = status;
            this.comment = comment;
            this.problem = problem;
            this.dateOfRaise = dateOFRaise;
            this.dateOfResolve = dateOfResolve;
            this.cancellation = cancellation;
            this.dateOfCancellation = dateOfCancellation;
        }

        // add dispute

        public Dispute(long billId, string customerId, long connectionNo, string status, string problem, string dateofraise) 
        {

            this.billId = billId;
            this.customerId = customerId;
            this.connectionNo = connectionNo;
            this.status = status;
            this.problem = problem;
            this.dateOfRaise = dateofraise;
        }

       
        //view dispute 
        public Dispute(long dispute_Id, long billId, string customerId, long connectionNo, string status, string comment, string problem, string dateOFRaise)
        {
            this.disputeId = dispute_Id;
            this.billId = billId;
            this.customerId = customerId;
            this.connectionNo = connectionNo;
            this.status = status;
            this.comment = comment;
            this.problem = problem;
            this.dateOfRaise = dateOFRaise;
            
        }

        //view validate
        public Dispute(long billId, string customerId)
        {
            this.billId = billId;
            this.customerId = customerId;
            
        }


        public Dispute(string customerId, long disputeId)
        {
            this.customerId = customerId;
            this.disputeId = disputeId;
        }

        public Dispute(string customerId, long disputeId, string cancelComment, string cancelDate)
        {
            this.customerId = customerId;
            this.disputeId = disputeId;
            this.cancellation = cancelComment;
            this.dateOfCancellation = cancelDate;
        }
        public Dispute(string customerId, long dispId, string status, string comment, string dateOfResolve)
        {
            this.customerId = customerId;
            this.disputeId = dispId;
            this.status = status;
            this.comment = comment;
            this.dateOfResolve = dateOfResolve;
        }
        public Dispute(long dispid)
        {
            this.disputeId = dispid;
        }
        public Dispute(string customerId)
        {
            this.customerId = customerId;
        }
    }
}