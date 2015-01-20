using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.TYPES
{
    public interface ICustomerManager
    {
        bool LoginCust(string id,string password);
    }
}
