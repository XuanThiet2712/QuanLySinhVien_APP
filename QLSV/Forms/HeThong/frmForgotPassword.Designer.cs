namespace QLSV.Forms.HeThong
{
    partial class frmForgotPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.btnGuiMa = new System.Windows.Forms.Button();
            this.txtOtp = new System.Windows.Forms.TextBox();
            this.txtMoi = new System.Windows.Forms.TextBox();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHienMatKhauMoi = new System.Windows.Forms.Button();
            this.btnXacNhanMatKhau = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã OTP : ";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(46, 54);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(338, 22);
            this.txtTenDangNhap.TabIndex = 2;
            // 
            // btnGuiMa
            // 
            this.btnGuiMa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGuiMa.Location = new System.Drawing.Point(295, 113);
            this.btnGuiMa.Name = "btnGuiMa";
            this.btnGuiMa.Size = new System.Drawing.Size(89, 30);
            this.btnGuiMa.TabIndex = 3;
            this.btnGuiMa.Text = "Gửi mã";
            this.btnGuiMa.UseVisualStyleBackColor = false;
            this.btnGuiMa.Click += new System.EventHandler(this.btnGuiMa_Click);
            // 
            // txtOtp
            // 
            this.txtOtp.Location = new System.Drawing.Point(46, 121);
            this.txtOtp.Name = "txtOtp";
            this.txtOtp.Size = new System.Drawing.Size(224, 22);
            this.txtOtp.TabIndex = 4;
            // 
            // txtMoi
            // 
            this.txtMoi.Location = new System.Drawing.Point(46, 190);
            this.txtMoi.Name = "txtMoi";
            this.txtMoi.Size = new System.Drawing.Size(224, 22);
            this.txtMoi.TabIndex = 5;
            this.txtMoi.UseSystemPasswordChar = true;
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Location = new System.Drawing.Point(46, 254);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(224, 22);
            this.txtNhapLai.TabIndex = 6;
            this.txtNhapLai.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mật khẩu mới : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nhập lại mật khẩu mới : ";
            // 
            // btnDoi
            // 
            this.btnDoi.Location = new System.Drawing.Point(12, 441);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(233, 47);
            this.btnDoi.TabIndex = 9;
            this.btnDoi.Text = "Đổi mật khẩu";
            this.btnDoi.UseVisualStyleBackColor = true;
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(270, 441);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(157, 47);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Quay trở lại";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXacNhanMatKhau);
            this.groupBox1.Controls.Add(this.btnHienMatKhauMoi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNhapLai);
            this.groupBox1.Controls.Add(this.btnGuiMa);
            this.groupBox1.Controls.Add(this.txtMoi);
            this.groupBox1.Controls.Add(this.txtOtp);
            this.groupBox1.Controls.Add(this.txtTenDangNhap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 338);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XÁC THỰC TÀI KHOẢN";
            // 
            // btnHienMatKhauMoi
            // 
            this.btnHienMatKhauMoi.Location = new System.Drawing.Point(295, 190);
            this.btnHienMatKhauMoi.Name = "btnHienMatKhauMoi";
            this.btnHienMatKhauMoi.Size = new System.Drawing.Size(89, 30);
            this.btnHienMatKhauMoi.TabIndex = 9;
            this.btnHienMatKhauMoi.Text = "👁";
            this.btnHienMatKhauMoi.UseVisualStyleBackColor = true;
            this.btnHienMatKhauMoi.Click += new System.EventHandler(this.btnHienMatKhauMoi_Click);
            // 
            // btnXacNhanMatKhau
            // 
            this.btnXacNhanMatKhau.Location = new System.Drawing.Point(295, 250);
            this.btnXacNhanMatKhau.Name = "btnXacNhanMatKhau";
            this.btnXacNhanMatKhau.Size = new System.Drawing.Size(89, 30);
            this.btnXacNhanMatKhau.TabIndex = 10;
            this.btnXacNhanMatKhau.Text = "👁";
            this.btnXacNhanMatKhau.UseVisualStyleBackColor = true;
            this.btnXacNhanMatKhau.Click += new System.EventHandler(this.btnHienMauKhauCu_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(9, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(417, 51);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "KHÔI PHỤC MẬT KHẨU\r\nXác thực tài khoản để đặt lại mật khẩu";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(450, 507);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnDoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.Load += new System.EventHandler(this.frmForgotPassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Button btnGuiMa;
        private System.Windows.Forms.TextBox txtOtp;
        private System.Windows.Forms.TextBox txtMoi;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXacNhanMatKhau;
        private System.Windows.Forms.Button btnHienMatKhauMoi;
        private System.Windows.Forms.TextBox textBox1;
    }
}