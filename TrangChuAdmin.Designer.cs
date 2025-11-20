namespace GZone
{
    partial class TrangChuAdmin
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQuanLyTaiKhoan = new System.Windows.Forms.Button();
            this.btnQuanLyChiNhanh = new System.Windows.Forms.Button();
            this.btnQuanLyDoanhThu = new System.Windows.Forms.Button();
            this.btnQuanLyGoiTap = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GZone.Properties.Resources.gymlogo;
            this.pictureBox1.Location = new System.Drawing.Point(236, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnQuanLyTaiKhoan
            // 
            this.btnQuanLyTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnQuanLyTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuanLyTaiKhoan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuanLyTaiKhoan.Location = new System.Drawing.Point(93, 145);
            this.btnQuanLyTaiKhoan.Name = "btnQuanLyTaiKhoan";
            this.btnQuanLyTaiKhoan.Size = new System.Drawing.Size(181, 62);
            this.btnQuanLyTaiKhoan.TabIndex = 1;
            this.btnQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.btnQuanLyTaiKhoan.UseVisualStyleBackColor = false;
            this.btnQuanLyTaiKhoan.Click += new System.EventHandler(this.btnQuanLyTaiKhoan_Click);
            // 
            // btnQuanLyChiNhanh
            // 
            this.btnQuanLyChiNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnQuanLyChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuanLyChiNhanh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuanLyChiNhanh.Location = new System.Drawing.Point(326, 145);
            this.btnQuanLyChiNhanh.Name = "btnQuanLyChiNhanh";
            this.btnQuanLyChiNhanh.Size = new System.Drawing.Size(181, 62);
            this.btnQuanLyChiNhanh.TabIndex = 2;
            this.btnQuanLyChiNhanh.Text = "Quản lý chi nhánh";
            this.btnQuanLyChiNhanh.UseVisualStyleBackColor = false;
            this.btnQuanLyChiNhanh.Click += new System.EventHandler(this.btnQuanLyChiNhanh_Click);
            // 
            // btnQuanLyDoanhThu
            // 
            this.btnQuanLyDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnQuanLyDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuanLyDoanhThu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuanLyDoanhThu.Location = new System.Drawing.Point(93, 235);
            this.btnQuanLyDoanhThu.Name = "btnQuanLyDoanhThu";
            this.btnQuanLyDoanhThu.Size = new System.Drawing.Size(181, 62);
            this.btnQuanLyDoanhThu.TabIndex = 3;
            this.btnQuanLyDoanhThu.Text = "Quản lý doanh thu hệ thống";
            this.btnQuanLyDoanhThu.UseVisualStyleBackColor = false;
            this.btnQuanLyDoanhThu.Click += new System.EventHandler(this.btnQuanDoanhThu_click);
            // 
            // btnQuanLyGoiTap
            // 
            this.btnQuanLyGoiTap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnQuanLyGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuanLyGoiTap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuanLyGoiTap.Location = new System.Drawing.Point(326, 235);
            this.btnQuanLyGoiTap.Name = "btnQuanLyGoiTap";
            this.btnQuanLyGoiTap.Size = new System.Drawing.Size(181, 62);
            this.btnQuanLyGoiTap.TabIndex = 4;
            this.btnQuanLyGoiTap.Text = "Quản lý gói tập";
            this.btnQuanLyGoiTap.UseVisualStyleBackColor = false;
            this.btnQuanLyGoiTap.Click += new System.EventHandler(this.btnQuanLyGoiTap_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.Red;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSignOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSignOut.Location = new System.Drawing.Point(416, 337);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(116, 41);
            this.btnSignOut.TabIndex = 9;
            this.btnSignOut.Text = "Đăng xuất";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // TrangChuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnQuanLyGoiTap);
            this.Controls.Add(this.btnQuanLyDoanhThu);
            this.Controls.Add(this.btnQuanLyChiNhanh);
            this.Controls.Add(this.btnQuanLyTaiKhoan);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TrangChuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnQuanLyTaiKhoan;
        private System.Windows.Forms.Button btnQuanLyChiNhanh;
        private System.Windows.Forms.Button btnQuanLyDoanhThu;
        private System.Windows.Forms.Button btnQuanLyGoiTap;
        private System.Windows.Forms.Button btnSignOut;
    }
}