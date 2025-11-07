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
            this.DanhSachGoiTap = new System.Windows.Forms.Label();
            this.dgvDSGoiTap = new System.Windows.Forms.DataGridView();
            this.colMaGoiTap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGoiTap)).BeginInit();
            this.SuspendLayout();
            // 
            // DanhSachGoiTap
            // 
            this.DanhSachGoiTap.AutoSize = true;
            this.DanhSachGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DanhSachGoiTap.Location = new System.Drawing.Point(190, 18);
            this.DanhSachGoiTap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DanhSachGoiTap.Name = "DanhSachGoiTap";
            this.DanhSachGoiTap.Size = new System.Drawing.Size(149, 20);
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
            this.colGia});
            this.dgvDSGoiTap.EnableHeadersVisualStyles = false;
            this.dgvDSGoiTap.Location = new System.Drawing.Point(25, 37);
            this.dgvDSGoiTap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDSGoiTap.Name = "dgvDSGoiTap";
            this.dgvDSGoiTap.RowTemplate.Height = 24;
            this.dgvDSGoiTap.Size = new System.Drawing.Size(657, 366);
            this.dgvDSGoiTap.TabIndex = 1;
            // 
            // colMaGoiTap
            // 
            this.colMaGoiTap.DataPropertyName = "GT_Ma";
            this.colMaGoiTap.HeaderText = "Mã gói tập";
            this.colMaGoiTap.Name = "colMaGoiTap";
            this.colMaGoiTap.ReadOnly = true;
            this.colMaGoiTap.Width = 156;
            // 
            // colTenGoi
            // 
            this.colTenGoi.DataPropertyName = "GT_Ten";
            this.colTenGoi.HeaderText = "Tên Gói Tập";
            this.colTenGoi.Name = "colTenGoi";
            this.colTenGoi.ReadOnly = true;
            this.colTenGoi.Width = 155;
            // 
            // colThoiHan
            // 
            this.colThoiHan.DataPropertyName = "GT_ThoiHan";
            this.colThoiHan.HeaderText = "Thời hạn gói tập";
            this.colThoiHan.Name = "colThoiHan";
            this.colThoiHan.ReadOnly = true;
            this.colThoiHan.Width = 156;
            // 
            // colGia
            // 
            this.colGia.DataPropertyName = "GT_Gia";
            this.colGia.HeaderText = "Giá Gói Tập";
            this.colGia.Name = "colGia";
            this.colGia.ReadOnly = true;
            this.colGia.Width = 155;
            // 
            // QuanLyGoiTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 439);
            this.Controls.Add(this.dgvDSGoiTap);
            this.Controls.Add(this.DanhSachGoiTap);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QuanLyGoiTap";
            this.Text = "Quản lý gói tập";
            this.Load += new System.EventHandler(this.QuanLyGoiTap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGoiTap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DanhSachGoiTap;
        private System.Windows.Forms.DataGridView dgvDSGoiTap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGoiTap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenGoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;
    }
}

