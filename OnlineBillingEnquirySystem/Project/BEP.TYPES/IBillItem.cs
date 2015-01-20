///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by BillItem Class>
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
    public enum CallType { STD, ISD, LOCAL };

    public interface IBillItem
    {
        Int64 BillItemId
        {
            get;
            set;
        }
        Int64 ConnectionId
        {
            get;
            set;
        }
        DateTime DateOfCall
        {
            get;
            set;
        }
        string Duration
        {
            get;
            set;
        }
        Int64 NumberCalled
        {
            get;
            set;
        }
        CallType CallType
        {
            get;
            set;
        }
        int Pulse
        {
            get;
            set;
        }
        double PulseRate
        {
            get;
            set;
        }
        double CallCost
        {
            get;
            set;
        }
    }
}
