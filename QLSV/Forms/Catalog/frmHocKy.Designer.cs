namespace QLSV.Forms.Catalog
{
    partial class frmHocKy
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvHocKy = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenHK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaHK = new System.Windows.Forms.TextBox();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(26, 26);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(66, 37);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(200, 26);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(66, 37);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(286, 26);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(66, 37);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(112, 26);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(66, 37);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvHocKy
            // 
            this.dgvHocKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocKy.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvHocKy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHocKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHocKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvHocKy.Location = new System.Drawing.Point(10, 150);
            this.dgvHocKy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvHocKy.Name = "dgvHocKy";
            this.dgvHocKy.RowHeadersWidth = 51;
            this.dgvHocKy.RowTemplate.Height = 24;
            this.dgvHocKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocKy.Size = new System.Drawing.Size(782, 360);
            this.dgvHocKy.TabIndex = 4;
            this.dgvHocKy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHocKy_CellClick);
            this.dgvHocKy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHocKy_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaHK";
            this.Column1.HeaderText = "Mã HK";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenHK";
            this.Column2.HeaderText = "Tên học kỳ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NamHoc";
            this.Column3.HeaderText = "Năm học";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TuNgay";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "Từ ngày";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DenNgay";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column5.HeaderText = "Đến ngày";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DonGiaTinChi";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column6.HeaderText = "Đơn giá/Tín chỉ";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên học kỳ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTenHK
            // 
            this.txtTenHK.Location = new System.Drawing.Point(275, 13);
            this.txtTenHK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenHK.Name = "txtTenHK";
            this.txtTenHK.Size = new System.Drawing.Size(181, 20);
            this.txtTenHK.TabIndex = 6;
            this.txtTenHK.TextChanged += new System.EventHandler(this.txtTenHK_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Đơn giá tín chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã học kỳ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(475, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Năm học";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtMaHK
            // 
            this.txtMaHK.Location = new System.Drawing.Point(82, 13);
            this.txtMaHK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaHK.Name = "txtMaHK";
            this.txtMaHK.Size = new System.Drawing.Size(106, 20);
            this.txtMaHK.TabIndex = 10;
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(542, 14);
            this.txtNamHoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Size = new System.Drawing.Size(132, 20);
            this.txtNamHoc.TabIndex = 11;
            this.txtNamHoc.TextChanged += new System.EventHandler(this.txtNamHoc_TextChanged);
            // 
            // numDonGia
            // 
            this.numDonGia.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.numDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDonGia.Location = new System.Drawing.Point(106, 99);
            this.numDonGia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numDonGia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.Size = new System.Drawing.Size(170, 19);
            this.numDonGia.TabIndex = 12;
            this.numDonGia.ThousandsSeparator = true;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(82, 53);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(96, 20);
            this.dtpTuNgay.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bắt đầu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(200, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Kết thúc";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(269, 57);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(96, 20);
            this.dtpDenNgay.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Location = new System.Drawing.Point(381, 56);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(364, 76);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // frmHocKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::QLSV.Properties.Resources.abstract_background_with_soft_gradient_color_and_dynamic_shadow_on_background_background_for_wallpaper_eps_10_free_vector;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 528);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.numDonGia);
            this.Controls.Add(this.txtNamHoc);
            this.Controls.Add(this.txtMaHK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenHK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHocKy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmHocKy";
            this.Text = "frmHocKy";
            this.Load += new System.EventHandler(this.frmHocKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvHocKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenHK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaHK;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}