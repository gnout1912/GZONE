namespace GZone
{
    partial class QuanLyCoSoVatChat
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvCSVC = new System.Windows.Forms.DataGridView();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCNMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCNMa = new System.Windows.Forms.TextBox();
            this.txtTenMay = new System.Windows.Forms.TextBox();
            this.txtLoaiMay = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cbTinhTrang = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCNMa = new System.Windows.Forms.Label();
            this.lblTenMay = new System.Windows.Forms.Label();
            this.lblLoaiMay = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSVC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCSVC
            // 
            this.dgvCSVC.AllowUserToAddRows = false;
            this.dgvCSVC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCSVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCSVC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colCNMa,
            this.colTenMay,
            this.colLoaiMay,
            this.colSoLuong,
            this.colTinhTrang,
            this.colGhiChu});
            this.dgvCSVC.Location = new System.Drawing.Point(12, 150);
            this.dgvCSVC.Name = "dgvCSVC";
            this.dgvCSVC.Size = new System.Drawing.Size(710, 240);
            this.dgvCSVC.TabIndex = 16;
            this.dgvCSVC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCSVC_CellClick);
            // 
            // colMa
            // 
            this.colMa.DataPropertyName = "Ma";
            this.colMa.HeaderText = "Mã";
            this.colMa.Name = "colMa";
            // 
            // colCNMa
            // 
            this.colCNMa.DataPropertyName = "MaChiNhanh";
            this.colCNMa.HeaderText = "Mã CN";
            this.colCNMa.Name = "colCNMa";
            // 
            // colTenMay
            // 
            this.colTenMay.DataPropertyName = "TenMay";
            this.colTenMay.HeaderText = "Tên Máy";
            this.colTenMay.Name = "colTenMay";
            // 
            // colLoaiMay
            // 
            this.colLoaiMay.DataPropertyName = "LoaiMay";
            this.colLoaiMay.HeaderText = "Loại Máy";
            this.colLoaiMay.Name = "colLoaiMay";
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            this.colSoLuong.HeaderText = "Số Lượng";
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colTinhTrang
            // 
            this.colTinhTrang.DataPropertyName = "TinhTrang";
            this.colTinhTrang.HeaderText = "Tình Trạng";
            this.colTinhTrang.Name = "colTinhTrang";
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.HeaderText = "Ghi Chú";
            this.colGhiChu.Name = "colGhiChu";
            // 
            // txtCNMa
            // 
            this.txtCNMa.Location = new System.Drawing.Point(120, 25);
            this.txtCNMa.Name = "txtCNMa";
            this.txtCNMa.Size = new System.Drawing.Size(80, 22);
            this.txtCNMa.TabIndex = 7;
            // 
            // txtTenMay
            // 
            this.txtTenMay.Location = new System.Drawing.Point(120, 55);
            this.txtTenMay.Name = "txtTenMay";
            this.txtTenMay.Size = new System.Drawing.Size(80, 22);
            this.txtTenMay.TabIndex = 8;
            // 
            // txtLoaiMay
            // 
            this.txtLoaiMay.Location = new System.Drawing.Point(120, 85);
            this.txtLoaiMay.Name = "txtLoaiMay";
            this.txtLoaiMay.Size = new System.Drawing.Size(80, 22);
            this.txtLoaiMay.TabIndex = 9;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(310, 28);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(80, 22);
            this.txtSoLuong.TabIndex = 10;
            // 
            // cbTinhTrang
            // 
            this.cbTinhTrang.Location = new System.Drawing.Point(310, 58);
            this.cbTinhTrang.Name = "cbTinhTrang";
            this.cbTinhTrang.Size = new System.Drawing.Size(120, 24);
            this.cbTinhTrang.TabIndex = 11;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(310, 91);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(120, 22);
            this.txtGhiChu.TabIndex = 12;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(470, 50);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(550, 50);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(630, 50);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(250, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(230, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Cơ Sở Vật Chất";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCNMa
            // 
            this.lblCNMa.Location = new System.Drawing.Point(14, 31);
            this.lblCNMa.Name = "lblCNMa";
            this.lblCNMa.Size = new System.Drawing.Size(89, 16);
            this.lblCNMa.TabIndex = 1;
            this.lblCNMa.Text = "Mã chi nhánh:";
            // 
            // lblTenMay
            // 
            this.lblTenMay.Location = new System.Drawing.Point(14, 61);
            this.lblTenMay.Name = "lblTenMay";
            this.lblTenMay.Size = new System.Drawing.Size(74, 16);
            this.lblTenMay.TabIndex = 2;
            this.lblTenMay.Text = "Tên máy:";
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.Location = new System.Drawing.Point(17, 94);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.lblLoaiMay.Size = new System.Drawing.Size(86, 16);
            this.lblLoaiMay.TabIndex = 3;
            this.lblLoaiMay.Text = "Loại máy:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(220, 31);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(84, 16);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Location = new System.Drawing.Point(220, 61);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(84, 16);
            this.lblTinhTrang.TabIndex = 5;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(220, 94);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(70, 16);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // QuanLyCoSoVatChat
            // 
            this.ClientSize = new System.Drawing.Size(740, 410);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCNMa);
            this.Controls.Add(this.lblTenMay);
            this.Controls.Add(this.lblLoaiMay);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtCNMa);
            this.Controls.Add(this.txtTenMay);
            this.Controls.Add(this.txtLoaiMay);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.cbTinhTrang);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvCSVC);
            this.Name = "QuanLyCoSoVatChat";
            this.Text = "Quản Lý Cơ Sở Vật Chất";
            this.Load += new System.EventHandler(this.QuanLyCoSoVatChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSVC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView dgvCSVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCNMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.TextBox txtCNMa;
        private System.Windows.Forms.TextBox txtTenMay;
        private System.Windows.Forms.TextBox txtLoaiMay;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cbTinhTrang;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCNMa;
        private System.Windows.Forms.Label lblTenMay;
        private System.Windows.Forms.Label lblLoaiMay;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Label lblGhiChu;
    }
}
