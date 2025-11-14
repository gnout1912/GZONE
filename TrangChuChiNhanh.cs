using GZone.QuanLyLamViec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone
{
    public partial class TrangChuChiNhanh : Form
    {
        public TrangChuChiNhanh()
        {
            InitializeComponent();
        }

        private void btnQuanLyChamCong_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyChamCong
            QuanLyChamCong frm = new QuanLyChamCong();
            frm.ShowDialog();
        }

        private void btnQuanLyCoSoVatChat_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyCoSoVatChat
            QuanLyCoSoVatChat frm = new QuanLyCoSoVatChat();
            frm.ShowDialog();
        }

        private void btnQuanLyDoanhThuChiNhanh_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyDoanhThuChiNhanh
            GZone.QuanLyDoanhThuChiNhanh.QuanLyDoanhThuChiNhanh frm = new GZone.QuanLyDoanhThuChiNhanh.QuanLyDoanhThuChiNhanh();
            frm.ShowDialog();

        }

        private void btnQuanLyGoiTap_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyGoiTap
            QuanLyGoiTap frm = new QuanLyGoiTap();
            frm.ShowDialog();
        }

        private void btnQuanLyLamViec_Click(object sender, EventArgs e)
        {
            GZone.QuanLyLamViec.Quanlylamviec frm = new Quanlylamviec();
            frm.ShowDialog();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyNhanVien
            QuanLyNhanVien frm = new QuanLyNhanVien();
            frm.ShowDialog();
        }

        private void btnQuanLyThanhVien_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyThanhVien
            //QuanLyThanhVien frm = new QuanLyThanhVien();
            // frm.ShowDialog();
            MessageBox.Show("Chức năng 'Quản lý Thành viên' đang được phát triển.");
        }
    }
}