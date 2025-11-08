using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone
{
    class clsDatabase
    {
        public static SqlConnection con;

        public static bool OpenConnection()
        {
            try
            {

                string connectionString = $"Data Source={Environment.MachineName}\\SQLEXPRESS;" + "Database=QuanLyPhongGym;" + "Integrated Security=True;" + "TrustServerCertificate=True;";

                con = new SqlConnection(connectionString);
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CloseConnection()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
