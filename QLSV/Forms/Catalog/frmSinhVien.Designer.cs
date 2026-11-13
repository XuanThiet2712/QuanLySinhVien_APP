namespace QLSV.Forms.Catalog
{
    partial class frmSinhVien
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
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.cboLocLop = new System.Windows.Forms.ComboBox();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.grbGioiTinh = new System.Windows.Forms.GroupBox();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnSau = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblTrang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.grbGioiTinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(33, 428);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 45);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(661, 68);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersWidth = 51;
            this.dgvSinhVien.RowTemplate.Height = 24;
            this.dgvSinhVien.Size = new System.Drawing.Size(615, 309);
            this.dgvSinhVien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã sinh viên";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(118, 14);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(225, 22);
            this.txtMaSV.TabIndex = 3;
            // 
            // picAnh
            // 
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.Location = new System.Drawing.Point(424, 128);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(150, 150);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabIndex = 4;
            this.picAnh.TabStop = false;
            // 
            // cboLocLop
            // 
            this.cboLocLop.FormattingEnabled = true;
            this.cboLocLop.Location = new System.Drawing.Point(472, 12);
            this.cboLocLop.Name = "cboLocLop";
            this.cboLocLop.Size = new System.Drawing.Size(191, 24);
            this.cboLocLop.TabIndex = 5;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNam.Location = new System.Drawing.Point(89, -1);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(60, 20);
            this.radNam.TabIndex = 6;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // grbGioiTinh
            // 
            this.grbGioiTinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grbGioiTinh.Controls.Add(this.radNu);
            this.grbGioiTinh.Controls.Add(this.radNam);
            this.grbGioiTinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGioiTinh.Location = new System.Drawing.Point(7, 128);
            this.grbGioiTinh.Name = "grbGioiTinh";
            this.grbGioiTinh.Size = new System.Drawing.Size(258, 29);
            this.grbGioiTinh.TabIndex = 7;
            this.grbGioiTinh.TabStop = false;
            this.grbGioiTinh.Text = "Giới tính";
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNu.Location = new System.Drawing.Point(179, -1);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(47, 20);
            this.radNu.TabIndex = 7;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(173, 428);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(99, 45);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(313, 428);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(99, 45);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(453, 428);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(99, 45);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ngày sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Họ tên";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(364, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Lớp sinh hoạt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Số điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(691, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tìm kiếm";
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(1177, 30);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(99, 25);
            this.btnTim.TabIndex = 18;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // btnTruoc
            // 
            this.btnTruoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruoc.Location = new System.Drawing.Point(794, 382);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(99, 25);
            this.btnTruoc.TabIndex = 19;
            this.btnTruoc.Text = "<";
            this.btnTruoc.UseVisualStyleBackColor = true;
            // 
            // btnSau
            // 
            this.btnSau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSau.Location = new System.Drawing.Point(1048, 382);
            this.btnSau.Name = "btnSau";
            this.btnSau.Size = new System.Drawing.Size(99, 25);
            this.btnSau.TabIndex = 20;
            this.btnSau.Text = ">\r\n";
            this.btnSau.UseVisualStyleBackColor = true;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(788, 33);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(362, 22);
            this.txtTim.TabIndex = 21;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(743, 428);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 45);
            this.btnImport.TabIndex = 22;
            this.btnImport.Text = "Nhập danh sách";
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(1048, 428);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 45);
            this.btnExport.TabIndex = 23;
            this.btnExport.Text = "Xuất danh sách";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(71, 68);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(272, 22);
            this.txtHoTen.TabIndex = 24;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(99, 189);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(244, 22);
            this.dtpNgaySinh.TabIndex = 25;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(86, 243);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(257, 22);
            this.txtDiaChi.TabIndex = 26;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(87, 297);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(256, 22);
            this.txtEmail.TabIndex = 27;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(118, 351);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(225, 22);
            this.txtSDT.TabIndex = 28;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.LightGray;
            this.btnChonAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.Location = new System.Drawing.Point(455, 286);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(85, 33);
            this.btnChonAnh.TabIndex = 29;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            // 
            // lblTrang
            // 
            this.lblTrang.AutoSize = true;
            this.lblTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrang.Location = new System.Drawing.Point(911, 391);
            this.lblTrang.Name = "lblTrang";
            this.lblTrang.Size = new System.Drawing.Size(119, 16);
            this.lblTrang.TabIndex = 30;
            this.lblTrang.Text = "Trang 1/1 (0 SV)";
            // 
            // frmSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1300, 503);
            this.Controls.Add(this.lblTrang);
            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnSau);
            this.Controls.Add(this.btnTruoc);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.grbGioiTinh);
            this.Controls.Add(this.cboLocLop);
            this.Controls.Add(this.picAnh);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSinhVien";
            this.Text = "frmSinhVien";
            this.Load += new System.EventHandler(this.frmSinhVien_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.grbGioiTinh.ResumeLayout(false);
            this.grbGioiTinh.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.ComboBox cboLocLop;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.GroupBox grbGioiTinh;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lblTrang;
    }
}