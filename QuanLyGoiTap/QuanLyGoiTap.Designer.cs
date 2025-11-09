namespace GZone
{
    partial class QuanLyGoiTap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DanhSachGoiTap = new System.Windows.Forms.Label();
            this.dgvDSGoiTap = new System.Windows.Forms.DataGridView();
            this.btnThemGT = new System.Windows.Forms.Button();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.colMaGoiTap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChinhSua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colXoaGoiTap = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGoiTap)).BeginInit();
            this.SuspendLayout();
            // 
            // DanhSachGoiTap
            // 
            this.DanhSachGoiTap.AutoSize = true;
            this.DanhSachGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DanhSachGoiTap.Location = new System.Drawing.Point(362, 9);
            this.DanhSachGoiTap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DanhSachGoiTap.Name = "DanhSachGoiTap";
            this.DanhSachGoiTap.Size = new System.Drawing.Size(166, 20);
            this.DanhSachGoiTap.TabIndex = 0;
            this.DanhSachGoiTap.Text = "Danh Sách Gói Tập";
            // 
            // dgvDSGoiTap
            // 
            this.dgvDSGoiTap.AllowUserToAddRows = false;
            this.dgvDSGoiTap.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSGoiTap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSGoiTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSGoiTap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaGoiTap,
            this.colTenGoi,
            this.colThoiHan,
            this.colGia,
            this.colChinhSua,
            this.colXoaGoiTap});
            this.dgvDSGoiTap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDSGoiTap.EnableHeadersVisualStyles = false;
            this.dgvDSGoiTap.Location = new System.Drawing.Point(35, 55);
            this.dgvDSGoiTap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSGoiTap.Name = "dgvDSGoiTap";
            this.dgvDSGoiTap.RowTemplate.Height = 24;
            this.dgvDSGoiTap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDSGoiTap.Size = new System.Drawing.Size(891, 534);
            this.dgvDSGoiTap.TabIndex = 1;
            this.dgvDSGoiTap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSGoiTap_CellContentClick);
            // 
            // btnThemGT
            // 
            this.btnThemGT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThemGT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemGT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThemGT.Location = new System.Drawing.Point(699, 29);
            this.btnThemGT.Name = "btnThemGT";
            this.btnThemGT.Size = new System.Drawing.Size(112, 21);
            this.btnThemGT.TabIndex = 2;
            this.btnThemGT.Text = "Thêm Gói Tập";
            this.btnThemGT.UseVisualStyleBackColor = false;
            this.btnThemGT.Click += new System.EventHandler(this.btnThemGT_Click);
            // 
            // btnDelAll
            // 
            this.btnDelAll.BackColor = System.Drawing.Color.Red;
            this.btnDelAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelAll.Location = new System.Drawing.Point(817, 27);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(109, 23);
            this.btnDelAll.TabIndex = 3;
            this.btnDelAll.Text = "Xóa Tất Cả";
            this.btnDelAll.UseVisualStyleBackColor = false;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // colMaGoiTap
            // 
            this.colMaGoiTap.DataPropertyName = "Ma";
            this.colMaGoiTap.Frozen = true;
            this.colMaGoiTap.HeaderText = "Mã gói tập";
            this.colMaGoiTap.Name = "colMaGoiTap";
            this.colMaGoiTap.ReadOnly = true;
            this.colMaGoiTap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaGoiTap.Width = 156;
            // 
            // colTenGoi
            // 
            this.colTenGoi.DataPropertyName = "Ten";
            this.colTenGoi.Frozen = true;
            this.colTenGoi.HeaderText = "Tên Gói Tập";
            this.colTenGoi.Name = "colTenGoi";
            this.colTenGoi.ReadOnly = true;
            this.colTenGoi.Width = 175;
            // 
            // colThoiHan
            // 
            this.colThoiHan.DataPropertyName = "ThoiHan";
            this.colThoiHan.Frozen = true;
            this.colThoiHan.HeaderText = "Thời hạn gói tập";
            this.colThoiHan.Name = "colThoiHan";
            this.colThoiHan.ReadOnly = true;
            this.colThoiHan.Width = 160;
            // 
            // colGia
            // 
            this.colGia.DataPropertyName = "Gia";
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.NullValue = null;
            this.colGia.DefaultCellStyle = dataGridViewCellStyle2;
            this.colGia.Frozen = true;
            this.colGia.HeaderText = "Giá Gói Tập";
            this.colGia.Name = "colGia";
            this.colGia.ReadOnly = true;
            this.colGia.Width = 155;
            // 
            // colChinhSua
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.colChinhSua.DefaultCellStyle = dataGridViewCellStyle3;
            this.colChinhSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colChinhSua.Frozen = true;
            this.colChinhSua.HeaderText = "Chỉnh Sửa";
            this.colChinhSua.Name = "colChinhSua";
            this.colChinhSua.Text = "Chỉnh sửa";
            this.colChinhSua.UseColumnTextForButtonValue = true;
            // 
            // colXoaGoiTap
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.colXoaGoiTap.DefaultCellStyle = dataGridViewCellStyle4;
            this.colXoaGoiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colXoaGoiTap.HeaderText = "Xóa Gói Tập";
            this.colXoaGoiTap.Name = "colXoaGoiTap";
            this.colXoaGoiTap.Text = "Xóa";
            this.colXoaGoiTap.UseColumnTextForButtonValue = true;
            // 
            // QuanLyGoiTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 612);
            this.Controls.Add(this.btnDelAll);
            this.Controls.Add(this.btnThemGT);
            this.Controls.Add(this.dgvDSGoiTap);
            this.Controls.Add(this.DanhSachGoiTap);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLyGoiTap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý gói tập";
            this.Load += new System.EventHandler(this.QuanLyGoiTap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGoiTap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DanhSachGoiTap;
        private System.Windows.Forms.DataGridView dgvDSGoiTap;
        private System.Windows.Forms.Button btnThemGT;
        private System.Windows.Forms.Button btnDelAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGoiTap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenGoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;
        private System.Windows.Forms.DataGridViewButtonColumn colChinhSua;
        private System.Windows.Forms.DataGridViewButtonColumn colXoaGoiTap;
    }
}

