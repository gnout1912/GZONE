namespace GZone.QuanLyLamViec
{
    partial class frmXepLichNhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTuan = new System.Windows.Forms.Label();
            this.dtpChonNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTuanSau = new System.Windows.Forms.Button();
            this.btnTuanTruoc = new System.Windows.Forms.Button();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dgvLichTuan = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichTuan)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelTop.Controls.Add(this.lblTuan);
            this.panelTop.Controls.Add(this.dtpChonNgay);
            this.panelTop.Controls.Add(this.btnTuanSau);
            this.panelTop.Controls.Add(this.btnTuanTruoc);
            this.panelTop.Controls.Add(this.lblNhanVien);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(736, 65);
            this.panelTop.TabIndex = 0;
            // 
            // lblTuan
            // 
            this.lblTuan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTuan.AutoSize = true;
            this.lblTuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuan.Location = new System.Drawing.Point(258, 37);
            this.lblTuan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTuan.Name = "lblTuan";
            this.lblTuan.Size = new System.Drawing.Size(205, 17);
            this.lblTuan.TabIndex = 4;
            this.lblTuan.Text = "Tuần từ: 10/11 đến 16/11/2025";
            // 
            // dtpChonNgay
            // 
            this.dtpChonNgay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpChonNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpChonNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpChonNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChonNgay.Location = new System.Drawing.Point(311, 10);
            this.dtpChonNgay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpChonNgay.Name = "dtpChonNgay";
            this.dtpChonNgay.Size = new System.Drawing.Size(96, 23);
            this.dtpChonNgay.TabIndex = 3;
            this.dtpChonNgay.ValueChanged += new System.EventHandler(this.dtpChonNgay_ValueChanged);
            // 
            // btnTuanSau
            // 
            this.btnTuanSau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTuanSau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuanSau.Location = new System.Drawing.Point(410, 8);
            this.btnTuanSau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTuanSau.Name = "btnTuanSau";
            this.btnTuanSau.Size = new System.Drawing.Size(44, 24);
            this.btnTuanSau.TabIndex = 2;
            this.btnTuanSau.Text = ">";
            this.btnTuanSau.UseVisualStyleBackColor = true;
            this.btnTuanSau.Click += new System.EventHandler(this.btnTuanSau_Click);
            // 
            // btnTuanTruoc
            // 
            this.btnTuanTruoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTuanTruoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuanTruoc.Location = new System.Drawing.Point(262, 8);
            this.btnTuanTruoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTuanTruoc.Name = "btnTuanTruoc";
            this.btnTuanTruoc.Size = new System.Drawing.Size(44, 24);
            this.btnTuanTruoc.TabIndex = 1;
            this.btnTuanTruoc.Text = "<";
            this.btnTuanTruoc.UseVisualStyleBackColor = true;
            this.btnTuanTruoc.Click += new System.EventHandler(this.btnTuanTruoc_Click);
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNhanVien.Location = new System.Drawing.Point(9, 7);
            this.lblNhanVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(186, 20);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Tên nhân viên";
            // 
            // dgvLichTuan
            // 
            this.dgvLichTuan.AllowUserToAddRows = false;
            this.dgvLichTuan.AllowUserToDeleteRows = false;
            this.dgvLichTuan.AllowUserToResizeRows = false;
            this.dgvLichTuan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichTuan.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichTuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLichTuan.ColumnHeadersHeight = 60;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichTuan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLichTuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichTuan.Location = new System.Drawing.Point(0, 65);
            this.dgvLichTuan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLichTuan.MultiSelect = false;
            this.dgvLichTuan.Name = "dgvLichTuan";
            this.dgvLichTuan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvLichTuan.RowTemplate.Height = 80;
            this.dgvLichTuan.Size = new System.Drawing.Size(736, 303);
            this.dgvLichTuan.TabIndex = 1;
            this.dgvLichTuan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichTuan_CellClick);
            // 
            // frmXepLichNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 368);
            this.Controls.Add(this.dgvLichTuan);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(604, 332);
            this.Name = "frmXepLichNhanVien";
            this.Text = "Xếp lịch làm việc chi tiết";
            this.Load += new System.EventHandler(this.frmXepLichNhanVien_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichTuan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DataGridView dgvLichTuan;
        private System.Windows.Forms.DateTimePicker dtpChonNgay;
        private System.Windows.Forms.Button btnTuanSau;
        private System.Windows.Forms.Button btnTuanTruoc;
        private System.Windows.Forms.Label lblTuan;
    }
}