///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Business object class of BillItem containg private fields,public properties and constructors>
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
using BEP.TYPES;

namespace BEP.BO
{
    public class BillItem : IBillItem
    {
        Int64 billitemId;
        Int64 connectionId;
        DateTime dateOfCall;
        string duration;
        Int64 numberCalled;
        CallType callType;
        int pulse;
        double pulseRate;
        double callCost;

        public Int64 BillItemId
        {
            get
            {
                return billitemId;
            }
            set
            {
                billitemId = value;
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
        public DateTime DateOfCall
        {
            get
            {
                return dateOfCall;
            }
            set
            {
                dateOfCall = value;
            }
        }
        public string Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        public Int64 NumberCalled
        {
            get
            {
                return numberCalled;
            }
            set
            {
                numberCalled = value;
            }
        }
        public CallType CallType
        {
            get
            {
                return callType;
            }
            set
            {
                callType = value;
            }
        }
        public int Pulse
        {
            get
            {
                return pulse;
            }
            set
            {
                pulse = value;
            }
        }
        public double PulseRate
        {
            get
            {
                return pulseRate;
            }
            set
            {
                pulseRate = value;
            }
        }
        public double CallCost
        {
            get
            {
                return callCost;
            }
            set
            {
                callCost = value;
            }
        }

        public BillItem(Int64 billitemId, Int64 connectionId, DateTime dateOfCall, string duration, Int64 numberCalled, CallType callType, int pulse, double pulseRate, double callCost)
        {
            this.billitemId = billitemId;
            this.connectionId = connectionId;
            this.dateOfCall = dateOfCall;
            this.duration = duration;
            this.numberCalled = numberCalled;
            this.callType = callType;
            this.pulse = pulse;
            this.pulseRate = pulseRate;
            this.callCost = callCost;
        }
        public BillItem()
        { }
        public BillItem(Int64 connectionId, DateTime dateOfCall)
        {
            this.connectionId = connectionId;
            this.dateOfCall = dateOfCall;
        }
        public BillItem(Int64 billitemId)
        {
            this.billitemId = billitemId;

        }
    }
}

