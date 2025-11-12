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
            this.btnInDoanhThu = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbx2Thang = new System.Windows.Forms.ComboBox();
            this.cHINHANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongGymDataSet1 = new GZone.QuanLyPhongGymDataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxNgay = new System.Windows.Forms.ComboBox();
            this.quanLyPhongGymDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongGymDataSet = new GZone.QuanLyPhongGymDataSet();
            this.cHI_NHANHTableAdapter = new GZone.QuanLyPhongGymDataSet1TableAdapters.CHI_NHANHTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInDoanhThu);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.cbx2Thang);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxNgay);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Hợp Doanh Thu";
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
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.comboBox2.Location = new System.Drawing.Point(223, 50);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(93, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.comboBox1.Location = new System.Drawing.Point(108, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 21);
            this.comboBox1.TabIndex = 5;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(697, 356);
            this.dataGridView1.TabIndex = 3;
            // 
            // cbx2Thang
            // 
            this.cbx2Thang.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cHINHANHBindingSource, "CN_Ten", true));
            this.cbx2Thang.DataSource = this.cHINHANHBindingSource;
            this.cbx2Thang.DisplayMember = "CN_Ten";
            this.cbx2Thang.FormattingEnabled = true;
            this.cbx2Thang.Location = new System.Drawing.Point(223, 23);
            this.cbx2Thang.Name = "cbx2Thang";
            this.cbx2Thang.Size = new System.Drawing.Size(124, 21);
            this.cbx2Thang.TabIndex = 2;
            this.cbx2Thang.ValueMember = "CN_Ma";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng hợp theo:";
            // 
            // cbxNgay
            // 
            this.cbxNgay.FormattingEnabled = true;
            this.cbxNgay.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.cbxNgay.Location = new System.Drawing.Point(108, 23);
            this.cbxNgay.Name = "cbxNgay";
            this.cbxNgay.Size = new System.Drawing.Size(93, 21);
            this.cbxNgay.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHINHANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongGymDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxNgay;
        private System.Windows.Forms.ComboBox cbx2Thang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource quanLyPhongGymDataSetBindingSource;
        private QuanLyPhongGymDataSet quanLyPhongGymDataSet;
        private QuanLyPhongGymDataSet1 quanLyPhongGymDataSet1;
        private System.Windows.Forms.BindingSource cHINHANHBindingSource;
        private QuanLyPhongGymDataSet1TableAdapters.CHI_NHANHTableAdapter cHI_NHANHTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInDoanhThu;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}