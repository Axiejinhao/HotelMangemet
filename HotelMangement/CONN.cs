using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace HotelMangement
{
     public class CONN
    {
        public static SqlConnection Myconn()
        {
            return new SqlConnection("server=.\\SQLEXPRESS; database = HotelManagementLibrary; Integrated Security = SSPI;");
        }
    }
}
