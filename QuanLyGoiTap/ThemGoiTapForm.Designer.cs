namespace GZone
{
    partial class frmThemGoiTap
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
            this.lblThemGoiTap = new System.Windows.Forms.Label();
            this.lblTenGoi = new System.Windows.Forms.Label();
            this.lblThoiHan = new System.Windows.Forms.Label();
            this.txtGoiTap = new System.Windows.Forms.TextBox();
            this.numThoiHan = new System.Windows.Forms.NumericUpDown();
            this.lblGia = new System.Windows.Forms.Label();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThemGoiTap
            // 
            this.lblThemGoiTap.AutoSize = true;
            this.lblThemGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThemGoiTap.Location = new System.Drawing.Point(23, 9);
            this.lblThemGoiTap.Name = "lblThemGoiTap";
            this.lblThemGoiTap.Size = new System.Drawing.Size(144, 24);
            this.lblThemGoiTap.TabIndex = 0;
            this.lblThemGoiTap.Text = "Thêm Gói Tập";
            // 
            // lblTenGoi
            // 
            this.lblTenGoi.AutoSize = true;
            this.lblTenGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenGoi.Location = new System.Drawing.Point(34, 54);
            this.lblTenGoi.Name = "lblTenGoi";
            this.lblTenGoi.Size = new System.Drawing.Size(100, 20);
            this.lblTenGoi.TabIndex = 1;
            this.lblTenGoi.Text = "Tên Gói Tập:";
            // 
            // lblThoiHan
            // 
            this.lblThoiHan.AutoSize = true;
            this.lblThoiHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThoiHan.Location = new System.Drawing.Point(34, 92);
            this.lblThoiHan.Name = "lblThoiHan";
            this.lblThoiHan.Size = new System.Drawing.Size(133, 20);
            this.lblThoiHan.TabIndex = 3;
            this.lblThoiHan.Text = "Thời hạn (Tháng):";
            // 
            // txtGoiTap
            // 
            this.txtGoiTap.Location = new System.Drawing.Point(174, 54);
            this.txtGoiTap.Name = "txtGoiTap";
            this.txtGoiTap.Size = new System.Drawing.Size(263, 20);
            this.txtGoiTap.TabIndex = 4;
            // 
            // numThoiHan
            // 
            this.numThoiHan.Location = new System.Drawing.Point(174, 92);
            this.numThoiHan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThoiHan.Name = "numThoiHan";
            this.numThoiHan.Size = new System.Drawing.Size(263, 20);
            this.numThoiHan.TabIndex = 5;
            this.numThoiHan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGia.Location = new System.Drawing.Point(34, 132);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(98, 20);
            this.lblGia.TabIndex = 6;
            this.lblGia.Text = "Giá Gói Tập:";
            // 
            // numGia
            // 
            this.numGia.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGia.Location = new System.Drawing.Point(174, 135);
            this.numGia.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numGia.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(263, 20);
            this.numGia.TabIndex = 7;
            this.numGia.TabStop = false;
            this.numGia.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Green;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLuu.Location = new System.Drawing.Point(281, 175);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(376, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmThemGoiTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(463, 216);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.numThoiHan);
            this.Controls.Add(this.txtGoiTap);
            this.Controls.Add(this.lblThoiHan);
            this.Controls.Add(this.lblTenGoi);
            this.Controls.Add(this.lblThemGoiTap);
            this.Name = "frmThemGoiTap";
            this.Text = "Thêm gói tập";
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThemGoiTap;
        private System.Windows.Forms.Label lblTenGoi;
        private System.Windows.Forms.Label lblThoiHan;
        private System.Windows.Forms.TextBox txtGoiTap;
        private System.Windows.Forms.NumericUpDown numThoiHan;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnCancel;
    }
}