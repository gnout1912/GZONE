namespace GZone.QuanLyThanhVien
{
    partial class DangKiGoiTap
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dtpNgayDangKy = new System.Windows.Forms.DateTimePicker();
            this.lblNgayDangKy = new System.Windows.Forms.Label();
            this.cboGoiTap = new System.Windows.Forms.ComboBox();
            this.lblGoiTap = new System.Windows.Forms.Label();
            this.txtNgayHetHan = new System.Windows.Forms.TextBox();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.txtThoiHan = new System.Windows.Forms.TextBox();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.lblGiaTien = new System.Windows.Forms.Label();
            this.lblThoiHan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnHuy);
            this.splitContainer1.Panel1.Controls.Add(this.btnLuu);
            this.splitContainer1.Panel1.Controls.Add(this.dtpNgayDangKy);
            this.splitContainer1.Panel1.Controls.Add(this.lblNgayDangKy);
            this.splitContainer1.Panel1.Controls.Add(this.cboGoiTap);
            this.splitContainer1.Panel1.Controls.Add(this.lblGoiTap);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtNgayHetHan);
            this.splitContainer1.Panel2.Controls.Add(this.txtGiaTien);
            this.splitContainer1.Panel2.Controls.Add(this.txtThoiHan);
            this.splitContainer1.Panel2.Controls.Add(this.lblNgayHetHan);
            this.splitContainer1.Panel2.Controls.Add(this.lblGiaTien);
            this.splitContainer1.Panel2.Controls.Add(this.lblThoiHan);
            this.splitContainer1.Size = new System.Drawing.Size(613, 262);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHuy.Location = new System.Drawing.Point(157, 118);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(78, 33);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Aquamarine;
            this.btnLuu.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(50, 118);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(88, 33);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu đăng ký";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dtpNgayDangKy
            // 
            this.dtpNgayDangKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDangKy.Location = new System.Drawing.Point(115, 64);
            this.dtpNgayDangKy.Name = "dtpNgayDangKy";
            this.dtpNgayDangKy.Size = new System.Drawing.Size(83, 20);
            this.dtpNgayDangKy.TabIndex = 3;
            // 
            // lblNgayDangKy
            // 
            this.lblNgayDangKy.AutoSize = true;
            this.lblNgayDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDangKy.Location = new System.Drawing.Point(23, 64);
            this.lblNgayDangKy.Name = "lblNgayDangKy";
            this.lblNgayDangKy.Size = new System.Drawing.Size(86, 13);
            this.lblNgayDangKy.TabIndex = 2;
            this.lblNgayDangKy.Text = "Ngày đăng ký";
            // 
            // cboGoiTap
            // 
            this.cboGoiTap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoiTap.FormattingEnabled = true;
            this.cboGoiTap.Location = new System.Drawing.Point(26, 24);
            this.cboGoiTap.Name = "cboGoiTap";
            this.cboGoiTap.Size = new System.Drawing.Size(289, 21);
            this.cboGoiTap.TabIndex = 1;
            this.cboGoiTap.SelectedIndexChanged += new System.EventHandler(this.cboGoiTap_SelectedIndexChanged);
            // 
            // lblGoiTap
            // 
            this.lblGoiTap.AutoSize = true;
            this.lblGoiTap.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoiTap.Location = new System.Drawing.Point(0, 0);
            this.lblGoiTap.Name = "lblGoiTap";
            this.lblGoiTap.Size = new System.Drawing.Size(119, 20);
            this.lblGoiTap.TabIndex = 0;
            this.lblGoiTap.Text = "Chọn Gói Tập";
            // 
            // txtNgayHetHan
            // 
            this.txtNgayHetHan.Location = new System.Drawing.Point(114, 115);
            this.txtNgayHetHan.Name = "txtNgayHetHan";
            this.txtNgayHetHan.ReadOnly = true;
            this.txtNgayHetHan.Size = new System.Drawing.Size(124, 20);
            this.txtNgayHetHan.TabIndex = 5;
            this.txtNgayHetHan.TabStop = false;
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(114, 64);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.ReadOnly = true;
            this.txtGiaTien.Size = new System.Drawing.Size(124, 20);
            this.txtGiaTien.TabIndex = 4;
            this.txtGiaTien.TabStop = false;
            // 
            // txtThoiHan
            // 
            this.txtThoiHan.Location = new System.Drawing.Point(114, 21);
            this.txtThoiHan.Name = "txtThoiHan";
            this.txtThoiHan.ReadOnly = true;
            this.txtThoiHan.Size = new System.Drawing.Size(124, 20);
            this.txtThoiHan.TabIndex = 3;
            this.txtThoiHan.TabStop = false;
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayHetHan.Location = new System.Drawing.Point(25, 118);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Size = new System.Drawing.Size(83, 13);
            this.lblNgayHetHan.TabIndex = 2;
            this.lblNgayHetHan.Text = "Ngày hết hạn";
            // 
            // lblGiaTien
            // 
            this.lblGiaTien.AutoSize = true;
            this.lblGiaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTien.Location = new System.Drawing.Point(25, 67);
            this.lblGiaTien.Name = "lblGiaTien";
            this.lblGiaTien.Size = new System.Drawing.Size(51, 13);
            this.lblGiaTien.TabIndex = 1;
            this.lblGiaTien.Text = "Giá tiền";
            // 
            // lblThoiHan
            // 
            this.lblThoiHan.AutoSize = true;
            this.lblThoiHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiHan.Location = new System.Drawing.Point(25, 24);
            this.lblThoiHan.Name = "lblThoiHan";
            this.lblThoiHan.Size = new System.Drawing.Size(57, 13);
            this.lblThoiHan.TabIndex = 0;
            this.lblThoiHan.Text = "Thời hạn";
            // 
            // DangKiGoiTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 262);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangKiGoiTap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng Ký Gói Tập Mới";
            this.Load += new System.EventHandler(this.DangKyGoiTap_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblGoiTap;
        private System.Windows.Forms.ComboBox cboGoiTap;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.Label lblNgayDangKy;
        private System.Windows.Forms.TextBox txtNgayHetHan;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.TextBox txtThoiHan;
        private System.Windows.Forms.Label lblNgayHetHan;
        private System.Windows.Forms.Label lblGiaTien;
        private System.Windows.Forms.Label lblThoiHan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}