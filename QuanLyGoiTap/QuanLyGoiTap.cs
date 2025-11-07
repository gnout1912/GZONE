using GZone.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone
{
    public partial class QuanLyGoiTap : Form
    {
        private GoiTapDAL _goiTapDAL;
        public QuanLyGoiTap()
        {
            InitializeComponent();
            _goiTapDAL = new GoiTapDAL();
            dgvDSGoiTap.AutoGenerateColumns = false;
        }
        private void QuanLyGoiTap_Load(object sender, EventArgs e)
        {
            LoadDataGoiTap();
        }
        private void LoadDataGoiTap()
        {
            List<GoiTap> danhSachGoiTap = _goiTapDAL.GetAllGoiTap();
            dgvDSGoiTap.DataSource = danhSachGoiTap;

            for (int i = 0; i < dgvDSGoiTap.Rows.Count; i++)
            {
                dgvDSGoiTap.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
    }
}
