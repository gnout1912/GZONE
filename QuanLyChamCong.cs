using GZone.models;
using System;
using System.Windows.Forms;

namespace GZone
{
    public partial class QuanLyChamCong : Form
    {
        private ChamCongDAL _chamCongDAL = new ChamCongDAL();

        public QuanLyChamCong()
        {
            InitializeComponent();
        }

        private void QuanLyChamCong_Load(object sender, EventArgs e)
        {
            LoadChamCong();
        }

        private void LoadChamCong()
        {
            dgvChamCong.DataSource = _chamCongDAL.GetAllChamCong();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("⚠️ Vui lòng nhập mã nhân viên!");
                return;
            }
            _chamCongDAL.CheckIn(txtMaNV.Text);
            LoadChamCong();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("⚠️ Vui lòng nhập mã nhân viên!");
                return;
            }
            _chamCongDAL.CheckOut(txtMaNV.Text);
            LoadChamCong();
        }
    }
}
