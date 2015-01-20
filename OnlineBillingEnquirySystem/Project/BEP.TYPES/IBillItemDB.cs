///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Interface implemented by BillItemDB Class>
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

    public interface IBillItemDB
    {

        IBillItem ViewBillItem(IBillItem obj);
        List<IBillItem> ViewAllBillItemByConnection(IBillItem obj);
        int CheckBillItem(IBillItem obj);
    }
}
