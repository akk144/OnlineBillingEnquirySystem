using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BEP.DAL
{
    class DBUTILITY
    {
        
        
        public static SqlConnection getConnection()
        {
            string connection = "Data Source=intvmsql;Initial Catalog=DB03TMS65;User id = PJ03TMS65;Password=tcstvm";
            SqlConnection conn = new SqlConnection(connection);
           // conn.ConnectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            //SqlConnection conn = new SqlConnection();
           // conn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            return conn;
        }
    }
}
