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
            this.btnTaoQR = new System.Windows.Forms.Button();
            this.picQR = new System.Windows.Forms.PictureBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudSoTienThu = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTienThu)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(127, 48);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(169, 22);
            this.txtMaSV.TabIndex = 0;
            // 
            // txtMaHK
            // 
            this.txtMaHK.Location = new System.Drawing.Point(127, 108);
            this.txtMaHK.Name = "txtMaHK";
            this.txtMaHK.Size = new System.Drawing.Size(169, 22);
            this.txtMaHK.TabIndex = 2;
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Location = new System.Drawing.Point(342, 45);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(115, 85);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tra cứu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Học Kỳ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã số sinh viên:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTaoQR);
            this.groupBox2.Controls.Add(this.picQR);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 269);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // btnTaoQR
            // 
            this.btnTaoQR.Location = new System.Drawing.Point(388, 227);
            this.btnTaoQR.Name = "btnTaoQR";
            this.btnTaoQR.Size = new System.Drawing.Size(86, 41);
            this.btnTaoQR.TabIndex = 11;
            this.btnTaoQR.Text = "Tạo QR";
            this.btnTaoQR.UseVisualStyleBackColor = true;
            this.btnTaoQR.Click += new System.EventHandler(this.btnTaoQR_Click);
            // 
            // picQR
            // 
            this.picQR.Image = ((System.Drawing.Image)(resources.GetObject("picQR.Image")));
            this.picQR.Location = new System.Drawing.Point(323, 13);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(197, 208);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 10;
            this.picQR.TabStop = false;
            // 
            // lblDaThu
            // 
            this.lblDaThu.AutoSize = true;
            this.lblDaThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblDaThu.Location = new System.Drawing.Point(168, 169);
            this.lblDaThu.Name = "lblDaThu";
            this.lblDaThu.Size = new System.Drawing.Size(31, 17);
            this.lblDaThu.TabIndex = 9;
            this.lblDaThu.Text = "0 đ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Số tiền đã thu:";
            // 
            // lblConNo
            // 
            this.lblConNo.AutoSize = true;
            this.lblConNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblConNo.ForeColor = System.Drawing.Color.Red;
            this.lblConNo.Location = new System.Drawing.Point(168, 220);
            this.lblConNo.Name = "lblConNo";
            this.lblConNo.Size = new System.Drawing.Size(31, 17);
            this.lblConNo.TabIndex = 7;
            this.lblConNo.Text = "0 đ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Học phí còn nợ:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblPhaiThu
            // 
            this.lblPhaiThu.AutoSize = true;
            this.lblPhaiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblPhaiThu.Location = new System.Drawing.Point(168, 125);
            this.lblPhaiThu.Name = "lblPhaiThu";
            this.lblPhaiThu.Size = new System.Drawing.Size(31, 17);
            this.lblPhaiThu.TabIndex = 5;
            this.lblPhaiThu.Text = "0 đ";
            this.lblPhaiThu.Click += new System.EventHandler(this.lblPhaiThu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Học phí phải thu:";
            // 
            // lblTongTC
            // 
            this.lblTongTC.AutoSize = true;
            this.lblTongTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblTongTC.Location = new System.Drawing.Point(168, 79);
            this.lblTongTC.Name = "lblTongTC";
            this.lblTongTC.Size = new System.Drawing.Size(17, 17);
            this.lblTongTC.TabIndex = 3;
            this.lblTongTC.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng tín chỉ đăng ký:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.Location = new System.Drawing.Point(139, 27);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(24, 20);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "...";
            this.lblHoTen.Click += new System.EventHandler(this.lblHoTen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ tên sinh viên:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLapPhieu);
            this.groupBox3.Controls.Add(this.txtGhiChu);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.nudSoTienThu);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(544, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 491);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hóa đơn";
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLapPhieu.FlatAppearance.BorderSize = 0;
            this.btnLapPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLapPhieu.Location = new System.Drawing.Point(93, 391);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(201, 74);
            this.btnLapPhieu.TabIndex = 4;
            this.btnLapPhieu.Text = "Lập Phiếu Thu";
            this.btnLapPhieu.UseVisualStyleBackColor = false;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(66, 123);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(291, 127);
            this.txtGhiChu.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ghi chú:";
            // 
            // nudSoTienThu
            // 
            this.nudSoTienThu.Location = new System.Drawing.Point(146, 63);
            this.nudSoTienThu.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudSoTienThu.Name = "nudSoTienThu";
            this.nudSoTienThu.Size = new System.Drawing.Size(159, 22);
            this.nudSoTienThu.TabIndex = 1;
            this.nudSoTienThu.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số tiền thu (VNĐ):";
            // 
            // frmThuHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThuHocPhi";
            this.Text = "FrmThuHocPhi";
            this.Load += new System.EventHandler(this.FrmThuHocPhi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTienThu)).EndInit();
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
        private System.Windows.Forms.Button btnTaoQR;
        private System.Windows.Forms.PictureBox picQR;
    }
}