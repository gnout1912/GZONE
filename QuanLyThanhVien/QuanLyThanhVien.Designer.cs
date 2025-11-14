namespace GZone.QuanLyThanhVien
{
    partial class QuanLyThanhVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyThanhVien));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvHoiVien = new System.Windows.Forms.DataGridView();
            this.lblDSThanhVien = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnThemHoiVien = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.tabChiTiet = new System.Windows.Forms.TabControl();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnInThe = new System.Windows.Forms.Button();
            this.btnSuaThongTin = new System.Windows.Forms.Button();
            this.txtChiNhanh = new System.Windows.Forms.TextBox();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaHV = new System.Windows.Forms.TextBox();
            this.lblChiNhanh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblSdt = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMaHV = new System.Windows.Forms.Label();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnDangKyGoi = new System.Windows.Forms.Button();
            this.dgvGoiTap = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.printCardPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printCardDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.tabChiTiet.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.tabDichVu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiTap)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.dgvHoiVien);
            this.splitContainer1.Panel1.Controls.Add(this.lblDSThanhVien);
            this.splitContainer1.Panel1.Controls.Add(this.pnlSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabChiTiet);
            this.splitContainer1.Size = new System.Drawing.Size(1389, 554);
            this.splitContainer1.SplitterDistance = 729;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvHoiVien
            // 
            this.dgvHoiVien.AllowUserToAddRows = false;
            this.dgvHoiVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoiVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoiVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoiVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoiVien.Location = new System.Drawing.Point(0, 71);
            this.dgvHoiVien.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHoiVien.Name = "dgvHoiVien";
            this.dgvHoiVien.ReadOnly = true;
            this.dgvHoiVien.RowHeadersWidth = 51;
            this.dgvHoiVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoiVien.Size = new System.Drawing.Size(729, 483);
            this.dgvHoiVien.TabIndex = 2;
            this.dgvHoiVien.SelectionChanged += new System.EventHandler(this.dgvHoiVien_SelectionChanged);
            // 
            // lblDSThanhVien
            // 
            this.lblDSThanhVien.AutoSize = true;
            this.lblDSThanhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDSThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSThanhVien.Location = new System.Drawing.Point(0, 46);
            this.lblDSThanhVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDSThanhVien.Name = "lblDSThanhVien";
            this.lblDSThanhVien.Size = new System.Drawing.Size(237, 25);
            this.lblDSThanhVien.TabIndex = 1;
            this.lblDSThanhVien.Text = "Danh Sách Thành Viên";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnThemHoiVien);
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(729, 46);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnThemHoiVien
            // 
            this.btnThemHoiVien.BackColor = System.Drawing.Color.SpringGreen;
            this.btnThemHoiVien.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThemHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHoiVien.Location = new System.Drawing.Point(570, 0);
            this.btnThemHoiVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemHoiVien.Name = "btnThemHoiVien";
            this.btnThemHoiVien.Size = new System.Drawing.Size(159, 46);
            this.btnThemHoiVien.TabIndex = 2;
            this.btnThemHoiVien.Text = "(+) Thêm Hội viên";
            this.btnThemHoiVien.UseVisualStyleBackColor = false;
            this.btnThemHoiVien.Click += new System.EventHandler(this.btnThemHoiVien_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimKiem.Location = new System.Drawing.Point(427, 12);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(105, 25);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(32, 12);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(385, 22);
            this.txtTimKiem.TabIndex = 0;
            // 
            // tabChiTiet
            // 
            this.tabChiTiet.Controls.Add(this.tabThongTin);
            this.tabChiTiet.Controls.Add(this.tabDichVu);
            this.tabChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChiTiet.Location = new System.Drawing.Point(0, 0);
            this.tabChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.tabChiTiet.Name = "tabChiTiet";
            this.tabChiTiet.SelectedIndex = 0;
            this.tabChiTiet.Size = new System.Drawing.Size(655, 554);
            this.tabChiTiet.TabIndex = 0;
            // 
            // tabThongTin
            // 
            this.tabThongTin.BackColor = System.Drawing.Color.White;
            this.tabThongTin.Controls.Add(this.btnLamMoi);
            this.tabThongTin.Controls.Add(this.btnXoa);
            this.tabThongTin.Controls.Add(this.btnInThe);
            this.tabThongTin.Controls.Add(this.btnSuaThongTin);
            this.tabThongTin.Controls.Add(this.txtChiNhanh);
            this.tabThongTin.Controls.Add(this.txtGioiTinh);
            this.tabThongTin.Controls.Add(this.txtSdt);
            this.tabThongTin.Controls.Add(this.txtNgaySinh);
            this.tabThongTin.Controls.Add(this.txtHoTen);
            this.tabThongTin.Controls.Add(this.txtMaHV);
            this.tabThongTin.Controls.Add(this.lblChiNhanh);
            this.tabThongTin.Controls.Add(this.lblGioiTinh);
            this.tabThongTin.Controls.Add(this.lblSdt);
            this.tabThongTin.Controls.Add(this.lblNgaySinh);
            this.tabThongTin.Controls.Add(this.lblHoTen);
            this.tabThongTin.Controls.Add(this.lblMaHV);
            this.tabThongTin.Location = new System.Drawing.Point(4, 25);
            this.tabThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(4);
            this.tabThongTin.Size = new System.Drawing.Size(647, 525);
            this.tabThongTin.TabIndex = 0;
            this.tabThongTin.Text = "Thông tin khách hàng";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(316, 236);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(151, 39);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa Thành Viên";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnInThe
            // 
            this.btnInThe.BackColor = System.Drawing.Color.Aquamarine;
            this.btnInThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInThe.Location = new System.Drawing.Point(85, 237);
            this.btnInThe.Margin = new System.Windows.Forms.Padding(4);
            this.btnInThe.Name = "btnInThe";
            this.btnInThe.Size = new System.Drawing.Size(88, 39);
            this.btnInThe.TabIndex = 13;
            this.btnInThe.Text = "In thẻ";
            this.btnInThe.UseVisualStyleBackColor = false;
            this.btnInThe.Click += new System.EventHandler(this.btnInThe_Click);
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.BackColor = System.Drawing.Color.Aquamarine;
            this.btnSuaThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaThongTin.Location = new System.Drawing.Point(181, 237);
            this.btnSuaThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(127, 39);
            this.btnSuaThongTin.TabIndex = 12;
            this.btnSuaThongTin.Text = "Sửa thông tin";
            this.btnSuaThongTin.UseVisualStyleBackColor = false;
            this.btnSuaThongTin.Click += new System.EventHandler(this.btnSuaThongTin_Click);
            // 
            // txtChiNhanh
            // 
            this.txtChiNhanh.Location = new System.Drawing.Point(152, 190);
            this.txtChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.txtChiNhanh.Name = "txtChiNhanh";
            this.txtChiNhanh.ReadOnly = true;
            this.txtChiNhanh.Size = new System.Drawing.Size(315, 22);
            this.txtChiNhanh.TabIndex = 11;
            this.txtChiNhanh.TextChanged += new System.EventHandler(this.txtChiNhanh_TextChanged);
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(152, 151);
            this.txtGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.ReadOnly = true;
            this.txtGioiTinh.Size = new System.Drawing.Size(315, 22);
            this.txtGioiTinh.TabIndex = 10;
            this.txtGioiTinh.TextChanged += new System.EventHandler(this.txtGioiTinh_TextChanged);
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(152, 114);
            this.txtSdt.Margin = new System.Windows.Forms.Padding(4);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.ReadOnly = true;
            this.txtSdt.Size = new System.Drawing.Size(315, 22);
            this.txtSdt.TabIndex = 9;
            this.txtSdt.TextChanged += new System.EventHandler(this.txtSdt_TextChanged);
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(152, 78);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.ReadOnly = true;
            this.txtNgaySinh.Size = new System.Drawing.Size(315, 22);
            this.txtNgaySinh.TabIndex = 8;
            this.txtNgaySinh.TextChanged += new System.EventHandler(this.txtNgaySinh_TextChanged);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(152, 46);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(315, 22);
            this.txtHoTen.TabIndex = 7;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // txtMaHV
            // 
            this.txtMaHV.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaHV.Location = new System.Drawing.Point(152, 12);
            this.txtMaHV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHV.Name = "txtMaHV";
            this.txtMaHV.ReadOnly = true;
            this.txtMaHV.Size = new System.Drawing.Size(132, 22);
            this.txtMaHV.TabIndex = 6;
            this.txtMaHV.TextChanged += new System.EventHandler(this.txtMaHV_TextChanged);
            // 
            // lblChiNhanh
            // 
            this.lblChiNhanh.AutoSize = true;
            this.lblChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiNhanh.Location = new System.Drawing.Point(20, 193);
            this.lblChiNhanh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChiNhanh.Name = "lblChiNhanh";
            this.lblChiNhanh.Size = new System.Drawing.Size(81, 17);
            this.lblChiNhanh.TabIndex = 5;
            this.lblChiNhanh.Text = "Chi nhánh";
            this.lblChiNhanh.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(20, 155);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(69, 17);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính";
            this.lblGioiTinh.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblSdt
            // 
            this.lblSdt.AutoSize = true;
            this.lblSdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSdt.Location = new System.Drawing.Point(20, 118);
            this.lblSdt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSdt.Name = "lblSdt";
            this.lblSdt.Size = new System.Drawing.Size(104, 17);
            this.lblSdt.TabIndex = 3;
            this.lblSdt.Text = "Số điện thoại";
            this.lblSdt.Click += new System.EventHandler(this.lblSdt_Click);
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 81);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(82, 17);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày Sinh";
            this.lblNgaySinh.Click += new System.EventHandler(this.lblNgaySinh_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(20, 49);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(85, 17);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ Và Tên";
            this.lblHoTen.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblMaHV
            // 
            this.lblMaHV.AutoSize = true;
            this.lblMaHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHV.Location = new System.Drawing.Point(20, 16);
            this.lblMaHV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaHV.Name = "lblMaHV";
            this.lblMaHV.Size = new System.Drawing.Size(117, 17);
            this.lblMaHV.TabIndex = 0;
            this.lblMaHV.Text = "Mã Thành Viên";
            this.lblMaHV.Click += new System.EventHandler(this.lblMaHV_Click);
            // 
            // tabDichVu
            // 
            this.tabDichVu.Controls.Add(this.panel1);
            this.tabDichVu.Controls.Add(this.dgvGoiTap);
            this.tabDichVu.Location = new System.Drawing.Point(4, 25);
            this.tabDichVu.Margin = new System.Windows.Forms.Padding(4);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Padding = new System.Windows.Forms.Padding(4);
            this.tabDichVu.Size = new System.Drawing.Size(647, 525);
            this.tabDichVu.TabIndex = 1;
            this.tabDichVu.Text = "Thông tin dịch vụ";
            this.tabDichVu.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnGiaHan);
            this.panel1.Controls.Add(this.btnDangKyGoi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 482);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 39);
            this.panel1.TabIndex = 1;
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.BackColor = System.Drawing.Color.Aquamarine;
            this.btnGiaHan.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGiaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaHan.Location = new System.Drawing.Point(299, 0);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(4);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(163, 39);
            this.btnGiaHan.TabIndex = 1;
            this.btnGiaHan.Text = "Gia hạn gói tập";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnDangKyGoi
            // 
            this.btnDangKyGoi.BackColor = System.Drawing.Color.Aquamarine;
            this.btnDangKyGoi.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDangKyGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKyGoi.Location = new System.Drawing.Point(462, 0);
            this.btnDangKyGoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangKyGoi.Name = "btnDangKyGoi";
            this.btnDangKyGoi.Size = new System.Drawing.Size(177, 39);
            this.btnDangKyGoi.TabIndex = 0;
            this.btnDangKyGoi.Text = "Đăng ký gói tập mới";
            this.btnDangKyGoi.UseVisualStyleBackColor = false;
            this.btnDangKyGoi.Click += new System.EventHandler(this.btnDangKyGoi_Click);
            // 
            // dgvGoiTap
            // 
            this.dgvGoiTap.AllowUserToAddRows = false;
            this.dgvGoiTap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGoiTap.BackgroundColor = System.Drawing.Color.White;
            this.dgvGoiTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoiTap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoiTap.Location = new System.Drawing.Point(4, 4);
            this.dgvGoiTap.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGoiTap.Name = "dgvGoiTap";
            this.dgvGoiTap.ReadOnly = true;
            this.dgvGoiTap.RowHeadersWidth = 51;
            this.dgvGoiTap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoiTap.Size = new System.Drawing.Size(639, 517);
            this.dgvGoiTap.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.LawnGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLamMoi.Location = new System.Drawing.Point(524, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(94, 38);
            this.btnLamMoi.TabIndex = 15;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // printCardPreviewDialog
            // 
            this.printCardPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printCardPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printCardPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printCardPreviewDialog.Enabled = true;
            this.printCardPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printCardPreviewDialog.Icon")));
            this.printCardPreviewDialog.Name = "printCardPreviewDialog";
            this.printCardPreviewDialog.Visible = false;
            // 
            // printCardDocument
            // 
            this.printCardDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCardDocument_PrintPage);
            // 
            // QuanLyThanhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 554);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuanLyThanhVien";
            this.Text = "QuanLyThanhVien";
            this.Load += new System.EventHandler(this.QuanLyThanhVien_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.tabChiTiet.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            this.tabDichVu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiTap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnThemHoiVien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvHoiVien;
        private System.Windows.Forms.Label lblDSThanhVien;
        private System.Windows.Forms.TabControl tabChiTiet;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.Label lblChiNhanh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblSdt;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMaHV;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.TextBox txtChiNhanh;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaHV;
        private System.Windows.Forms.Button btnInThe;
        private System.Windows.Forms.Button btnSuaThongTin;
        private System.Windows.Forms.DataGridView dgvGoiTap;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnDangKyGoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.PrintPreviewDialog printCardPreviewDialog;
        private System.Drawing.Printing.PrintDocument printCardDocument;
    }
}