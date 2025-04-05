using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Chuong5
{
    internal class DAO
    {
        public static SqlConnection con = new SqlConnection();
        public static string ConnectionString =
                                "Data Source=DESKTOP-78VRNVN\\SQLEXPRESS;" +
                                "Initial Catalog=QuanLyBanHang;" +
                                "Integrated Security=True";

        public static void Connect()
        {
            con.ConnectionString = ConnectionString;
            try
            {
                if (con != null & con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Close()
        {
            try
            {
                if (con != null & con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static DataTable LoadDataToTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            adapter.Fill(dt);
            return dt;
        }

        public static string getSQLdateFromText(string dateDDMMYYYY)
        {
            string[] elemets = dateDDMMYYYY.Split('/');
            return elemets[2] + '/' + elemets[1]+ '/'+ elemets[0];

        }


    }
}
