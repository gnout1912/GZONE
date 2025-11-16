using GZone.models;
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
        private string _maChiNhanh;
        public Quanlylamviec(string maChiNhanh)
        {
            InitializeComponent();
            _nhanVienDAL = new NhanVienDAL();
            _maChiNhanh = maChiNhanh;
        }

        private void Quanlylamviec_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {

            List<NhanVien> dsNhanVien = _nhanVienDAL.GetNhanVienByChiNhanh(_maChiNhanh);
            dgvNhanVien.DataSource = dsNhanVien;

            dgvNhanVien.Columns["Ma"].Visible = false; 
            dgvNhanVien.Columns["MaChiNhanh"].Visible = false; 

            dgvNhanVien.Columns["Ten"].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns["Ten"].Width = 200;
            dgvNhanVien.Columns["Sdt"].HeaderText = "Số Điện Thoại";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";

            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.AllowUserToAddRows = false;
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                NhanVien selectedNhanVien = dgvNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;

                if (selectedNhanVien != null)
                {
                    frmXepLichNhanVien formXepLich = new frmXepLichNhanVien(selectedNhanVien);
                    formXepLich.ShowDialog();
                }
            }
        }
    }
}