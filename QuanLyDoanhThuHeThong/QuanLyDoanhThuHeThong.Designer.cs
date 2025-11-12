namespace GZone.QuanLyDoanhThuHeThong
{
    partial class QuanLyDoanhThuHeThong
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTongHop = new System.Windows.Forms.Button();
            this.btnInDoanhThu = new System.Windows.Forms.Button();
            this.cbTangGiam = new System.Windows.Forms.ComboBox();
            this.cbSapXepTheo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTongHopTheo = new System.Windows.Forms.ComboBox();
            this.cHINHANHBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongGymDataSet2 = new GZone.QuanLyPhongGymDataSet2();
            this.cHINHANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongGymDataSet1 = new GZone.QuanLyPhongGymDataSet1();
            this.quanLyPhongGymDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongGymDataSet = new GZone.QuanLyPhongGymDataSet();
            this.cHI_NHANHTableAdapter = new GZone.QuanLyPhongGymDataSet1TableAdapters.CHI_NHANHTableAdapter();
            this.cHI_NHANHTableAdapter1 = new GZone.QuanLyPhongGymDataSet2TableAdapters.CHI_NHANHTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTongHop);
            this.groupBox1.Controls.Add(this.btnInDoanhThu);
            this.groupBox1.Controls.Add(this.cbTangGiam);
            this.groupBox1.Controls.Add(this.cbSapXepTheo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvThongKe);
            this.groupBox1.Controls.Add(this.cbChiNhanh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbTongHopTheo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Hợp Doanh Thu";
            // 
            // btnTongHop
            // 
            this.btnTongHop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTongHop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTongHop.ForeColor = System.Drawing.Color.White;
            this.btnTongHop.Location = new System.Drawing.Point(507, 48);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(80, 23);
            this.btnTongHop.TabIndex = 8;
            this.btnTongHop.Text = "Tổng hợp";
            this.btnTongHop.UseVisualStyleBackColor = false;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // btnInDoanhThu
            // 
            this.btnInDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnInDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnInDoanhThu.Location = new System.Drawing.Point(593, 49);
            this.btnInDoanhThu.Name = "btnInDoanhThu";
            this.btnInDoanhThu.Size = new System.Drawing.Size(129, 23);
            this.btnInDoanhThu.TabIndex = 7;
            this.btnInDoanhThu.Text = "In Báo Cáo Doanh thu";
            this.btnInDoanhThu.UseVisualStyleBackColor = false;
            this.btnInDoanhThu.Click += new System.EventHandler(this.btnInDoanhThu_Click);
            // 
            // cbTangGiam
            // 
            this.cbTangGiam.FormattingEnabled = true;
            this.cbTangGiam.Location = new System.Drawing.Point(223, 50);
            this.cbTangGiam.Name = "cbTangGiam";
            this.cbTangGiam.Size = new System.Drawing.Size(93, 21);
            this.cbTangGiam.TabIndex = 6;
            // 
            // cbSapXepTheo
            // 
            this.cbSapXepTheo.FormattingEnabled = true;
            this.cbSapXepTheo.Location = new System.Drawing.Point(108, 50);
            this.cbSapXepTheo.Name = "cbSapXepTheo";
            this.cbSapXepTheo.Size = new System.Drawing.Size(93, 21);
            this.cbSapXepTheo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sắp xếp theo:";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(25, 77);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.Size = new System.Drawing.Size(697, 356);
            this.dgvThongKe.TabIndex = 3;
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(223, 23);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(124, 21);
            this.cbChiNhanh.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng hợp theo:";
            // 
            // cbTongHopTheo
            // 
            this.cbTongHopTheo.FormattingEnabled = true;
            this.cbTongHopTheo.Location = new System.Drawing.Point(108, 23);
            this.cbTongHopTheo.Name = "cbTongHopTheo";
            this.cbTongHopTheo.Size = new System.Drawing.Size(93, 21);
            this.cbTongHopTheo.TabIndex = 0;
            // 
            // cHINHANHBindingSource1
            // 
            this.cHINHANHBindingSource1.DataMember = "CHI_NHANH";
            this.cHINHANHBindingSource1.DataSource = this.quanLyPhongGymDataSet2;
            // 
            // quanLyPhongGymDataSet2
            // 
            this.quanLyPhongGymDataSet2.DataSetName = "QuanLyPhongGymDataSet2";
            this.quanLyPhongGymDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cHINHANHBindingSource
            // 
            this.cHINHANHBindingSource.DataMember = "CHI_NHANH";
            this.cHINHANHBindingSource.DataSource = this.quanLyPhongGymDataSet1;
            // 
            // quanLyPhongGymDataSet1
            // 
            this.quanLyPhongGymDataSet1.DataSetName = "QuanLyPhongGymDataSet1";
            this.quanLyPhongGymDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLyPhongGymDataSetBindingSource
            // 
            this.quanLyPhongGymDataSetBindingSource.DataSource = this.quanLyPhongGymDataSet;
            this.quanLyPhongGymDataSetBindingSource.Position = 0;
            // 
            // quanLyPhongGymDataSet
            // 
            this.quanLyPhongGymDataSet.DataSetName = "QuanLyPhongGymDataSet";
            this.quanLyPhongGymDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cHI_NHANHTableAdapter
            // 
            this.cHI_NHANHTableAdapter.ClearBeforeFill = true;
            // 
            // cHI_NHANHTableAdapter1
            // 
            this.cHI_NHANHTableAdapter1.ClearBeforeFill = true;
            // 
            // QuanLyDoanhThuHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 474);
            this.Controls.Add(this.groupBox1);
            this.Name = "QuanLyDoanhThuHeThong";
            this.Text = "Quản Lý Doanh Thu Hệ Thống";
            this.Load += new System.EventHandler(this.QuanLyDoanhThuHeThong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTongHopTheo;
        private System.Windows.Forms.ComboBox cbChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource quanLyPhongGymDataSetBindingSource;
        private QuanLyPhongGymDataSet quanLyPhongGymDataSet;
        private QuanLyPhongGymDataSet1 quanLyPhongGymDataSet1;
        private System.Windows.Forms.BindingSource cHINHANHBindingSource;
        private QuanLyPhongGymDataSet1TableAdapters.CHI_NHANHTableAdapter cHI_NHANHTableAdapter;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInDoanhThu;
        private System.Windows.Forms.ComboBox cbTangGiam;
        private System.Windows.Forms.ComboBox cbSapXepTheo;
        private QuanLyPhongGymDataSet2 quanLyPhongGymDataSet2;
        private System.Windows.Forms.BindingSource cHINHANHBindingSource1;
        private QuanLyPhongGymDataSet2TableAdapters.CHI_NHANHTableAdapter cHI_NHANHTableAdapter1;
        private System.Windows.Forms.Button btnTongHop;
    }
}