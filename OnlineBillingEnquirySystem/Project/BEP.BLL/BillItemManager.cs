///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <Handles all the BillItem related operations by calling the DB Functions and implementing logic as required>
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
using BEP.DAL_FACTORY;
using BEP.DAL;

namespace BEP.BLL
{
    public class BillItemManager : IBillItemManager
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewBillItem>
        // Summary  : <To view a particular bill item by its id by caliing its cooresponding DB Function>
        // Input Parameters : <Object of billItem class containing id>
        // Output Parameters :<Object of billItem class>
        // Return Value  : <The entire details of the particular bill item>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public IBillItem ViewBillItem(IBillItem obj)
        {
            IBillItem billItem = null;
            IBillItemDB billItemDBobj = BillItemDBFactory.CreateBillItemDB();
            try
            {
                billItem = billItemDBobj.ViewBillItem(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return billItem;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <CheckBillItem>
        // Summary  : <To check if a particular bill item exist in the database or not by caliing its cooresponding DB Function>
        // Input Parameters : <Object of billItem class containing id>
        // Output Parameters : <Integer value isvalid>
        // Return Value  : <0 or 1>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public int CheckBillItem(IBillItem obj)
        {
            int isvalid = 0;
            IBillItemDB billItemDBobj = BillItemDBFactory.CreateBillItemDB();
            try
            {
                isvalid = billItemDBobj.CheckBillItem(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isvalid;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <ViewAllBillItemByConnection>
        // Summary  : <To view all the bill items of a particular connection in a particular month by caliing its cooresponding DB Function>
        // Input Parameters : <Object of billItem class containing id and dateofcall>
        // Output Parameters : <Object of billItem class>
        // Return Value  : <Entire details of the bill items of the connection in a month>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public List<IBillItem> ViewAllBillItemByConnection(IBillItem billitem)
        {
            List<IBillItem> BillItemList = null;
            IBillItemDB billItemDBobj = BillItemDBFactory.CreateBillItemDB();
            try
            {
                BillItemList = new List<IBillItem>();
                BillItemList = billItemDBobj.ViewAllBillItemByConnection(billitem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BillItemList;
        }      
    }
}
