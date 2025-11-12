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
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.FlowLayoutPanel();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblSdt = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.gbChucNang = new System.Windows.Forms.GroupBox();
            this.gbGoiTap = new System.Windows.Forms.GroupBox();
            this.btnInThe = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.cboGoiTap = new System.Windows.Forms.ComboBox();
            this.lblGoiTap = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.dgvThanhVien = new System.Windows.Forms.DataGridView();
            this.lblDSThanhVien = new System.Windows.Forms.Label();
            this.dgvGoiTap = new System.Windows.Forms.DataGridView();
            this.lblGoiTapDaDK = new System.Windows.Forms.Label();
            this.printCardDocument = new System.Drawing.Printing.PrintDocument();
            this.printCardPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlTop.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.gbChucNang.SuspendLayout();
            this.gbGoiTap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiTap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(15, 125);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 29);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(15, 75);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(114, 31);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(15, 24);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 28);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(112, 135);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(142, 22);
            this.txtSdt.TabIndex = 4;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(111, 105);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(143, 24);
            this.cboGioiTinh.TabIndex = 3;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(112, 77);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(142, 22);
            this.dtpNgaySinh.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(112, 49);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(142, 22);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(112, 21);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(142, 22);
            this.txtMa.TabIndex = 0;
            this.txtMa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Controls.Add(this.gbThongTin);
            this.pnlTop.Controls.Add(this.gbChucNang);
            this.pnlTop.Controls.Add(this.gbGoiTap);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(800, 180);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.lblSdt);
            this.gbThongTin.Controls.Add(this.lblGioiTinh);
            this.gbThongTin.Controls.Add(this.lblNgaySinh);
            this.gbThongTin.Controls.Add(this.lblHoTen);
            this.gbThongTin.Controls.Add(this.lblMa);
            this.gbThongTin.Controls.Add(this.dtpNgaySinh);
            this.gbThongTin.Controls.Add(this.txtSdt);
            this.gbThongTin.Controls.Add(this.txtMa);
            this.gbThongTin.Controls.Add(this.txtHoTen);
            this.gbThongTin.Controls.Add(this.cboGioiTinh);
            this.gbThongTin.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbThongTin.Location = new System.Drawing.Point(3, 3);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(335, 171);
            this.gbThongTin.TabIndex = 0;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin thành viên";
            // 
            // lblSdt
            // 
            this.lblSdt.AutoSize = true;
            this.lblSdt.Location = new System.Drawing.Point(29, 138);
            this.lblSdt.Name = "lblSdt";
            this.lblSdt.Size = new System.Drawing.Size(69, 16);
            this.lblSdt.TabIndex = 9;
            this.lblSdt.Text = "Điện thoại:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(29, 112);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(57, 16);
            this.lblGioiTinh.TabIndex = 8;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(29, 82);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(70, 16);
            this.lblNgaySinh.TabIndex = 7;
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.lblNgaySinh.Click += new System.EventHandler(this.lblNgaySinh_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(29, 54);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(49, 16);
            this.lblHoTen.TabIndex = 6;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(29, 24);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(50, 16);
            this.lblMa.TabIndex = 5;
            this.lblMa.Text = "Mã TV:";
            // 
            // gbChucNang
            // 
            this.gbChucNang.Controls.Add(this.btnXoa);
            this.gbChucNang.Controls.Add(this.btnThem);
            this.gbChucNang.Controls.Add(this.btnSua);
            this.gbChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChucNang.Location = new System.Drawing.Point(344, 3);
            this.gbChucNang.Name = "gbChucNang";
            this.gbChucNang.Size = new System.Drawing.Size(146, 171);
            this.gbChucNang.TabIndex = 1;
            this.gbChucNang.TabStop = false;
            this.gbChucNang.Text = "Chức năng";
            // 
            // gbGoiTap
            // 
            this.gbGoiTap.Controls.Add(this.btnInThe);
            this.gbGoiTap.Controls.Add(this.btnGiaHan);
            this.gbGoiTap.Controls.Add(this.btnDangKy);
            this.gbGoiTap.Controls.Add(this.cboGoiTap);
            this.gbGoiTap.Controls.Add(this.lblGoiTap);
            this.gbGoiTap.Location = new System.Drawing.Point(496, 3);
            this.gbGoiTap.Name = "gbGoiTap";
            this.gbGoiTap.Size = new System.Drawing.Size(300, 171);
            this.gbGoiTap.TabIndex = 2;
            this.gbGoiTap.TabStop = false;
            this.gbGoiTap.Text = "Quản lý gói tập";
            // 
            // btnInThe
            // 
            this.btnInThe.Location = new System.Drawing.Point(83, 138);
            this.btnInThe.Name = "btnInThe";
            this.btnInThe.Size = new System.Drawing.Size(148, 23);
            this.btnInThe.TabIndex = 4;
            this.btnInThe.Text = "In Thẻ";
            this.btnInThe.UseVisualStyleBackColor = true;
            this.btnInThe.Click += new System.EventHandler(this.btnInThe_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(83, 105);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(148, 23);
            this.btnGiaHan.TabIndex = 3;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(83, 73);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(148, 26);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng ký gói tập";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // cboGoiTap
            // 
            this.cboGoiTap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoiTap.FormattingEnabled = true;
            this.cboGoiTap.Location = new System.Drawing.Point(28, 43);
            this.cboGoiTap.Name = "cboGoiTap";
            this.cboGoiTap.Size = new System.Drawing.Size(264, 24);
            this.cboGoiTap.TabIndex = 1;
            // 
            // lblGoiTap
            // 
            this.lblGoiTap.AutoSize = true;
            this.lblGoiTap.Location = new System.Drawing.Point(25, 24);
            this.lblGoiTap.Name = "lblGoiTap";
            this.lblGoiTap.Size = new System.Drawing.Size(85, 16);
            this.lblGoiTap.TabIndex = 0;
            this.lblGoiTap.Text = "Chọn gói tập:";
            this.lblGoiTap.Click += new System.EventHandler(this.label1_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 180);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.dgvThanhVien);
            this.scMain.Panel1.Controls.Add(this.lblDSThanhVien);
            this.scMain.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.dgvGoiTap);
            this.scMain.Panel2.Controls.Add(this.lblGoiTapDaDK);
            this.scMain.Size = new System.Drawing.Size(800, 270);
            this.scMain.SplitterDistance = 131;
            this.scMain.TabIndex = 1;
            // 
            // dgvThanhVien
            // 
            this.dgvThanhVien.AllowUserToAddRows = false;
            this.dgvThanhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThanhVien.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvThanhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThanhVien.Location = new System.Drawing.Point(0, 25);
            this.dgvThanhVien.MultiSelect = false;
            this.dgvThanhVien.Name = "dgvThanhVien";
            this.dgvThanhVien.ReadOnly = true;
            this.dgvThanhVien.RowHeadersWidth = 51;
            this.dgvThanhVien.RowTemplate.Height = 24;
            this.dgvThanhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThanhVien.Size = new System.Drawing.Size(800, 106);
            this.dgvThanhVien.TabIndex = 1;
            this.dgvThanhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThanhVien_CellClick);
            // 
            // lblDSThanhVien
            // 
            this.lblDSThanhVien.AutoSize = true;
            this.lblDSThanhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDSThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSThanhVien.Location = new System.Drawing.Point(0, 0);
            this.lblDSThanhVien.Name = "lblDSThanhVien";
            this.lblDSThanhVien.Size = new System.Drawing.Size(275, 25);
            this.lblDSThanhVien.TabIndex = 0;
            this.lblDSThanhVien.Text = "DANH SÁCH THÀNH VIÊN";
            this.lblDSThanhVien.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // dgvGoiTap
            // 
            this.dgvGoiTap.AllowUserToAddRows = false;
            this.dgvGoiTap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGoiTap.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGoiTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoiTap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoiTap.GridColor = System.Drawing.SystemColors.Control;
            this.dgvGoiTap.Location = new System.Drawing.Point(0, 25);
            this.dgvGoiTap.Name = "dgvGoiTap";
            this.dgvGoiTap.ReadOnly = true;
            this.dgvGoiTap.RowHeadersWidth = 51;
            this.dgvGoiTap.RowTemplate.Height = 24;
            this.dgvGoiTap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoiTap.Size = new System.Drawing.Size(800, 110);
            this.dgvGoiTap.TabIndex = 1;
            // 
            // lblGoiTapDaDK
            // 
            this.lblGoiTapDaDK.AutoSize = true;
            this.lblGoiTapDaDK.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGoiTapDaDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoiTapDaDK.Location = new System.Drawing.Point(0, 0);
            this.lblGoiTapDaDK.Name = "lblGoiTapDaDK";
            this.lblGoiTapDaDK.Size = new System.Drawing.Size(291, 25);
            this.lblGoiTapDaDK.TabIndex = 0;
            this.lblGoiTapDaDK.Text = "CÁC GÓI TẬP ĐÃ ĐĂNG KÝ";
            // 
            // printCardDocument
            // 
            this.printCardDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCardDocument_PrintPage);
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
            // QuanLyThanhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "QuanLyThanhVien";
            this.Text = "Quản Lý Thành Viên";
            this.Load += new System.EventHandler(this.QuanLyThanhVien_Load);
            this.pnlTop.ResumeLayout(false);
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbChucNang.ResumeLayout(false);
            this.gbGoiTap.ResumeLayout(false);
            this.gbGoiTap.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiTap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.FlowLayoutPanel pnlTop;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblSdt;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.GroupBox gbChucNang;
        private System.Windows.Forms.GroupBox gbGoiTap;
        private System.Windows.Forms.Label lblGoiTap;
        private System.Windows.Forms.ComboBox cboGoiTap;
        private System.Windows.Forms.Button btnInThe;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Label lblDSThanhVien;
        private System.Windows.Forms.DataGridView dgvThanhVien;
        private System.Windows.Forms.Label lblGoiTapDaDK;
        private System.Windows.Forms.DataGridView dgvGoiTap;
        private System.Drawing.Printing.PrintDocument printCardDocument;
        private System.Windows.Forms.PrintPreviewDialog printCardPreviewDialog;
    }
}