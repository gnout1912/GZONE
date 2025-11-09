namespace GZone
{
    partial class ChinhSuaGoiTapForm
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
            this.lblChinhSua = new System.Windows.Forms.Label();
            this.lblTenGoiTap = new System.Windows.Forms.Label();
            this.txtTenGoiTap = new System.Windows.Forms.TextBox();
            this.lblThoiHan = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.numThoiHan = new System.Windows.Forms.NumericUpDown();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChinhSua
            // 
            this.lblChinhSua.AutoSize = true;
            this.lblChinhSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblChinhSua.Location = new System.Drawing.Point(12, 9);
            this.lblChinhSua.Name = "lblChinhSua";
            this.lblChinhSua.Size = new System.Drawing.Size(173, 24);
            this.lblChinhSua.TabIndex = 0;
            this.lblChinhSua.Text = "Chỉnh sửa gói tập";
            // 
            // lblTenGoiTap
            // 
            this.lblTenGoiTap.AutoSize = true;
            this.lblTenGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenGoiTap.Location = new System.Drawing.Point(20, 59);
            this.lblTenGoiTap.Name = "lblTenGoiTap";
            this.lblTenGoiTap.Size = new System.Drawing.Size(100, 20);
            this.lblTenGoiTap.TabIndex = 1;
            this.lblTenGoiTap.Text = "Tên Gói Tập:";
            // 
            // txtTenGoiTap
            // 
            this.txtTenGoiTap.Location = new System.Drawing.Point(165, 56);
            this.txtTenGoiTap.Name = "txtTenGoiTap";
            this.txtTenGoiTap.Size = new System.Drawing.Size(263, 20);
            this.txtTenGoiTap.TabIndex = 2;
            // 
            // lblThoiHan
            // 
            this.lblThoiHan.AutoSize = true;
            this.lblThoiHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThoiHan.Location = new System.Drawing.Point(20, 93);
            this.lblThoiHan.Name = "lblThoiHan";
            this.lblThoiHan.Size = new System.Drawing.Size(133, 20);
            this.lblThoiHan.TabIndex = 4;
            this.lblThoiHan.Text = "Thời hạn (Tháng):";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGia.Location = new System.Drawing.Point(20, 131);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(98, 20);
            this.lblGia.TabIndex = 7;
            this.lblGia.Text = "Giá Gói Tập:";
            // 
            // numThoiHan
            // 
            this.numThoiHan.Location = new System.Drawing.Point(165, 96);
            this.numThoiHan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThoiHan.Name = "numThoiHan";
            this.numThoiHan.Size = new System.Drawing.Size(263, 20);
            this.numThoiHan.TabIndex = 8;
            this.numThoiHan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numGia
            // 
            this.numGia.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGia.Location = new System.Drawing.Point(165, 134);
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
            this.numGia.TabIndex = 9;
            this.numGia.TabStop = false;
            this.numGia.ThousandsSeparator = true;
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
            this.btnLuu.Location = new System.Drawing.Point(273, 181);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(376, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChinhSuaGoiTapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(463, 216);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.numGia);
            this.Controls.Add(this.numThoiHan);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblThoiHan);
            this.Controls.Add(this.txtTenGoiTap);
            this.Controls.Add(this.lblTenGoiTap);
            this.Controls.Add(this.lblChinhSua);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ChinhSuaGoiTapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa thông tin gói tập";
            this.Load += new System.EventHandler(this.ChinhSuaGoiTapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChinhSua;
        private System.Windows.Forms.Label lblTenGoiTap;
        private System.Windows.Forms.TextBox txtTenGoiTap;
        private System.Windows.Forms.Label lblThoiHan;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.NumericUpDown numThoiHan;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnCancel;
    }
}