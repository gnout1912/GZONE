using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone.QuanLyDoanhThuHeThong
{
    public partial class QuanLyDoanhThuHeThong : Form
    {
        public QuanLyDoanhThuHeThong()
        {
            InitializeComponent();
        }

        private void QuanLyDoanhThuHeThong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyPhongGymDataSet1.CHI_NHANH' table. You can move, or remove it, as needed.
            this.cHI_NHANHTableAdapter.Fill(this.quanLyPhongGymDataSet1.CHI_NHANH);

        }

        private void btnInDoanhThu_Click(object sender, EventArgs e)
        {

        }
    }
}
