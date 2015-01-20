using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEP.TYPES;
using BEP.DAL;
using BEP.BLL;


namespace BEP.BLL_FACTORY
{
   public  class CustomerManagerFactory
    {
        public static ICustomerManager CreateCustomerManager()
        {
            ICustomerManager objCustomerManager = new CustomerManager();
            return objCustomerManager;
        } 
    }
}
