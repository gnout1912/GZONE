using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone
{
    public partial class QuanLyGoiTap : Form
    {
        public QuanLyGoiTap()
        {
            InitializeComponent();
        
        }
        private void QuanLyGoiTap_Load(object sender, EventArgs e)
        {
            LoadDataGoiTap();
        }
        private void LoadDataGoiTap()
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    SqlCommand com = new SqlCommand("SELECT GT_Ma, GT_Ten, GT_Gia, GT_ThoiHan FROM Goi_Tap", clsDatabase.con);

                    SqlDataAdapter da = new SqlDataAdapter(com);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvDSGoiTap.DataSource = dt;
                    for (int i = 0; i < dgvDSGoiTap.Rows.Count; i++)
                    {
                        dgvDSGoiTap.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        private void dgvDSGoiTap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
