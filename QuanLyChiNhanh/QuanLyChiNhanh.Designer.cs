namespace GZone
{
    partial class QuanLyChiNhanh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.lstChiNhanh = new System.Windows.Forms.ListBox();
            this.btnThemChiNhanh = new System.Windows.Forms.Button();
            this.lblTieuDeTrai = new System.Windows.Forms.Label();
            this.tabChiTiet = new System.Windows.Forms.TabControl();
            this.tabPageThongTin = new System.Windows.Forms.TabPage();
            this.btnSuaChiTiet = new System.Windows.Forms.Button();
            this.txtNgayThanhLap = new System.Windows.Forms.TextBox();
            this.lblNgayThanhLap = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtTenChiNhanh = new System.Windows.Forms.TextBox();
            this.lblTenChiNhanh = new System.Windows.Forms.Label();
            this.txtMaChiNhanh = new System.Windows.Forms.TextBox();
            this.lblMaChiNhanh = new System.Windows.Forms.Label();
            this.tabPageYeuCau = new System.Windows.Forms.TabPage();
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();
            this.panelYeuCauTop = new System.Windows.Forms.Panel();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnPheDuyet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tabChiTiet.SuspendLayout();
            this.tabPageThongTin.SuspendLayout();
            this.tabPageYeuCau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.panelYeuCauTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.lstChiNhanh);
            this.splitMain.Panel1.Controls.Add(this.btnThemChiNhanh);
            this.splitMain.Panel1.Controls.Add(this.lblTieuDeTrai);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabChiTiet);
            this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.splitMain.Size = new System.Drawing.Size(1112, 600);
            this.splitMain.SplitterDistance = 299;
            this.splitMain.TabIndex = 0;
            // 
            // lstChiNhanh
            // 
            this.lstChiNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChiNhanh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChiNhanh.FormattingEnabled = true;
            this.lstChiNhanh.IntegralHeight = false;
            this.lstChiNhanh.ItemHeight = 20;
            this.lstChiNhanh.Location = new System.Drawing.Point(10, 82);
            this.lstChiNhanh.Name = "lstChiNhanh";
            this.lstChiNhanh.Size = new System.Drawing.Size(279, 508);
            this.lstChiNhanh.TabIndex = 1;
            this.lstChiNhanh.SelectedIndexChanged += new System.EventHandler(this.lstChiNhanh_SelectedIndexChanged);
            // 
            // btnThemChiNhanh
            // 
            this.btnThemChiNhanh.BackColor = System.Drawing.Color.SeaGreen;
            this.btnThemChiNhanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemChiNhanh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemChiNhanh.ForeColor = System.Drawing.Color.White;
            this.btnThemChiNhanh.Location = new System.Drawing.Point(10, 42);
            this.btnThemChiNhanh.Name = "btnThemChiNhanh";
            this.btnThemChiNhanh.Size = new System.Drawing.Size(279, 40);
            this.btnThemChiNhanh.TabIndex = 11;
            this.btnThemChiNhanh.Text = "+ Thêm Chi Nhánh Mới";
            this.btnThemChiNhanh.UseVisualStyleBackColor = false;
            this.btnThemChiNhanh.Click += new System.EventHandler(this.btnThemChiNhanh_Click);
            // 
            // lblTieuDeTrai
            // 
            this.lblTieuDeTrai.AutoSize = true;
            this.lblTieuDeTrai.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTrai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTrai.Location = new System.Drawing.Point(10, 10);
            this.lblTieuDeTrai.Name = "lblTieuDeTrai";
            this.lblTieuDeTrai.Padding = new System.Windows.Forms.Padding(0, 0, 0, 11);
            this.lblTieuDeTrai.Size = new System.Drawing.Size(200, 32);
            this.lblTieuDeTrai.TabIndex = 0;
            this.lblTieuDeTrai.Text = "DANH SÁCH CHI NHÁNH";
            // 
            // tabChiTiet
            // 
            this.tabChiTiet.Controls.Add(this.tabPageThongTin);
            this.tabChiTiet.Controls.Add(this.tabPageYeuCau);
            this.tabChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChiTiet.Location = new System.Drawing.Point(5, 10);
            this.tabChiTiet.Name = "tabChiTiet";
            this.tabChiTiet.SelectedIndex = 0;
            this.tabChiTiet.Size = new System.Drawing.Size(794, 580);
            this.tabChiTiet.TabIndex = 0;
            // 
            // tabPageThongTin
            // 
            this.tabPageThongTin.Controls.Add(this.btnSuaChiTiet);
            this.tabPageThongTin.Controls.Add(this.txtNgayThanhLap);
            this.tabPageThongTin.Controls.Add(this.lblNgayThanhLap);
            this.tabPageThongTin.Controls.Add(this.txtSoDienThoai);
            this.tabPageThongTin.Controls.Add(this.lblSoDienThoai);
            this.tabPageThongTin.Controls.Add(this.txtDiaChi);
            this.tabPageThongTin.Controls.Add(this.lblDiaChi);
            this.tabPageThongTin.Controls.Add(this.txtTenChiNhanh);
            this.tabPageThongTin.Controls.Add(this.lblTenChiNhanh);
            this.tabPageThongTin.Controls.Add(this.txtMaChiNhanh);
            this.tabPageThongTin.Controls.Add(this.lblMaChiNhanh);
            this.tabPageThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageThongTin.Location = new System.Drawing.Point(4, 26);
            this.tabPageThongTin.Name = "tabPageThongTin";
            this.tabPageThongTin.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tabPageThongTin.Size = new System.Drawing.Size(786, 550);
            this.tabPageThongTin.TabIndex = 0;
            this.tabPageThongTin.Text = "Thông tin Chi tiết";
            this.tabPageThongTin.UseVisualStyleBackColor = true;
            // 
            // btnSuaChiTiet
            // 
            this.btnSuaChiTiet.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSuaChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnSuaChiTiet.Location = new System.Drawing.Point(135, 235);
            this.btnSuaChiTiet.Name = "btnSuaChiTiet";
            this.btnSuaChiTiet.Size = new System.Drawing.Size(180, 40);
            this.btnSuaChiTiet.TabIndex = 10;
            this.btnSuaChiTiet.Text = "Chỉnh sửa Chi nhánh";
            this.btnSuaChiTiet.UseVisualStyleBackColor = false;
            this.btnSuaChiTiet.Click += new System.EventHandler(this.btnSuaChiTiet_Click);
            // 
            // txtNgayThanhLap
            // 
            this.txtNgayThanhLap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgayThanhLap.Location = new System.Drawing.Point(135, 184);
            this.txtNgayThanhLap.Name = "txtNgayThanhLap";
            this.txtNgayThanhLap.ReadOnly = true;
            this.txtNgayThanhLap.Size = new System.Drawing.Size(636, 25);
            this.txtNgayThanhLap.TabIndex = 9;
            // 
            // lblNgayThanhLap
            // 
            this.lblNgayThanhLap.AutoSize = true;
            this.lblNgayThanhLap.Location = new System.Drawing.Point(25, 187);
            this.lblNgayThanhLap.Name = "lblNgayThanhLap";
            this.lblNgayThanhLap.Size = new System.Drawing.Size(100, 17);
            this.lblNgayThanhLap.TabIndex = 8;
            this.lblNgayThanhLap.Text = "Ngày thành lập:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(135, 143);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.ReadOnly = true;
            this.txtSoDienThoai.Size = new System.Drawing.Size(636, 25);
            this.txtSoDienThoai.TabIndex = 7;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(25, 146);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(88, 17);
            this.lblSoDienThoai.TabIndex = 6;
            this.lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Location = new System.Drawing.Point(135, 102);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(636, 25);
            this.txtDiaChi.TabIndex = 5;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(25, 105);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(50, 17);
            this.lblDiaChi.TabIndex = 4;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtTenChiNhanh
            // 
            this.txtTenChiNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenChiNhanh.Location = new System.Drawing.Point(135, 61);
            this.txtTenChiNhanh.Name = "txtTenChiNhanh";
            this.txtTenChiNhanh.ReadOnly = true;
            this.txtTenChiNhanh.Size = new System.Drawing.Size(636, 25);
            this.txtTenChiNhanh.TabIndex = 3;
            // 
            // lblTenChiNhanh
            // 
            this.lblTenChiNhanh.AutoSize = true;
            this.lblTenChiNhanh.Location = new System.Drawing.Point(25, 64);
            this.lblTenChiNhanh.Name = "lblTenChiNhanh";
            this.lblTenChiNhanh.Size = new System.Drawing.Size(90, 17);
            this.lblTenChiNhanh.TabIndex = 2;
            this.lblTenChiNhanh.Text = "Tên chi nhánh:";
            // 
            // txtMaChiNhanh
            // 
            this.txtMaChiNhanh.Location = new System.Drawing.Point(135, 20);
            this.txtMaChiNhanh.Name = "txtMaChiNhanh";
            this.txtMaChiNhanh.ReadOnly = true;
            this.txtMaChiNhanh.Size = new System.Drawing.Size(180, 25);
            this.txtMaChiNhanh.TabIndex = 1;
            // 
            // lblMaChiNhanh
            // 
            this.lblMaChiNhanh.AutoSize = true;
            this.lblMaChiNhanh.Location = new System.Drawing.Point(25, 23);
            this.lblMaChiNhanh.Name = "lblMaChiNhanh";
            this.lblMaChiNhanh.Size = new System.Drawing.Size(89, 17);
            this.lblMaChiNhanh.TabIndex = 0;
            this.lblMaChiNhanh.Text = "Mã chi nhánh:";
            // 
            // tabPageYeuCau
            // 
            this.tabPageYeuCau.Controls.Add(this.dgvYeuCau);
            this.tabPageYeuCau.Controls.Add(this.panelYeuCauTop);
            this.tabPageYeuCau.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageYeuCau.Location = new System.Drawing.Point(4, 26);
            this.tabPageYeuCau.Name = "tabPageYeuCau";
            this.tabPageYeuCau.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.tabPageYeuCau.Size = new System.Drawing.Size(786, 550);
            this.tabPageYeuCau.TabIndex = 1;
            this.tabPageYeuCau.Text = "Quản lý Yêu cầu";
            this.tabPageYeuCau.UseVisualStyleBackColor = true;
            // 
            // dgvYeuCau
            // 
            this.dgvYeuCau.AllowUserToAddRows = false;
            this.dgvYeuCau.AllowUserToDeleteRows = false;
            this.dgvYeuCau.BackgroundColor = System.Drawing.Color.White;
            this.dgvYeuCau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvYeuCau.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvYeuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvYeuCau.Location = new System.Drawing.Point(10, 55);
            this.dgvYeuCau.MultiSelect = false;
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.ReadOnly = true;
            this.dgvYeuCau.RowHeadersVisible = false;
            this.dgvYeuCau.RowHeadersWidth = 51;
            this.dgvYeuCau.RowTemplate.Height = 28;
            this.dgvYeuCau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvYeuCau.Size = new System.Drawing.Size(766, 485);
            this.dgvYeuCau.TabIndex = 1;
            this.dgvYeuCau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYeuCau_CellContentClick);
            // 
            // panelYeuCauTop
            // 
            this.panelYeuCauTop.Controls.Add(this.btnTuChoi);
            this.panelYeuCauTop.Controls.Add(this.btnPheDuyet);
            this.panelYeuCauTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelYeuCauTop.Location = new System.Drawing.Point(10, 10);
            this.panelYeuCauTop.Name = "panelYeuCauTop";
            this.panelYeuCauTop.Size = new System.Drawing.Size(766, 45);
            this.panelYeuCauTop.TabIndex = 0;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuChoi.BackColor = System.Drawing.Color.Tomato;
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(653, 3);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(110, 40);
            this.btnTuChoi.TabIndex = 1;
            this.btnTuChoi.Text = "Từ chối";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // btnPheDuyet
            // 
            this.btnPheDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPheDuyet.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPheDuyet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPheDuyet.ForeColor = System.Drawing.Color.White;
            this.btnPheDuyet.Location = new System.Drawing.Point(528, 3);
            this.btnPheDuyet.Name = "btnPheDuyet";
            this.btnPheDuyet.Size = new System.Drawing.Size(110, 40);
            this.btnPheDuyet.TabIndex = 0;
            this.btnPheDuyet.Text = "Phê duyệt";
            this.btnPheDuyet.UseVisualStyleBackColor = false;
            this.btnPheDuyet.Click += new System.EventHandler(this.btnPheDuyet_Click);
            // 
            // QuanLyChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 600);
            this.Controls.Add(this.splitMain);
            this.Name = "QuanLyChiNhanh";
            this.Text = "Quản Lý Chi Nhánh";
            this.Load += new System.EventHandler(this.QuanLyChiNhanh_Load);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tabChiTiet.ResumeLayout(false);
            this.tabPageThongTin.ResumeLayout(false);
            this.tabPageThongTin.PerformLayout();
            this.tabPageYeuCau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.panelYeuCauTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ListBox lstChiNhanh;
        private System.Windows.Forms.Label lblTieuDeTrai;
        private System.Windows.Forms.TabControl tabChiTiet;
        private System.Windows.Forms.TabPage tabPageThongTin;
        private System.Windows.Forms.TabPage tabPageYeuCau;
        private System.Windows.Forms.TextBox txtMaChiNhanh;
        private System.Windows.Forms.Label lblMaChiNhanh;
        private System.Windows.Forms.TextBox txtNgayThanhLap;
        private System.Windows.Forms.Label lblNgayThanhLap;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtTenChiNhanh;
        private System.Windows.Forms.Label lblTenChiNhanh;
        private System.Windows.Forms.Button btnSuaChiTiet;
        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.Panel panelYeuCauTop;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnPheDuyet;
        private System.Windows.Forms.Button btnThemChiNhanh;
    }
}