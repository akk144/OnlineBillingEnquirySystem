///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by Dispute Class>
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
using System.Threading.Tasks;

namespace BEP.TYPES
{
    public interface IDispute
    {
        long Dispute_Id { get; set; }
        long Bill_Id{ get; set; }
        string Customer_Id{ get; set; }
        long ConnectionNo{ get; set; }
        string Status{ get; set; }
       string Comment{ get; set; }
       string Problem{ get; set; }
        string DateOfRaise{ get; set; }
         string DateOfResolve{ get; set; }
       string Cancellation{ get; set; }
        string DateOfCancellation{ get; set; }
    }
}