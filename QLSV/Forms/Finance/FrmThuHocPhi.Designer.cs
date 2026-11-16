namespace QLSV.Forms.Finance
{
    partial class frmThuHocPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuHocPhi));
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtMaHK = new System.Windows.Forms.TextBox();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDaThu = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblConNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPhaiThu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTongTC = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudSoTienThu = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTienThu)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(86, 23);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(170, 20);
            this.txtMaSV.TabIndex = 0;
            // 
            // txtMaHK
            // 
            this.txtMaHK.Location = new System.Drawing.Point(86, 57);
            this.txtMaHK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaHK.Name = "txtMaHK";
            this.txtMaHK.Size = new System.Drawing.Size(170, 20);
            this.txtMaHK.TabIndex = 2;
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Location = new System.Drawing.Point(172, 93);
            this.btnTraCuu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(82, 31);
            this.btnTraCuu.TabIndex = 3;
            this.btnTraCuu.Text = "Tra Cứu";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTraCuu);
            this.groupBox1.Controls.Add(this.txtMaHK);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Location = new System.Drawing.Point(17, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(305, 146);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tra cứu thông tin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Học Kỳ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã số sinh viên:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDaThu);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblConNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPhaiThu);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblTongTC);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblHoTen);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(346, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(380, 146);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin sinh viên";
            // 
            // lblDaThu
            // 
            this.lblDaThu.AutoSize = true;
            this.lblDaThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblDaThu.Location = new System.Drawing.Point(126, 93);
            this.lblDaThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDaThu.Name = "lblDaThu";
            this.lblDaThu.Size = new System.Drawing.Size(26, 13);
            this.lblDaThu.TabIndex = 9;
            this.lblDaThu.Text = "0 đ";
            this.lblDaThu.Click += new System.EventHandler(this.lblDaThu_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Số tiền đã thu:";
            // 
            // lblConNo
            // 
            this.lblConNo.AutoSize = true;
            this.lblConNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblConNo.ForeColor = System.Drawing.Color.Red;
            this.lblConNo.Location = new System.Drawing.Point(127, 110);
            this.lblConNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConNo.Name = "lblConNo";
            this.lblConNo.Size = new System.Drawing.Size(26, 13);
            this.lblConNo.TabIndex = 7;
            this.lblConNo.Text = "0 đ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Học phí còn nợ:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblPhaiThu
            // 
            this.lblPhaiThu.AutoSize = true;
            this.lblPhaiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblPhaiThu.Location = new System.Drawing.Point(127, 69);
            this.lblPhaiThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhaiThu.Name = "lblPhaiThu";
            this.lblPhaiThu.Size = new System.Drawing.Size(26, 13);
            this.lblPhaiThu.TabIndex = 5;
            this.lblPhaiThu.Text = "0 đ";
            this.lblPhaiThu.Click += new System.EventHandler(this.lblPhaiThu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Học phí phải thu:";
            // 
            // lblTongTC
            // 
            this.lblTongTC.AutoSize = true;
            this.lblTongTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblTongTC.Location = new System.Drawing.Point(125, 48);
            this.lblTongTC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTC.Name = "lblTongTC";
            this.lblTongTC.Size = new System.Drawing.Size(14, 13);
            this.lblTongTC.TabIndex = 3;
            this.lblTongTC.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng tín chỉ đăng ký:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.Location = new System.Drawing.Point(104, 22);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(23, 17);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "...";
            this.lblHoTen.Click += new System.EventHandler(this.lblHoTen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ tên sinh viên:";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(171, 41);
            this.lblTaiKhoan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(102, 13);
            this.lblTaiKhoan.TabIndex = 7;
            this.lblTaiKhoan.Text = "Tài khoản nhận tiền";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(171, 100);
            this.lblNoiDung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(121, 13);
            this.lblNoiDung.TabIndex = 8;
            this.lblNoiDung.Text = "Nội dung chuyển khoản";
            // 
            // picQR
            // 
            this.picQR.Image = ((System.Drawing.Image)(resources.GetObject("picQR.Image")));
            this.picQR.Location = new System.Drawing.Point(19, 44);
            this.picQR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(140, 140);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 10;
            this.picQR.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLapPhieu);
            this.groupBox3.Controls.Add(this.txtGhiChu);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.nudSoTienThu);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(391, 178);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(334, 219);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Số tiền thu";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLapPhieu.FlatAppearance.BorderSize = 0;
            this.btnLapPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLapPhieu.Location = new System.Drawing.Point(12, 144);
            this.btnLapPhieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(151, 49);
            this.btnLapPhieu.TabIndex = 4;
            this.btnLapPhieu.Text = "Lập Phiếu Thu";
            this.btnLapPhieu.UseVisualStyleBackColor = false;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(104, 60);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(213, 71);
            this.txtGhiChu.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 60);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ghi chú:";
            // 
            // nudSoTienThu
            // 
            this.nudSoTienThu.Location = new System.Drawing.Point(104, 21);
            this.nudSoTienThu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSoTienThu.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudSoTienThu.Name = "nudSoTienThu";
            this.nudSoTienThu.Size = new System.Drawing.Size(212, 23);
            this.nudSoTienThu.TabIndex = 1;
            this.nudSoTienThu.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số tiền thu (VNĐ):";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTaiKhoan);
            this.groupBox4.Controls.Add(this.lblNoiDung);
            this.groupBox4.Controls.Add(this.picQR);
            this.groupBox4.Location = new System.Drawing.Point(16, 178);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(357, 219);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mã QR thanh toán";
            // 
            // frmThuHocPhi
            // 
            this.AcceptButton = this.btnTraCuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 452);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmThuHocPhi";
            this.Text = "Thu học phí";
            this.Load += new System.EventHandler(this.FrmThuHocPhi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTienThu)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtMaHK;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongTC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPhaiThu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblConNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudSoTienThu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDaThu;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}