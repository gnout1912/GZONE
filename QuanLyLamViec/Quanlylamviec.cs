using GZone.models; // Thêm
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone.QuanLyLamViec
{
    public partial class Quanlylamviec : Form
    {
        private NhanVienDAL _nhanVienDAL;

        public Quanlylamviec()
        {
            InitializeComponent();
            _nhanVienDAL = new NhanVienDAL();
        }

        private void Quanlylamviec_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {
            // Lấy danh sách NV (kèm tên chi nhánh)
            List<NhanVien> dsNhanVien = _nhanVienDAL.GetAllNhanVienWithChiNhanh();
            dgvNhanVien.DataSource = dsNhanVien;

            // Cấu hình cột
            dgvNhanVien.Columns["Ma"].Visible = false; // Ẩn Mã NV
            dgvNhanVien.Columns["MaChiNhanh"].Visible = false; // Ẩn Mã CN

            dgvNhanVien.Columns["Ten"].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns["Ten"].Width = 200;
            dgvNhanVien.Columns["Sdt"].HeaderText = "Số Điện Thoại";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvNhanVien.Columns["TenChiNhanh"].HeaderText = "Chi Nhánh";

            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.AllowUserToAddRows = false;
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy nhân viên được chọn từ dòng
                NhanVien selectedNhanVien = dgvNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;

                if (selectedNhanVien != null)
                {
                    // Mở form xếp lịch và truyền nhân viên qua
                    frmXepLichNhanVien formXepLich = new frmXepLichNhanVien(selectedNhanVien);
                    formXepLich.ShowDialog();
                }
            }
        }
    }
}